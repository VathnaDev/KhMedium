using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KhMedium.Entities;

namespace KhMedium.Models.ViewModel
{
    public class PublicationViewModel
    {
        public List<AuthorPublication> Publications { get; set; }
    }
}