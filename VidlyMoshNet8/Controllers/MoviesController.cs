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
}