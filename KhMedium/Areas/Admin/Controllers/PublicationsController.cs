using KhMedium.Controllers;
using KhMedium.Data;
using KhMedium.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KhMedium.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PublicationsController : Controller
    {
        private readonly UnitOfWork _context = new UnitOfWork(new KhMediumEntities());

        // GET: Admin/Publications
        public ActionResult Index()
        {
            var model = _context.Publications.GetAll()
                .Where(p => p.DeletedAt == null);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Publication publication, HttpPostedFileBase cover, HttpPostedFileBase avatar)
        {
            publication.Id = Guid.NewGuid().ToString();
            publication.CreatedAt = DateTime.Now;
            publication.UpdatedAt = DateTime.Now;
            publication.Cover = FileController.SaveFile(avatar).Path;
            publication.Logo = FileController.SaveFile(cover).Path;
            _context.Publications.Add(publication);
            _context.Complete();
            return RedirectToAction("Index");
        }

        public ActionResult Edits(String id)
        {
            var publication = _context.Publications.Get(id);
            return View(publication);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edits(String id, Publication publication, HttpPostedFileBase cv,
            HttpPostedFileBase avatar)
        {
            if (!ModelState.IsValid)
                return View(publication);
            publication.UpdatedAt = DateTime.Now;
            if (cv != null)
                publication.Cover = FileController.SaveFile(cv).Path;
            if (avatar != null)
                publication.Logo = FileController.SaveFile(avatar).Path;
            _context.Publications.Update(publication);
            _context.Complete();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(String id)
        {
            var publication = _context.Publications.Get(id);
            publication.DeletedAt = DateTime.Now;
            _context.Publications.Update(publication);
            _context.Complete();
            return RedirectToAction("Index");
        }
    }
}