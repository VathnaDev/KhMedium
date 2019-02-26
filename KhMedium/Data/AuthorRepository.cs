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
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(DbContext context) : base(context)
        {
        }

        public KhMediumEntities KhMediumContext => Context as KhMediumEntities;

        public Author GetAuthorByUserId(string id)
        {
            return KhMediumContext.Authors.SingleOrDefault(a => a.UserId == id);
        }
    }
}