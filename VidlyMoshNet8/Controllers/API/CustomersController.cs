using System.Net;
using Microsoft.AspNetCore.Mvc;
using VidlyMoshNet8.Data;
using VidlyMoshNet8.Models;

namespace VidlyMoshNet8.Controllers.API
{
    [Route("api/customer")]
    [ApiController]
    public class CustomersController : Controller
    {
        private AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }
         // GET: api/customers
        [HttpGet]
        public IEnumerable<Customers> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        // GET: api/customers/1
        [HttpGet ("{id}")]
        public Customers GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());
            }
            return customer;
        }

        // POST: api/customers
        [HttpPost]
        public Customers CreateCustomer(Customers customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        //PUT: /api/customers/1
        [HttpPut("{id}")]
        public void UpdateCustomer(int id, Customers customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());
            }
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            
            if (customerInDb == null)
            {
                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());
            }

            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();
        }

        // Delete: /api/customers/1
        [HttpDelete("{id}")]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());
            }
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}