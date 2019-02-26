using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace KhMedium.Utils
{
    public class StringUtils
    {
        public static string GetFullImagePath(String path)
        {
            return Path.Combine(HttpContext.Current.Server.MapPath("~/FileUpload/"), path);
        }
    }
}