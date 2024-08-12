using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyMoshNet8.Data;
using VidlyMoshNet8.DTO;
using VidlyMoshNet8.Models;

namespace VidlyMoshNet8.Controllers.API
{
    [Route("api/customer")]
    [ApiController]
    public class CustomersController : Controller
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;

        public CustomersController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


         // GET: api/customers
        [HttpGet]
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(_mapper.Map<Customers, CustomerDTO>);
        }

        // GET: api/customers/1
        [HttpGet ("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());
            }
            return Ok(_mapper.Map<Customers, CustomerDTO>(customer));
        }

        // POST: api/customers
        [HttpPost]
        public IActionResult CreateCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = _mapper.Map<CustomerDTO, Customers>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(Request.Path.ToString()+"/"+customer.Id, customerDto);
        }

        //PUT: /api/customers/1
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, CustomerDTO customerDto)
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
            _mapper.Map(customerDto, customerInDb);
            _context.SaveChanges();
            //customerInDb.Name = customer.Name;
            //customerInDb.Birthdate = customer.Birthdate;
            //customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            //customerInDb.MembershipTypeId = customer.MembershipTypeId;

            return Accepted(Request.Path.ToString());
        }

        // Delete: /api/customers/1
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());
            }
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return NoContent();
        }
    }
}