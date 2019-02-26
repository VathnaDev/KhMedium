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
    public class TopicsController : Controller
    {
        readonly UnitOfWork _context = new UnitOfWork(new KhMediumEntities());

        // GET: Topics
        public ActionResult Index(string topicId)
        {
            var viewModel = new TopicArticlesViewModel()
            {
                LatestArticles = _context.Articles.GetArticlesByTopic(topicId),
                FeatureArticle = _context.Articles.GetArticlesByTopic(topicId).FirstOrDefault() ?? new Article(),
                PopularArticles = _context.Articles.GetArticlesByTopic(topicId),
                RelatedTopics = new List<string>(),
                Topic = _context.Topics.Get(topicId)
            };
        

            return View(viewModel);
        }
    }
}