using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KhMedium.Entities;

namespace KhMedium.Models.ViewModel
{
    public class TopicViewModel
    {
        public Topic Topic { get; set; }
        public List<String> RelatedTopic { get; set; }
        public List<Article> PopularArticles { get; set; }
        public List<Article> LatestArticles { get; set; }
    }
}