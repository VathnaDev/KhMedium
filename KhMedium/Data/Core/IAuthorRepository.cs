using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KhMedium.Models;

namespace KhMedium.Data.Core
{
    public interface IAuthorRepository : IRepository<AuthorModel>
    {
        AuthorModel GetAuthorWithCourses(String id);
    }
}