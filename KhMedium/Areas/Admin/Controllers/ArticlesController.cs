using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KhMedium.Entities;
using System.Web.Mvc;
using KhMedium.Data;

namespace KhMedium.Areas.Admin.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly UnitOfWork _context = new UnitOfWork(new KhMediumEntities());

        
        // GET: Admin/Articles
        public ActionResult Index()
        {
            var model = _context.Articles.GetAll();

           return View(model);
        }
        public ActionResult Create()
        {
            var ListTopic = _context.Topics.GetAll();
            var ListAuthor = _context.Topics.GetAll();

            ViewBag.ListTopics = new SelectList(ListTopic, "Id", "Name");

            ViewBag.ListAuthor = new SelectList(ListAuthor, "Id", "Name");
            return View();
        }
    }
}