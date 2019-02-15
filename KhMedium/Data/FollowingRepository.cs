using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KhMedium.Data.Core;
using KhMedium.Models;

namespace KhMedium.Data
{
    public class FollowingRepository : Repository<FollowingModel>, IFollowingRepository
    {
        public FollowingRepository(DbContext context) : base(context)
        {
        }
    }
}