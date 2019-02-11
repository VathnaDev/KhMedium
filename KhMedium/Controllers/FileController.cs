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
        public JsonResult CreateFile(HttpPostedFileBase file, FileType type, String Id)
        {
            if (file == null) return Json("Invalid file");
            return Json(SaveFile(file, type, Id));
        }

        public static String SaveFile(HttpPostedFileBase file, FileType type, String Id)
        {
            UnitOfWork context = new UnitOfWork(new KhMediumEntities());
            if (file == null) return "Invalid file";
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
            return dbFile.FullPath();
        }
    }
}

public enum FileType
{
    Article,
    Publication,
    Topic
}