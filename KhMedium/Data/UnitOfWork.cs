using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KhMedium.Data.Core;
using KhMedium.Entities;

namespace KhMedium.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KhMediumEntities _context;

        public UnitOfWork(KhMediumEntities context)
        {
            _context = context;
//            Courses = new CourseRepository(_context);
            Authors = new AuthorRepository(_context);
        }

//        public ICourseRepository Courses { get; private set; }
        public IAuthorRepository Authors { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}