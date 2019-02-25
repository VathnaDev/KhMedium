using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KhMedium.Entities;
using KhMedium.Models;

namespace KhMedium.Data.Core
{
    public interface IArticleRepository : IRepository<Article>
    {
        List<Article> GetFeatureArticle(String userId = "");
        List<Article> GetPopularArticle(String userId = "");
        List<Article> GetArticlesByTopic(String topicId);
        List<Article> GetAuthorArticlesByPublication(String publicationId, String authorId);

    }
}