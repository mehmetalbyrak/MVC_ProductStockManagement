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

        public ActionResult DeleteCustomer(int id)
        {
            var customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCustomer(int id)
        {
            var customer = db.Customers.Find(id);
            return View("GetCustomer", customer);
        }

        public ActionResult UpdateCustomer(Customer customer)
        {
            var forUpdatingCustomer = db.Customers.Find(customer.CustomerId);
            forUpdatingCustomer.CustomerName = customer.CustomerName;
            forUpdatingCustomer.CustomerLastName = customer.CustomerLastName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}