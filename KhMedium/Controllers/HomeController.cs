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
using KhMedium.Models.ViewModel;
using Microsoft.AspNet.Identity;

namespace KhMedium.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork _context = new UnitOfWork(new KhMediumEntities());

        public ActionResult Index()
        {
            string uid = "";

            if (User.Identity.IsAuthenticated)
            {
                uid = User.Identity.GetUserId();
            } 
            var viewModel = new HomeViewModel()
            {
                Topics = _context.Topics.GetAll().ToList(),
                FeatureArticles = _context.Articles.GetFeatureArticle(uid),
                BasedHistoryArticles = _context.Articles.GetFeatureArticle(uid),
                PopularArticles = _context.Articles.GetPopularArticle(uid)
            };

            return View(viewModel);
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}