using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KhMedium.Data.Core
{
    public interface IUnitOfWork : IDisposable
    {
//        ICourseRepository Courses { get; }
        IAuthorRepository Authors { get; }
        int Complete();
    }
}