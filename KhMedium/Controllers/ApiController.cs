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

        [HttpPost]
        [Authorize]
        public JsonResult Follow(string followingId, FollowType type)
        {
            var following = new Following()
            {
                Id = Guid.NewGuid().ToString(),
                FollowingId = followingId,
                UserId = User.Identity.GetUserId(),
                CreatedAt = DateTime.Now,
            };

            var follower = new Follower()
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now
            };

            switch (type)
            {
                case FollowType.Author:
                    following.AuthorId = followingId;
                    var author = _context.Authors.Get(followingId);
                    follower.UserId = author.AspNetUser.Id;
                    follower.FollowerId = author.Id;
                    break;
                case FollowType.Publication:
                    following.PublicationId = followingId;
                    break;
                case FollowType.Topic:
                    following.TopicId = followingId;
                    break;
            }
            _context.Followers.Add(follower);
            _context.Followings.Add(following);
            _context.Complete();
            return Json(new
            {
                result = true
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"> Id is the publication or user or topic id</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public JsonResult UnFollow(String id)
        {
            var currentUserId = User.Identity.GetUserId();
            var following = _context.Followings.SingleOrDefault(f => f.UserId == currentUserId && f.FollowingId == id);
            var follower = _context.Followers.SingleOrDefault(f => f.UserId == id && f.FollowerId == currentUserId);
            _context.Followers.Remove(follower);
            _context.Followings.Remove(following);
            _context.Complete();
            return Json(new
            {
                result = true
            }, JsonRequestBehavior.AllowGet);
        }

        public enum FollowType
        {
            Author,
            Publication,
            Topic
        }
    }
}