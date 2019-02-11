using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KhMedium.Data;
using KhMedium.Data.Core;
using KhMedium.Entities;
using KhMedium.Models;
using Microsoft.AspNet.Identity;

namespace KhMedium.Controllers
{
    [Authorize]
    public class StartController : Controller
    {
        private readonly UnitOfWork _context = new UnitOfWork(new KhMediumEntities());

        // GET: Start
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectTopics()
        {
            var topics = _context.Topics.GetAll().ToList();
            return View(new SelectedTopicViewModel() {Topics = topics, SelectedTopics = new List<string>()});
        }

        [HttpPost]
        public ActionResult SelectTopics(SelectedTopicViewModel model)
        {
            foreach (var topic in model.SelectedTopics)
            {
                var userTopic = new UserTopic();
                userTopic.Id = Guid.NewGuid().ToString();
                userTopic.UserId = User.Identity.GetUserId();
                userTopic.TopicId = topic;
                _context.UserTopics.Add(userTopic);
            }
            _context.Complete();
            return RedirectToAction("Index", "Home");
        }
    }
}