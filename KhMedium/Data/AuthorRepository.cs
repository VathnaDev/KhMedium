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

        public Models.AuthorModel GetAuthorWithCourses(String id)
        {
            return AutoMapper.Mapper.Map<Models.AuthorModel>(KhMediumContext.Authors.SingleOrDefault(a => a.Id == id));
        }
        
        public KhMediumEntities KhMediumContext => Context as KhMediumEntities;
    }
}