using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KhMedium.Entities;

namespace KhMedium.Models.ViewModel
{
    public class PublicationProfileViewModel
    {
        public Publication Publication { get; set; }
        public List<Article> Articles { get; set; }
    }
}