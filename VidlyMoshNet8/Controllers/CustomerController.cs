﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyMoshNet8.Data;
using VidlyMoshNet8.Models;
using VidlyMoshNet8.ViewModel;

namespace VidlyMoshNet8.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [Authorize]
        [Route("customer/new")]
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customers = new Customers(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }
        
        
        //Estructura general de un metodo POST o Api
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("customer/save")]
        public ActionResult Save( Customers customers)
        {

            var errorCheck = false;
            var errorsList = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToList();

            if (errorsList.Count <= 1 && errorsList.Any(x => x.Key == "customers.MembershipType"))
                errorCheck = true;
            // customer.MembershipType is always null, bypass here
            if (!ModelState.IsValid && !errorCheck)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customers = customers,
                    MembershipTypes = _context.MembershipType.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if (customers.Id == 0)
            {
               customers.DateSubscribed = DateTime.Now; // 3  Descomentar para que se actualice la fecha de suscripcion
                _context.Customers.Add(customers);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customers.Id);
                //Mapper.Map(customer, customerInDb);

                customerInDb.Name = customers.Name;
                customerInDb.Birthdate = customers.Birthdate;
                customerInDb.MembershipTypeId = customers.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customers.IsSubscribedToNewsLetter;
                customerInDb.DateSubscribed = customers.DateSubscribed; //6 Descomentar para que se actualice la fecha de suscripcion
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        [Authorize]
        public ViewResult Index()
        {
            return View();
        }

        [Route("customer/{id}")]
        [Authorize]
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.
                Include(c => c.MembershipType).
                SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return new NotFoundResult();

            return View(customer);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return new NotFoundResult();

            var viewModel = new CustomerFormViewModel
            {
                Customers = customer,
                MembershipTypes = _context.MembershipType.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}
