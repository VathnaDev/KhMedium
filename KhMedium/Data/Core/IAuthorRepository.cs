using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KhMedium.Entities;
using KhMedium.Models;

namespace KhMedium.Data.Core
{
    public interface IAuthorRepository : IRepository<Author>
    {
        AuthorModel GetAuthorWithCourses(String id);

        AuthorModel GetAuthorByAspUserId(string id);
    }
}