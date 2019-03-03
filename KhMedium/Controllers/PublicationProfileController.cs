using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KhMedium.Data;
using KhMedium.Entities;
using KhMedium.Models.ViewModel;

namespace KhMedium.Controllers
{
    public class PublicationProfileController : Controller
    {
        private readonly UnitOfWork _context = new UnitOfWork(new KhMediumEntities());

        // GET: PublicationProfile
        public ActionResult Index(string publicationId)
        {

            var pub = _context.Publications.Get(publicationId);
            var articles = new List<Article>();
            foreach (var auth in pub.AuthorPublications)
            {
                articles.AddRange(auth.Author.Articles);
            }

            var viewModel = new PublicationProfileViewModel()
            {
                Publication = _context.Publications.Get(publicationId),
                Articles = articles

            };
        

            return View(viewModel);
        }
    }
}