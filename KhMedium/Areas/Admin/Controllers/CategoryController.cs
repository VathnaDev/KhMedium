using KhMedium.Data;
using KhMedium.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KhMedium.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly UnitOfWork _context = new UnitOfWork(new KhMediumEntities());

        // GET: Admin/Category
        public ActionResult Index()
        {
            var categories = _context.Categories.GetAll();
            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category model)
        {
           
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Id = Guid.NewGuid().ToString();
            model.CreatedAt = DateTime.Now;
            _context.Categories.Add(model);
            _context.Complete();
            return RedirectToAction("Index");
        }
        public ActionResult Edits(String id)
        {
            var catergory = _context.Categories.Get(id);
            return View(catergory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edits(String id, Category category)
        {
            if (!ModelState.IsValid)
                return View(category);
            category.CreatedAt = DateTime.Now;
            _context.Categories.Update(category);
            _context.Complete();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(String id)
        {
            var category = _context.Categories.Get(id);
            _context.Categories.Remove(category);
            _context.Complete();
            return RedirectToAction("Index");
        }
    }
}