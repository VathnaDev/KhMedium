using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KhMedium.Entities;

namespace KhMedium.Models.ViewModel
{
    public class TopicArticlesViewModel
    {
        public Topic Topic { get; set; }
        public List<String> RelatedTopics { get; set; }
        public Article FeatureArticle { get; set; }
        public List<Article> PopularArticles { get; set; }
        public List<Article> LatestArticles { get; set; }
    }
}