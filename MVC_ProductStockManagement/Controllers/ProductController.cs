﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ProductStockManagement.Models.Entity;


namespace MVC_ProductStockManagement.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        MVCStockDBEntities db = new MVCStockDBEntities();
        public ActionResult Index()
        {
            var values = db.Products.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewProduct()
        {
            List<SelectListItem> values = (from i in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CategoryName,
                                               Value = i.CategoryId.ToString(),

                                           }).ToList();
            ViewBag.productValue = values;
            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(Product product)
        {
            var category = db.Categories.Where(m => m.CategoryId == product.Category.CategoryId).FirstOrDefault();
            product.Category = category;

            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}