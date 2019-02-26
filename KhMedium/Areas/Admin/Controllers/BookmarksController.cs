using KhMedium.Data;
using KhMedium.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KhMedium.Areas.Admin.Models;

namespace KhMedium.Areas.Admin.Controllers
{
    public class BookmarksController : Controller
    {
        private readonly KhMediumEntities _entities = new KhMediumEntities();
        private readonly UnitOfWork _context = new UnitOfWork(new KhMediumEntities());

        // GET: Admin/Bookmarks
        public ActionResult Index()
        {
            var bookmarks = _context.Bookmarks.GetAll().OrderBy(topic => topic.CreatedAt);
            return View(bookmarks);
        }

        public ActionResult Create()
        {
            var listArticles = _context.Articles.GetAll();
            var listUsers = _entities.AspNetUsers.ToList();
            var viewModel = new BookmarkViewModel
            {
                Authors = new SelectList(listUsers, "Id", "UserName"),
                Articles = new SelectList(listArticles, "Id", "Title")
            };

            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(BookmarkViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var bookmark = new Bookmark
            {
                Id = Guid.NewGuid().ToString(),
                UserId = viewModel.AuthorId,
                ArticleId = viewModel.ArticleId,
                CreatedAt = DateTime.Now
            };
            _context.Bookmarks.Add(bookmark);
            _context.Complete();
            return RedirectToAction("Index");
        }

        public ActionResult Edits(String id)
        {
            var bookmark = _context.Bookmarks.Get(id);
            var listArticles = _context.Articles.GetAll();
            var listUsers = _entities.AspNetUsers.ToList();
            var viewModel = new BookmarkViewModel
            {
                Authors = new SelectList(listUsers, "Id", "UserName"),
                Articles = new SelectList(listArticles, "Id", "Title"),
                ArticleId = bookmark.ArticleId,
                AuthorId = bookmark.UserId
            };

            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edits(BookmarkViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            var bookmark = _context.Bookmarks.Get(viewModel.Id);
            bookmark.ArticleId = viewModel.ArticleId;
            bookmark.UserId = viewModel.AuthorId;
            _context.Bookmarks.Update(bookmark);
            _context.Complete();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(String id)
        {
            var bm = _context.Bookmarks.Get(id);
            _context.Bookmarks.Remove(bm);
            _context.Complete();
            return RedirectToAction("Index");
        }
    }
}