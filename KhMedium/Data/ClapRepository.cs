using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KhMedium.Data.Core;
using KhMedium.Models;

namespace KhMedium.Data
{
    public class ClapRepository : Repository<ClapModel>, IClapRepository
    {
        public ClapRepository(DbContext context) : base(context)
        {
        }
    }
}