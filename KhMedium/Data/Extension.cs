﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using KhMedium.Entities;
using File = KhMedium.Entities.File;

namespace KhMedium.Data
{
    public static class Extension 
    {
        //Articles
        public static Boolean IsDeleted(this Article article)
        {
            return article.DeletedAt == null;
        }

        //File
        public static String FullPath(this File file)
        {
            return Path.Combine(HttpContext.Current.Server.MapPath("~/FileUpload/"), file.Path);
        }
    }
}