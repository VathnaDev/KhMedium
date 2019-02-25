using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KhMedium.Models.ViewModel
{
    public class CreateArticleViewModel
    {
        public String Title { get; set; }
        public String Content { get; set; }
        public HttpPostedFileBase ArticlesImage { get; set; }
    }
}