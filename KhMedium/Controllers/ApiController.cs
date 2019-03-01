﻿using System;
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
        public JsonResult FollowUser(string followingId, FollowType type)
        {
            var following = new Following()
            {
                Id = Guid.NewGuid().ToString(),
                FollowingId = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                UserId = User.Identity.GetUserId()
            };
            var follower = new Follower()
            {
                Id = Guid.NewGuid().ToString(),
                FollowerId = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now
            };

            switch (type)
            {
                case FollowType.Author:
                    follower.AuthorId = followingId;
                    break;
                case FollowType.Publication:
                    follower.PublicationId = followingId;
                    break;
                case FollowType.Topic:
                    follower.TopicId = followingId;
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

        public enum FollowType
        {
            Author,
            Publication,
            Topic
        }
    }
}