using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers

        [Route("Customers")]
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith"},
                new Customer { Id = 2, Name = "Will Rogers" }
            };

            return View(new CustomersViewModel { Customers = customers});
        }

        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            return Content("Customer id = " + id);
        }
    }
}