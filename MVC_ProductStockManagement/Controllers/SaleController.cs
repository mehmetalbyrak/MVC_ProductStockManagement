using MVC_ProductStockManagement.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVC_ProductStockManagement.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        MVCStockDBEntities db = new MVCStockDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewSale()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewSale([Bind(Exclude = "SaleId")] Sale sale)
        {
            //db.Sales.Add(sale);
            //db.SaveChanges();
            //return View("Index");

            
            int maxId = db.Sales.Any() ? db.Sales.Max(s => s.SaleId) : 0;  
            sale.SaleId = maxId + 1;

            // Yeni satış kaydını ekle
            db.Sales.Add(sale);
            db.SaveChanges();

            
            return View("Index");
        }

    }
}