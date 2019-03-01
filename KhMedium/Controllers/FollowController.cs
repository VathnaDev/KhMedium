using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KhMedium.Data;
using KhMedium.Entities;

namespace KhMedium.Controllers
{
    public class FollowController : Controller
    {
        private UnitOfWork _context = new UnitOfWork(new KhMediumEntities());

    }

//    public enum FollowType
//    {
//        User,
//        Author,
//        Publication,
//        Topic
//    }
}