using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KhMedium.Data.Core;
using KhMedium.Entities;
using KhMedium.Models;

namespace KhMedium.Data
{
    public class BookmarkRepository : Repository<Bookmark>, IBookmarkRepository
    {
        public BookmarkRepository(DbContext context) : base(context)
        {
        }

        public KhMediumEntities KhMediumContext => Context as KhMediumEntities;

        public List<Bookmark> GetUserBookmarks(string userId)
        {
            var user = KhMediumContext.AspNetUsers.SingleOrDefault(u => u.Id == userId);
            return user?.Bookmarks
                       .OrderByDescending(b => b.CreatedAt)
                       .ToList() ?? new List<Bookmark>();
        }
    }
}