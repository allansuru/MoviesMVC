using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult New()
        {
            var membershipType = _context.MembershipTypes.ToList();
            //aqui como temos um controller do Customer e temos q adicionar um combo com os membershipstypes, tive que criar uma viewmodel com as infos, boas praticas de solid
            var viewModel = new CustomerFormViewModel
            {
                MembershipType = membershipType // recebo a lista no meu ienumerable da minha viewmodel
            };

            
            
            return View("CustomerForm",viewModel);
        }


        [HttpPost]
      
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipType = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            if(customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                //TryUpdateModel(customerInDb); //abordagem ruim, porem, oficial da MS.


                //aqui entraria um automapper pra fazer isso com uma linha só 
                //Mapper.Map(customer, customerInDb);

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }
            _context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ViewResult Index()
        {
            //var customers = GetCustomers();

            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
         
        }
        public ActionResult Details(int id)
        {
            //var customers = GetCustomers().SingleOrDefault(c => c.Id == id);

            var customers = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
          

            if (customers == null)
                return HttpNotFound();

            return View(customers);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();


            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipType =_context.MembershipTypes.ToList()
            };


            return View("CustomerForm", viewModel);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    Id =1, Name = "Allan Passoso"
                },
                new Customer
                {
                    Id = 2, Name = "Kawana Okubo"
                },
                new Customer
                {
                    Id =3, Name = "Guilherme Okubo"
                }
            };
        }
    }
}