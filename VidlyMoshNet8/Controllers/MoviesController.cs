using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyMoshNet8.Data;
using VidlyMoshNet8.Models;
using VidlyMoshNet8.ViewModel;

namespace VidlyMoshNet8.Controllers;

public class MoviesController : Controller
{
    private readonly AppDbContext _context;

    public MoviesController(AppDbContext context)
    {
        _context = context;
    }

    protected override void Dispose(bool disposing)
    {
        _context.Dispose();
    }

    public ViewResult Index()
    {
        var movies = _context.Movies.Include(m=>m.Genre).ToList();
        return View(movies);
    }
    public ViewResult New()
    {
        var genres = _context.Genre.ToList();
        var viewModel = new MovieFormViewModel
        {
            
            Genres = genres
        };

        return View("MoviesForm", viewModel);
    }
    public ActionResult Edit(int id)
    {
        var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

        if (movie == null)
            return NotFound();

        var viewModel = new MovieFormViewModel
        {
            Genres = _context.Genre.ToList()
        };

        return View("MoviesForm", viewModel);
    }

    public ActionResult Details(int id)
    {
        var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

        if (movie == null)
            return new NotFoundResult();

        return View(movie);
    }

    public ActionResult Random()
    {
        var movie = new Movie() { Name = "Shrek!" };
        var customers = new List<Customers>
        {
            new Customers { Name = "Customer 1" },
            new Customers { Name = "Customer 2" }
        };

        var viewModel = new RandomMovieViewModel
        {
            Movie = movie,
            Customers = customers
        };

        return View(viewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Save(Movie movie)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "");
            var viewModel = new MovieFormViewModel
            {
                Genres = _context.Genre.ToList()
            };
            return View("MoviesForm", viewModel);
        }
        if(movie.Id ==0)
        {
            movie.DateAdded = DateTime.Now;
            _context.Movies.Add(movie);
        }
        else
        {
            var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
            
            movieInDb.Name = movie.Name;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.GenreId = movie.GenreId;
            movieInDb.NumberInStock = movie.NumberInStock;
        }
        _context.SaveChanges();
        return RedirectToAction("Index", "Movies");
    }
}