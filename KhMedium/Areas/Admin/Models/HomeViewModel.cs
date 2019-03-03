using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;
using KhMedium.Entities;

namespace KhMedium.Areas.Admin.Models
{
    public class HomeViewModel
    {
        public int TotalArticles { get; set; }
        public int TotalAuthors { get; set; }
        public int TotalNewMember { get; set; }
        public int TotalPulications { get; set; }
        public List<Article> PopularArticles { get; set; }
        public List<Publication> Publications { get; set; }
    }
}