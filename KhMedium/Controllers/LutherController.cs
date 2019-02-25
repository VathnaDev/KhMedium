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
    public class LutherController : Controller
    {
        private readonly UnitOfWork _context = new UnitOfWork(new KhMediumEntities());

        // GET: Luther
        public ActionResult CreateArticlesDemo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateArticlesDemo(CreateArticleViewModel model, HttpPostedFileBase ArticlesImage)
        {
            var file = Request.Files[0];
            //Foreign Keys are simulated for simplicity
            var article = new Article();
            article.Id = Guid.NewGuid().ToString();
            article.Title = model.Title;
            article.TopicId = "6b92ef38-f1b0-4911-8199-eeeadeb25bef";
            article.Content = model.Content;
            article.AuthorId = "wwe";
            article.CreatedAt = DateTime.Now;
            article.UpdatedAt = DateTime.Now;

            var thumnail = FileController.SaveFile(model.ArticlesImage);
            article.Thumbnail = thumnail.FullPath();
            _context.Articles.Add(article);
            _context.Complete();

            return View();
        }

        [HttpPost]
        public JsonResult AddBookMark(String articleId)
        {
            var bookmark = new Bookmark()
            {
                Id = Guid.NewGuid().ToString(),
                ArticleId = articleId,
                UserId = User.Identity.GetUserId(),
                CreatedAt = DateTime.Now
            };
            _context.Bookmarks.Add(bookmark);
            _context.Complete();
            return Json(bookmark);
        }

        [HttpPost]
        public JsonResult RemoveBookMark(String bookmarkId)
        {
            var bookmark = _context.Bookmarks.SingleOrDefault(b => b.Id == bookmarkId);
            if (bookmark == null)
                return Json(new { result = "Bookmark not found!" });
            _context.Bookmarks.Remove(bookmark);
            _context.Complete();
            return Json(new {result = "successS"});
        }


    }
}