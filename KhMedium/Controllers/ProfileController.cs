using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KhMedium.Data;
using KhMedium.Entities;

namespace KhMedium.Controllers
{
    public class ProfileController : Controller
    {
        UnitOfWork _context = new UnitOfWork(new KhMediumEntities());

        public ActionResult Index()
        {
//            var aspNetUser = _context.Authors.SingleOrDefault(a => a.)
//
//            var author = _context.Authors.Get();


            return View();
        }
    }
}