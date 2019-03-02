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
            var viewModel = new HomeViewModel();
            viewModel.TotalArticles = _context.Articles.GetAll().Count();
            viewModel.TotalAuthors = _context.Authors.GetAll().Count();
            viewModel.TotalPulications = _context.Publications.GetAll().Count();
            viewModel.TotalNewMember = 5;
            viewModel.PopularArticles = _context.Articles.GetPopularArticle();
            viewModel.Publications = _context.Publications.GetAll()
                .Where(d => d.DeletedAt == null)
                .OrderByDescending(c => c.CreatedAt).ToList();
            return View(viewModel);
        }
    }
}