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
    public class ArticleDetailController : Controller
    {
        private readonly UnitOfWork _context = new UnitOfWork(new KhMediumEntities());

        // GET: ArticleDetail
        public ActionResult Index(string id)
        {
            var viewModel = new ArticleDetailViewModel()
            {
                Article = _context.Articles.Get(id) ?? new Article()
            };

            System.Diagnostics.Debug.WriteLine("" + _context.Articles.Get(id));

            return View(viewModel);
        }
    }
}