using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace KhMedium.Areas.Admin.Controllers
{
    public class TestingController : Controller
    {
        // GET: Admin/Testing
        public ActionResult Index()
        {
            var currrentUserId = User.Identity.GetUserId();
            return View();
        }



    }
}