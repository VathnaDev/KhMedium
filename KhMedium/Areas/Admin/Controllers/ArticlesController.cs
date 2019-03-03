using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KhMedium.Entities;
using System.Web.Mvc;
using KhMedium.Controllers;
using KhMedium.Data;
using KhMedium.Models.ViewModel;
using Microsoft.AspNet.Identity;

namespace KhMedium.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ArticlesController : Controller
    {
        private readonly UnitOfWork _context = new UnitOfWork(new KhMediumEntities());


        // GET: Admin/Articles
        public ActionResult Index()
        {
            var articles = _context.Articles.GetAll()
                .Where(d => d.DeletedAt == null);
            return View(articles);
        }

        public ActionResult Create()
        {
            var model = new CreateArticleViewModel
            {
                Topics = _context.Topics.GetAll().ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateArticleViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var userId = User.Identity.GetUserId();
            var author = _context.Authors.GetAuthorByUserId(userId);
            var article = new Article();
            article.Id = Guid.NewGuid().ToString();
            article.Title = model.Title;
            article.TopicId = model.TopicId;
            article.Content = model.Content;
            article.AuthorId = author.Id;
            article.CreatedAt = DateTime.Now;
            article.UpdatedAt = DateTime.Now;

            var thumnail = FileController.SaveFile(model.ArticlesImage);
            article.Thumbnail = thumnail.Path;
            _context.Articles.Add(article);
            _context.Complete();
            return RedirectToAction("Index");
        }

        public ActionResult Edits(String id)
        {
            var article = _context.Articles.Get(id);
            var model = new CreateArticleViewModel
            {
                Id =  article.Id,
                Title = article.Title,
                Content = article.Content,
                TopicId = article.TopicId,
                ImageName = article.Thumbnail,
                Topics = _context.Topics.GetAll().ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edits(String id, CreateArticleViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            var article = _context.Articles.Get(viewModel.Id);
            article.Title = viewModel.Title;
            article.Content = viewModel.Content;
            article.TopicId = viewModel.TopicId;
            article.UpdatedAt = DateTime.Now;
            if(viewModel.ArticlesImage != null)
                article.Thumbnail = FileController.SaveFile(viewModel.ArticlesImage).Path;
            _context.Articles.Update(article);
            _context.Complete();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(String id)
        {
            var articles = _context.Articles.Get(id);
            articles.DeletedAt = DateTime.Now;
            _context.Complete();
            return RedirectToAction("Index");
        }
    }
}