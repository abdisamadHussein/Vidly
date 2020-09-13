using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        
        public ActionResult Index()
        {
          
            
            return View();
        }

        public ActionResult NewCustomer()
        {
            var membershipType = _context.MembershipTypes.ToList();
            var ViewModel = new CustomerFormView
            {
                customer = new Customer(),
                MembershipTypes = membershipType
                
            };

            return View("CustomerForm", ViewModel);

        }

        [HttpPost]
        public ActionResult Update(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var ViewModel = new CustomerFormView
                {
                    MembershipTypes = _context.MembershipTypes.ToList(),
                    customer = customer

                };

                return View("CustomerForm", ViewModel);
            }    
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerDb.Name = customer.Name;
                customerDb.BirthDate = customer.BirthDate;
                customerDb.IsSubscribed = customer.IsSubscribed;
                customerDb.MembershipTypeId = customer.MembershipTypeId;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                Console.WriteLine(e);
            }
          
            return RedirectToAction("Index", "Customers");
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Single(c => c.Id == id);
            var memberShipType = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormView
            {
                customer = customer,
                MembershipTypes = memberShipType
            };
            return View("CustomerForm", viewModel);

        }



    }

}