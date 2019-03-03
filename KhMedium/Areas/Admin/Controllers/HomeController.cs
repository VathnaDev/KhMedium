using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KhMedium.Areas.Admin.Models;
using KhMedium.Data;
using KhMedium.Entities;

namespace KhMedium.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly UnitOfWork _context = new UnitOfWork(new KhMediumEntities());

        // GET: admin/Home
        public ActionResult Index()
        {
            var articles = _context.Articles.GetAll().Where(a => a.DeletedAt == null);
            var authors = _context.Authors.GetAll().Where(a => a.DeletedAt == null);
            var publications = _context.Publications.GetAll()
                .Where(d => d.DeletedAt == null)
                .OrderByDescending(c => c.CreatedAt).ToList();

            var viewModel = new HomeViewModel();
            viewModel.TotalArticles = articles.Count();
            viewModel.TotalAuthors = authors.Count();
            viewModel.TotalPulications = publications.Count();
            viewModel.TotalNewMember = 5;
            viewModel.PopularArticles = _context.Articles.GetPopularArticle().Where(a => a.DeletedAt == null).Take(10)
                .ToList();
            viewModel.Publications = publications.Take(10).ToList();
            return View(viewModel);
        }
    }
}