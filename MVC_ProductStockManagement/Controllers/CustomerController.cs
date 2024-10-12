using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ProductStockManagement.Models.Entity;

namespace MVC_ProductStockManagement.Controllers
{
    public class CustomerController : Controller
    {
        MVCStockDBEntities db = new MVCStockDBEntities();
        // GET: Customer
        public ActionResult Index()
        {
            var values = db.Customers.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return View();
        }
    }
}