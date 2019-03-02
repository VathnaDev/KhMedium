using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KhMedium.Data;
using KhMedium.Entities;
using KhMedium.Models.ViewModel;
using Microsoft.AspNet.Identity;

namespace KhMedium.Controllers
{
    public class ArticleController : Controller
    {
        private readonly UnitOfWork _context = new UnitOfWork(new KhMediumEntities());

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
            Console.WriteLine(User.Identity.GetUserId());
            article.AuthorId = _context.Authors.GetAuthorByUserId(User.Identity.GetUserId()).Id;
            article.CreatedAt = DateTime.Now;
            article.UpdatedAt = DateTime.Now;

            var thumbnail = FileController.SaveFile(model.ArticlesImage);
            article.Thumbnail = thumbnail.Path;
            _context.Articles.Add(article);
            _context.Complete();

            return View("Index");
        }

    }
}