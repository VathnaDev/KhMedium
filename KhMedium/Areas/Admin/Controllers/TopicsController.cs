﻿using KhMedium.Data;
using KhMedium.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KhMedium.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TopicsController : Controller
    {
        private readonly UnitOfWork _context = new UnitOfWork(new KhMediumEntities());
        // GET: Admin/Topics
        public ActionResult Index()
        {
            var model = _context.Topics.GetAll().OrderBy(topic => topic.CreatedAt);
            return View(model);
        }
        public ActionResult Create()
        {
  
            //ViewBag.CategoryList = new SelectList(_context.Categories.GetAll(), "Id", "Name");
            var listData = _context.Categories.GetAll();
           
            ViewBag.List = new SelectList(listData, "Id", "Name");
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Topic model)
        {
            if (!ModelState.IsValid)
            {
                var listData = _context.Categories.GetAll();
                ViewBag.List = new SelectList(listData, "Id", "Name");
                return View(model);
            }

            model.Id = Guid.NewGuid().ToString();
            model.CreatedAt = DateTime.Now;

            _context.Topics.Add(model);
            _context.Complete();
            return RedirectToAction("Index");
        }
        public ActionResult Edits(String id)
        {
            var ListData = _context.Categories.GetAll();

            ViewBag.List = new SelectList(ListData, "Id", "Name");

            var topic = _context.Topics.Get(id);
            return View(topic);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edits(Topic topic)
        {
            if (!ModelState.IsValid)
            {
                var listData = _context.Categories.GetAll();
                ViewBag.List = new SelectList(listData, "Id", "Name");
                return View(topic);
            }
            topic.CreatedAt = DateTime.Now;
            _context.Topics.Update(topic);
            _context.Complete();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(String id)
        {
            var topic = _context.Topics.Get(id);
            _context.Topics.Remove(topic);
            _context.Complete();
            return RedirectToAction("Index");
        }
    }
}