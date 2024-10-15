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
        public ActionResult Index(string p)
        {

            var values = from value in db.Customers select value;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(c => c.CustomerName.Contains(p));
            }
            return View(values.ToList());
            //var values = db.Customers.ToList();
            //return View(values);
        }

        [HttpGet]
        public ActionResult NewCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCustomer");
            }
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