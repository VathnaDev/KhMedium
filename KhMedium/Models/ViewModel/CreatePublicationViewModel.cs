using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KhMedium.Entities;

namespace KhMedium.Models.ViewModel
{
    public class CreatePublicationViewModel
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public HttpPostedFileBase Logo { get; set; }
        public HttpPostedFileBase Cover { get; set; }
        public List<String> TagIds { get; set; }
        public List<String> AuthorsIds { set; get; }
    }
}