using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KhMedium.Data;
using KhMedium.Entities;

namespace KhMedium.Controllers
{
    public class FollowController : Controller
    {
        private UnitOfWork _context = new UnitOfWork(new KhMediumEntities());

        [HttpPost]
        public JsonResult Follow(String followerId, String followingId, FollowType type)
        {
            var following = new Following()
            {
                Id = Guid.NewGuid().ToString(),
                FollowingId = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                UserId = followerId
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
            return Json("Success");
        }
    }

    public enum FollowType
    {
        User,
        Author,
        Publication,
        Topic
    }
}