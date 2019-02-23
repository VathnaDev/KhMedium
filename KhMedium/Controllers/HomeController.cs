using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using KhMedium.Data;
using KhMedium.Entities;
using KhMedium.Models;
using KhMedium.Models.ViewModel;
using Microsoft.AspNet.Identity;

namespace KhMedium.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork _context = new UnitOfWork(new KhMediumEntities());

        public ActionResult Index()
        {
            string uid = "";

            var allArticles = _context.Articles.GetAll().OrderBy(a => a.CreatedAt).Take(10).ToList();

            if (User.Identity.IsAuthenticated)
            {
                uid = User.Identity.GetUserId();
            } 
            var viewModel = new HomeViewModel()
            {
                Topics = _context.Topics.GetAll().ToList(),
                FeatureArticles = _context.Articles.GetFeatureArticle(uid),
                BasedHistoryArticles = _context.Articles.GetFeatureArticle(uid),
                PopularArticles = _context.Articles.GetPopularArticle(uid).Take(4).ToList(),
                AllStoriesArticles = allArticles
                
            };

            return View(viewModel);
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpPost]
        [Authorize]
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
        [Authorize]
        public JsonResult RemoveBookMark(String bookmarkId)
        {
            var bookmark = _context.Bookmarks.SingleOrDefault(b => b.Id == bookmarkId);
            if (bookmark == null)
                return Json(new { result = "Bookmark not found!" });
            _context.Bookmarks.Remove(bookmark);
            _context.Complete();
            return Json(new { result = "successS" });
        }
    }
}