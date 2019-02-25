using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KhMedium.Data;
using KhMedium.Entities;
using Microsoft.AspNet.Identity;
using File = KhMedium.Entities.File;

namespace KhMedium.Controllers
{
    public class FileController : Controller
    {
        private readonly UnitOfWork _context = new UnitOfWork(new KhMediumEntities());

        // GET: File
        [HttpPost]
        public JsonResult CreateFile(HttpPostedFileBase file)
        {
            if (file == null) return Json("Invalid file");
            return Json(SaveFile(file).FullPath());
        }

        public static File SaveFile(HttpPostedFileBase file)
        {
            UnitOfWork context = new UnitOfWork(new KhMediumEntities());
            if (file == null) return null;
            var fileName = Path.GetFileName(file.FileName);
            var extension = Path.GetExtension(fileName);
            var fileNamePath = Guid.NewGuid() + extension;
            var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/FileUpload/"), fileNamePath);
            file.SaveAs(path);

            var dbFile = new File()
            {
                Id = Guid.NewGuid().ToString(),
                Path = fileNamePath,
                CreatedAt = DateTime.Now,
                UserId = System.Web.HttpContext.Current.User.Identity.GetUserId()
            };
            context.Files.Add(dbFile);
            context.Complete();
            return dbFile;
        }

        public static void DeleteFile(String fileId)
        {

            UnitOfWork context = new UnitOfWork(new KhMediumEntities());
            var file = context.Files.SingleOrDefault(f => f.Id == fileId);
            context.Files.Remove(file);
            context.Complete();
        }
    }
}