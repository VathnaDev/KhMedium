using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KhMedium.Data;
using KhMedium.Entities;
using KhMedium.Models.ViewModel;
using Microsoft.AspNet.Identity;

namespace KhMedium.Controllers
{
    public class BookmarkController : Controller
    {
        private readonly UnitOfWork _context = new UnitOfWork(new KhMediumEntities());

        // GET: Bookmark
        public ActionResult Index()
        {

            var bookmarks = _context.Bookmarks.GetUserBookmarks(User.Identity.GetUserId());
            var articles = new List<Article>();

            foreach (var bookmark in bookmarks)
            {
                articles.Add(_context.Articles.Get(bookmark.ArticleId));
            }

            var viewModel = new BookmarkViewModel()
            {
                Bookmarks = bookmarks,
                Articles = articles
            };

            return View(viewModel);
        }
    }
}