using Microsoft.AspNetCore.Mvc;
using VidlyMoshNet8.Data;
using VidlyMoshNet8.DTO;
using VidlyMoshNet8.Models;

namespace VidlyMoshNet8.Controllers.API
{
    [Route("api/newRental")]
    public class NewRentalsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NewRentalsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateNewRentals([FromForm]NewRentalDTO newRental)
        {
            var customer = _context.Customers.SingleOrDefault(
	            c => c.Id == newRental.CustomerId);
            if (customer == null)
            {
                return BadRequest("Invalid customer ID.");
            }
            var movies = _context.Movies.Where(
	            m => newRental.MovieIds.Contains(m.Id)).ToList();
            if (movies.Count != newRental.MovieIds.Count)
            {
                return BadRequest("One or more movie IDs are invalid.");
            }

            foreach (var movie in movies)
			{
				if (movie.NumberAvailable == 0)
				{
					return BadRequest("Movie is not available.");
				}
				movie.NumberAvailable--;
				var rental = new Rental
				{
					Customer = customer,
					Movie = movie,
					DateRented = DateTime.Now
				};
				_context.Rental.Add(rental);
			}
            _context.SaveChanges();

            return Ok();
        }
    }
}
