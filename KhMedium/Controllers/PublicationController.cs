using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using KhMedium.Data;
using KhMedium.Entities;
using KhMedium.Models.ViewModel;

namespace KhMedium.Controllers
{
    public class PublicationController : Controller
    {
        private readonly UnitOfWork _context = new UnitOfWork(new KhMediumEntities());

        // GET
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreatePublicationViewModel model)
        {
            var publication = new Publication();
            publication.Id = Guid.NewGuid().ToString();
            publication.Name = model.Name;
            publication.Description = model.Description;
            publication.Logo = FileController.SaveFile(model.Logo).Path;
            publication.Cover = FileController.SaveFile(model.Cover).Path;
            publication.CreatedAt = DateTime.Now;
            publication.UpdatedAt = DateTime.Now;
            _context.Publications.Add(publication);
            _context.Complete();

            var author = _context.Authors.GetAll().FirstOrDefault();
            var authorPub = new AuthorPublication();
            authorPub.Id = Guid.NewGuid().ToString();
            authorPub.PublicationId = publication.Id;
            authorPub.AuthorId = author?.Id;
            _context.AuthorPublication.Add(authorPub);

            _context.Complete();
            return View();
        }
    }
}