﻿using KhMedium.Data;
using KhMedium.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KhMedium.Areas.Admin.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly UnitOfWork _context = new UnitOfWork(new KhMediumEntities());
        // GET: Admin/Authors
        public ActionResult Index()
        {
            var model = _context.Authors.GetAll();
            if(model == null)
            {
                return View("No Data");
            }
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(String author)
        {
           
          
            if (!ModelState.IsValid)
                return View(author);
            author.Id = Guid.NewGuid().ToString();
            author.CreatedAt = DateTime.Now;
            author.UpdatedAt = DateTime.Now;
            _context.Publications.Add(author);
            _context.Complete();
            return RedirectToAction("Index");
        }
        public ActionResult Edits(String id)
        {
            var publication = _context.Publications.Get(id);
            return View(publication);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edits(String id, Publication publication)
        {
            if (!ModelState.IsValid)
                return View(publication);
            publication.UpdatedAt = DateTime.Now;

            _context.Publications.Update(publication);
            _context.Complete();
            return RedirectToAction("Index");

        }
        public ActionResult Delete(String id)
        {
            var publication = _context.Publications.Get(id);
            _context.Publications.Remove(publication);
            _context.Complete();
            return RedirectToAction("Index");
        }
    }
}