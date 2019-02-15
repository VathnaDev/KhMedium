using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using KhMedium.Data;
using KhMedium.Entities;
using KhMedium.Models;

namespace KhMedium.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var unitOfWork = new UnitOfWork(new KhMediumEntities());
            ViewBag.Message = "Your application description page.";

            var context =new KhMediumEntities();
            var dbAuthor = context.Authors.Find("wwe");
            var author = Mapper.Map<Models.AuthorModel>(dbAuthor);
            return View(author);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}