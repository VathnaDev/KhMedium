using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.WebPages;
using KhMedium.Data.Core;
using KhMedium.Entities;
using KhMedium.Models;

namespace KhMedium.Data
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(DbContext context) : base(context)
        {
        }

        public Article Get(string id)
        {
            var result = KhMediumContext.Articles.Find(id);
            if (result != null && result.DeletedAt != null) return null;
            return result;
        }

        public IEnumerable<Article> GetAll()
        {
            return KhMediumContext.Articles.Where(a => a.DeletedAt == null);
        }

        public IEnumerable<Article> Find(Expression<Func<Article, bool>> predicate)
        {
            return KhMediumContext.Articles.Where(predicate)
                .Where(a => a.DeletedAt == null);
        }

        public Article SingleOrDefault(Expression<Func<Article, bool>> predicate)
        {
            return KhMediumContext.Articles
                .Where(predicate)
                .First(a => a.DeletedAt == null);
        }


        public List<Article> GetFeatureArticle(String userId = "")
        {
            var articles = KhMediumContext.Articles.OrderBy(
                    a => a.CreatedAt)
                .ThenBy(a => a.Claps.Count)
                .ToList();

            if (userId.IsEmpty()) return articles;
            var user = KhMediumContext.AspNetUsers.SingleOrDefault(u => u.Id == userId);
            articles = (from userTopic in user?.UserTopics
                from article in articles
                where userTopic.TopicId == article.TopicId
                select article
            ).ToList();
            return articles;
        }

        public List<Article> GetPopularArticle(String userId = "")
        {
            var articles = KhMediumContext.Articles.OrderBy(
                    a => a.CreatedAt)
                .ThenBy(a => a.Claps.Count)
                .ThenBy(a => a.Comments.Count)
                .ToList();

            if (!userId.IsEmpty())
            {
                var user = KhMediumContext.AspNetUsers.SingleOrDefault(u => u.Id == userId);
                articles = (from userTopic in user.UserTopics
                    from article in articles
                    where userTopic.TopicId == article.TopicId
                    select article
                ).ToList();
            }
            return articles;
        }

        public List<Article> GetArticlesByTopic(String topicId)
        {
            var topic = KhMediumContext.Topics.SingleOrDefault(t => t.Id == topicId);
            return topic?.Articles.ToList() ?? new List<Article>();
        }

        public List<Article> GetAuthorArticlesByPublication(string publicationId, string authorId)
        {
            return KhMediumContext.Articles.Where(
                a => a.DeletedAt != null &&
                     a.Author.Id == authorId &&
                     a.Author.Publication.Id == publicationId
            ).ToList();
        }

        public KhMediumEntities KhMediumContext => Context as KhMediumEntities;
    }
}