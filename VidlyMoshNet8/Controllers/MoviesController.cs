using Microsoft.AspNetCore.Mvc;
using VidlyMoshNet8.Models;
using VidlyMoshNet8.ViewModel;

namespace VidlyMoshNet8.Controllers;

public class MoviesController : Controller
{
    public ViewResult Index()
    {
        var movies = GetMovies();
        return View(movies);
    }

    private IEnumerable<Movie> GetMovies()
    {
        return new List<Movie>
        {
            new Movie { Id = 1, Name = "Shrek" },
            new Movie { Id = 2, Name = "Wall-e" }
        };
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
}