using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ProductStockManagement.Models.Entity;

namespace MVC_ProductStockManagement.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        MVCStockDBEntities db = new MVCStockDBEntities();
        public ActionResult Index()
        {
            var values = db.Categories.ToList();
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
    }
}