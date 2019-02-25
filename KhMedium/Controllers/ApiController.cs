using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KhMedium.Data;
using KhMedium.Entities;
using Microsoft.AspNet.Identity;

namespace KhMedium.Controllers
{
    public class ApiController : Controller
    {
        private readonly UnitOfWork _context = new UnitOfWork(new KhMediumEntities());

        // GET: Api
        [HttpPost]
        [Authorize]
        public JsonResult ToggleBookmark(string articleId)
        {
            var article = _context.Articles.SingleOrDefault(a => a.Id == articleId);
            var userId = User.Identity.GetUserId();
            if (article.IsBookmarked())
            {
                var bm = _context.Bookmarks.SingleOrDefault(
                    b => b.ArticleId == articleId &&
                         b.UserId == userId
                );
                _context.Bookmarks.Remove(bm);
                _context.Complete();
                return Json(new
                {
                    result = true
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var bm = new Bookmark()
                {
                    Id = Guid.NewGuid().ToString(),
                    ArticleId = articleId,
                    CreatedAt = DateTime.Now,
                    UserId = userId
                };
                _context.Bookmarks.Add(bm);
                _context.Complete();
                return Json(new
                {
                    result = false
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}