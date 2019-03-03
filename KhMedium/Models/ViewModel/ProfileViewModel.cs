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
        public List<Following> Followings { get; set; }
        public List<Follower> Followers { get; set; }
    }
}