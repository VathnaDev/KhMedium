using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using KhMedium.Data;
using KhMedium.Entities;
using KhMedium.Models.ViewModel;
using Microsoft.AspNet.Identity;

namespace KhMedium.Controllers
{
    public class PublicationController : Controller
    {
        private readonly UnitOfWork _context = new UnitOfWork(new KhMediumEntities());

        [Authorize]
        public ActionResult Index()
        {
            var authorPublications = _context.Authors.GetAuthorByUserId(User.Identity.GetUserId()).AuthorPublications.ToList();

            var viewModel = new PublicationViewModel()
            {
                Publications = authorPublications
            };

            return View(viewModel);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
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