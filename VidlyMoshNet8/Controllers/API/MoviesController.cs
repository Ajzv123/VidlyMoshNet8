using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyMoshNet8.Data;
using VidlyMoshNet8.DTO;
using VidlyMoshNet8.Models;

namespace VidlyMoshNet8.Controllers.API
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : Controller
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;

        public MoviesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(_context.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(_mapper.Map<Movie, MovieDTO>));       }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());
            }
            return Ok(_mapper.Map<Movie, MovieDTO>(movie));
        }

        [HttpPost]
        public IActionResult CreateMovie(MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = _mapper.Map<MovieDTO, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(Request.Path.ToString() + "/" + movie.Id, movieDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
            {
                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());
            }
            _mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
            {
                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());
            }
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
