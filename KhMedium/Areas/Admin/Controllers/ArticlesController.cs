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
            var articles = _context.Articles.GetAll();

           return View(articles);
        }
        public ActionResult Create()
        {
            var ListTopic = _context.Topics.GetAll();
            var ListAuthor = _context.Topics.GetAll();

            ViewBag.ListTopics = new SelectList(ListTopic, "Id", "Name");

            ViewBag.ListAuthor = new SelectList(ListAuthor, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Article article)
        {
            if (!ModelState.IsValid)
            {
                return View(article);
            }

            article.Id = Guid.NewGuid().ToString();
            article.CreatedAt = DateTime.Now;
            _context.Articles.Add(article);
            _context.Complete();
            return RedirectToAction("Index");
        }
        public ActionResult Edits(String id)
        {
            var catergory = _context.Articles.Get(id);
            return View(catergory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edits(String id, Article article)
        {
            if (!ModelState.IsValid)
                return View(article);
            article.UpdatedAt = DateTime.Now;
            _context.Articles.Update(article);
            _context.Complete();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(String id)
        {
            var articles = _context.Articles.Get(id);
            _context.Articles.Remove(articles);
            _context.Complete();
            return RedirectToAction("Index");
        }
    }
}