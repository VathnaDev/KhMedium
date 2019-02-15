using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KhMedium.Data.Core;
using KhMedium.Models;

namespace KhMedium.Data
{
    public class TagRepository : Repository<TagModel>, ITagRepository
    {
        public TagRepository(DbContext context) : base(context)
        {
        }
    }
}