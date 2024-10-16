﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ProductStockManagement.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVC_ProductStockManagement.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        MVCStockDBEntities db = new MVCStockDBEntities();
        public ActionResult Index(int page = 1)
        {
            // var values = db.Categories.ToList();
            var values = db.Categories.ToList().ToPagedList(page, 4);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCategory(Category category) // ekleme yaparken bunu yap
        {
            if (!ModelState.IsValid)
            {
                return View("NewCategory");
            }
            db.Categories.Add(category);
            db.SaveChanges();
            return View();
        }


        public ActionResult DeleteCategory(int id)
        {
            var category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCategory(int id)
        {
            var category = db.Categories.Find(id);
            return View("GetCategory", category);
        }

        public ActionResult UpdateCategory(Category category)
        {
            var forUpdateCategory = db.Categories.Find(category.CategoryId);
            forUpdateCategory.CategoryName = category.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

