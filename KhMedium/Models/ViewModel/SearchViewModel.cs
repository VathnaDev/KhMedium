using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KhMedium.Entities;

namespace KhMedium.Models.ViewModel
{
    public class SearchViewModel
    {
        public String Query { get; set; }
        public List<Author> Users { get; set; }
        public List<Publication> Publications { get; set; }
        public List<Article> Articles { get; set; }
        public String Type { get; set; }
    }
}