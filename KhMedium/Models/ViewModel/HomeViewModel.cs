using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KhMedium.Entities;

namespace KhMedium.Models.ViewModel
{
    public class HomeViewModel
    {
        public List<Topic> Topics { get; set; }
        public List<Article> FeatureArticles { get; set; }
        public List<Article> PopularArticles { get; set; }
        public List<Article> BasedHistoryArticles { get; set; }
        public List<Article> AllStoriesArticles { get; set; }
    }
}