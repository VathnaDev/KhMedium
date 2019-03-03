using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KhMedium.Data;
using KhMedium.Entities;
using Microsoft.AspNet.Identity;

namespace KhMedium.Controllers
{
    public class InfomationController : Controller
    {
        [Authorize]
        public static Author GetLoginUser(String userId)
        {
            using (var context = new UnitOfWork(new KhMediumEntities()))
            {
                return context.Authors.GetAuthorByUserId(userId);
            }
        }
    }
}