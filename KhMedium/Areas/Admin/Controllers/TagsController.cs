using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KhMedium.Data;
using KhMedium.Entities;

namespace KhMedium.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TagsController : Controller
    {
        private readonly UnitOfWork _context = new UnitOfWork(new KhMediumEntities());

        // GET: Admin/Tags
        public ActionResult Index()
        {
            var tags = _context.Tags.GetAll().OrderBy(t => t.Name);
            return View(tags);
        }

        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Tag tag)
        {
            tag.Id = Guid.NewGuid().ToString();
            tag.CreatedAt = DateTime.Now;

            if (!ModelState.IsValid)
                return View(tag);

            _context.Tags.Add(tag);
            _context.Complete();
            return RedirectToAction("Index");
        }

        public ActionResult Edits(String id)
        {
            var tag = _context.Tags.Get(id);
            if (tag == null)
                return View("Error");
            return View(tag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edits(String id, Tag tag)
        {
            if (!ModelState.IsValid)
                return View(tag);
            tag.CreatedAt = DateTime.Now;

            _context.Tags.Update(tag);
            _context.Complete();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(String id)
        {
            var tag = _context.Tags.Get(id);
            _context.Tags.Remove(tag);
            _context.Complete();
            return RedirectToAction("Index");
        }

        public ActionResult Test()
        {
            var articles = _context.Articles.GetAll().ToList();
            return View("Index");
        }
    }
}