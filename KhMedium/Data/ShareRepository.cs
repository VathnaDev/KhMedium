using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KhMedium.Data.Core;
using KhMedium.Models;

namespace KhMedium.Data
{
    public class ShareRepository : Repository<ShareModel> , IShareRepository
    {
        public ShareRepository(DbContext context) : base(context)
        {
        }
    }
}