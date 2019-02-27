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
    public class ProfileController : Controller
    {
        private readonly UnitOfWork _context = new UnitOfWork(new KhMediumEntities());


        public ActionResult Index(string userId, string authorId)
        {
//            var aspNetUser = _context.Authors.SingleOrDefault(a => a.)
//
//            var author = _context.Authors.Get();

//            var author = _context.Authors.GetAuthorByUserId(User.Identity.GetUserId());
            var author = userId != null ? _context.Authors.GetAuthorByUserId(User.Identity.GetUserId()) : _context.Authors.Get(authorId);
//            var author = _context.Authors.Get(authorId);
            var viewModel = new ProfileViewModel()
            {
                Author = author,
                Articles = _context.Authors.Get(author.Id).Articles.ToList()
            };

            return View(viewModel);
        }
    }
}