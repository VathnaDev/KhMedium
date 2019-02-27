using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KhMedium.Entities;

namespace KhMedium.Models.ViewModel
{
    public class ProfileViewModel
    {
        public Author Author { get; set; }
        public List<Article> Articles { get; set; }
    }
}