using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KhMedium.Data;
using KhMedium.Entities;
using KhMedium.Models.ViewModel;

namespace KhMedium.Controllers
{
    public class ArticleController : Controller
    {
        private UnitOfWork _context = new UnitOfWork(new KhMediumEntities());

        // GET: Article
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Create()
        {
            var model = new CreateArticleViewModel
            {
                Topics = _context.Topics.GetAll().ToList()
            };


            return View(model);
        }

        [HttpPost]
        public ActionResult CreateArticle(CreateArticleViewModel model)
        {
            var file = Request.Files[0];
            //Foreign Keys are simulated for simplicity
            var article = new Article();
            article.Id = Guid.NewGuid().ToString();
            article.Title = model.Title;
            article.TopicId = model.TopicId;
            article.Content = model.Content;
            article.AuthorId = "wwe";
            article.CreatedAt = DateTime.Now;
            article.UpdatedAt = DateTime.Now;

            var thumnail = FileController.SaveFile(model.ArticlesImage);
            article.Thumbnail = thumnail.Path;
            _context.Articles.Add(article);
            _context.Complete();

            return View("Index");
        }

    }
}