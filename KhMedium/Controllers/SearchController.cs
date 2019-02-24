using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KhMedium.Models.ViewModel;

namespace KhMedium.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(String q)
        {
            var model = new SearchViewModel();
            model.Query = q;
            model.Type = "stories";
            return View(model);
        }

        public ActionResult Users(String q)
        {
            var model = new SearchViewModel();
            model.Query = q;
            model.Type = "stories";
            return View(model);
        }

        public ActionResult Publications(String q)
        {
            var model = new SearchViewModel();
            model.Query = q;
            model.Type = "publication";
            return View(model);
        }
       
    }
}