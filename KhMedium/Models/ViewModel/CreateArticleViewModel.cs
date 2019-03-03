using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KhMedium.Entities;

namespace KhMedium.Models.ViewModel
{
    public class CreateArticleViewModel
    {
        public String Id { get; set; }
        public String Title { get; set; }
        [AllowHtml]
        public String Content { get; set; }
        public HttpPostedFileBase ArticlesImage { get; set; }
        public List<Topic> Topics { get; set; }
        public String TopicId { get; set; }
        public String ImageName { get; set; }
    }
}