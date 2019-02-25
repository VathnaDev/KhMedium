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
    public class PublicationsController : Controller
    {
        private readonly UnitOfWork _context = new UnitOfWork(new KhMediumEntities());
        // GET: Admin/Publications
        public ActionResult Index()
        {
            var model = _context.Publications.GetAll();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Publication publication , HttpPostedFileBase cover,HttpPostedFileBase avatar)
        {
            publication.Id = Guid.NewGuid().ToString();
            publication.ContactInfo = "sldfkdlds";
            publication.CreatedAt = DateTime.Now;
            publication.UpdatedAt = DateTime.Now;
            _context.Publications.Add(publication);

            publication.Avatar = FileController.SaveFile(avatar);
            publication.Logo = FileController.SaveFile(cover, FileType.Publication, publication.Id);
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
        public ActionResult Edits(String id, Publication publication)
        {
            if (!ModelState.IsValid)
                return View(publication);
            publication.UpdatedAt = DateTime.Now;

            _context.Publications.Update(publication);
            _context.Complete();
            return RedirectToAction("Index");
            
        }
        public ActionResult Delete(String id)
        {
            var publication = _context.Publications.Get(id);
            _context.Publications.Remove(publication);
            _context.Complete();
            return RedirectToAction("Index");
        }
    }
}