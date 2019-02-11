using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KhMedium.Data.Core;
using KhMedium.Entities;

namespace KhMedium.Data
{
    public class FileRepository : Repository<File>, IFileRepository
    {
        public FileRepository(DbContext context) : base(context)
        {
        }
        public KhMediumEntities KhMediumContext => Context as KhMediumEntities;

    }
}