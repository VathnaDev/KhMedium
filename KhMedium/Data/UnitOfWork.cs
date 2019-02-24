using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KhMedium.Data.Core;
using KhMedium.Entities;

namespace KhMedium.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KhMediumEntities _context;

        public UnitOfWork(KhMediumEntities context)
        {
            _context = context;
            Articles = new ArticleRepository(_context);
            ArticleTags = new ArticleTagRepository(_context);
            Authors = new AuthorRepository(_context);
            Bookmarks = new BookmarkRepository(_context);
            Categories = new CategoryRepository(_context);
            Claps = new ClapRepository(_context);
            Comments = new CommentRepository(_context);
            Followers = new FollowerRepository(_context);
            Followings = new FollowingRepository(_context);
            Publications = new PublicationRepository(_context);
            Shares = new ShareRepository(_context);
            Tags = new TagRepository(_context);
            Topics = new TopicRepository(_context);
            UserTopics = new UserTopicRespository(_context);
            Files = new FileRepository(_context);
            AuthorPublication = new AuthorPublicationRepository(_context);
        }

        public IArticleRepository Articles { get; }
        public IArticleTagRepository ArticleTags { get; }
        public IAuthorRepository Authors { get; }
        public IBookmarkRepository Bookmarks { get; }
        public ICategoryRepository Categories { get; }
        public IClapRepository Claps { get; }
        public ICommentRepository Comments { get; }
        public IFollowerRepository Followers { get; }
        public IFollowingRepository Followings { get; }
        public IPublicationRepository Publications { get; }
        public IShareRepository Shares { get; }
        public ITagRepository Tags { get; }
        public ITopicRepository Topics { get; }
        public IUserTopicRepository UserTopics { get; }
        public IFileRepository Files { get; }
        public IAuthorPublicationRepository AuthorPublication { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}