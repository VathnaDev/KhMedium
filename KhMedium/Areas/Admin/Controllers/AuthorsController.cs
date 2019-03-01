using KhMedium.Data;
using KhMedium.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KhMedium.Areas.Admin.Models;
using KhMedium.Controllers;
using KhMedium.Models.ViewModel;
using KhMedium.Utils;

namespace KhMedium.Areas.Admin.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly UnitOfWork _context = new UnitOfWork(new KhMediumEntities());

        // GET: Admin/Authors
        public ActionResult Index()
        {
            var model = _context.Authors.GetAll().Where(a => a.DeletedAt == null);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            var account = new AccountController();
            account.RegisterNewUser(viewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Edits(String id)
        {
            var viewModel = new AuthorViewModel();
            var author = _context.Authors.Get(id);
            viewModel.AuthorId = id;
            viewModel.Name = author.Name;
            viewModel.Bio = author.Bio;
            viewModel.Email = author.AspNetUser.Email;
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edits(AuthorViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            var author = _context.Authors.Get(viewModel.AuthorId);
            author.Name = viewModel.Name;
            author.AspNetUser.Email = viewModel.Email;
            author.Bio = viewModel.Bio;
            author.UpdatedAt = DateTime.Now;
            _context.Authors.Update(author);
            _context.Complete();
            return RedirectToAction("Index");
        }

        public ActionResult Details(String id)
        {
            var author = _context.Authors.Get(id);
            return View(author);
        }

        public ActionResult Delete(String id)
        {
            var author = _context.Authors.Get(id);
            author.DeletedAt = DateTime.Now;
            _context.Complete();
            return RedirectToAction("Index");
        }

        public ActionResult UnFollow(String id,String authorId)
        {
            var following = _context.Followings.Get(id);
            _context.Followings.Remove(following);
            _context.Complete();
            return RedirectToAction("Details", new { id = authorId });
        }

        public ActionResult RemoveFollower(String id, String authorId)
        {
            var follower= _context.Followers.Get(id);
            _context.Followers.Remove(follower);
            _context.Complete();
            return RedirectToAction("Details", new { id = authorId });
        }
    }
}