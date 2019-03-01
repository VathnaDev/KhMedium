using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using KhMedium.Entities;
using KhMedium.Models.ViewModel;

namespace KhMedium.Areas.Admin.Models
{
    public class AuthorViewModel
    {
        public String AuthorId { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Email { get; set; }
        public String Bio{ get; set; }
        public HttpPostedFileBase Profile { get; set; }
    }
}