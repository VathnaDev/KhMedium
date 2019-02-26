using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KhMedium.Areas.Admin.Models
{
    public class BookmarkViewModel
    {
        public String Id { get; set; }
        [Required]
        public String AuthorId { get; set; }

        [Required]
        public String ArticleId { get; set; }

        public SelectList Authors { get; set; }
        public SelectList Articles { get; set; }
    }
}