using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VidlyMoshNet8.Models;

namespace VidlyMoshNet8.Controllers
{
    public class CustomerController : Controller
    {
        public ViewResult Index()
        {
            var customers = GetCustomers();
            //var hello = "Hello World!";
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return new NotFoundResult();

            return View(customer);
        }

        private IEnumerable<Customers> GetCustomers()
        {
            return new List<Customers>
            {
                new Customers { Id = 1, Name = "John Smith" },
                new Customers { Id = 2, Name = "Mary Williams" }
            };
        }
    }
}
