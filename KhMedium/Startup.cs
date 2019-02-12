using System;
using System.Collections.Generic;
using KhMedium.Data;
using KhMedium.Entities;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KhMedium.Startup))]

namespace KhMedium
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           
            //
            //            var context = new UnitOfWork(new KhMediumEntities());
            //            var categories = new List<Category>();
            //            categories.Add(new Category()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Arts & Entertainment",
            //                CreatedAt = DateTime.Now
            //            });
            //            categories.Add(new Category()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Industry",
            //                CreatedAt = DateTime.Now
            //            });
            //            categories.Add(new Category()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Innovation & Tech",
            //                CreatedAt = DateTime.Now
            //            });
            //            categories.Add(new Category()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Life",
            //                CreatedAt = DateTime.Now
            //            });
            //            categories.Add(new Category()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Society",
            //                CreatedAt = DateTime.Now
            //            });
            //
            //            context.Categories.AddRange(categories);
            //
            //            var categoryArt = categories[0];
            //            var topics = new List<Topic>();
            //            topics.Add(new Topic()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Art",
            //                CategoryId = categoryArt.Id,
            //                CreatedAt = DateTime.Now
            //            });
            //            topics.Add(new Topic()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Books",
            //                CategoryId = categoryArt.Id,
            //                CreatedAt = DateTime.Now
            //            });
            //            topics.Add(new Topic()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Comics",
            //                CategoryId = categoryArt.Id,
            //                CreatedAt = DateTime.Now
            //            });
            //
            //            topics.Add(new Topic()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Business",
            //                CategoryId = categories[1].Id,
            //                CreatedAt = DateTime.Now
            //            });
            //            topics.Add(new Topic()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Design",
            //                CategoryId = categories[1].Id,
            //                CreatedAt = DateTime.Now
            //            });
            //            topics.Add(new Topic()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Economy",
            //                CategoryId = categories[1].Id,
            //                CreatedAt = DateTime.Now
            //            });
            //            topics.Add(new Topic()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Freelancing",
            //                CategoryId = categories[1].Id,
            //                CreatedAt = DateTime.Now
            //            });
            //
            //            topics.Add(new Topic()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Leadership",
            //                CategoryId = categories[1].Id,
            //                CreatedAt = DateTime.Now
            //            });
            //            topics.Add(new Topic()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Marketing",
            //                CategoryId = categories[1].Id,
            //                CreatedAt = DateTime.Now
            //            });
            //
            //            topics.Add(new Topic()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Accessibility",
            //                CategoryId = categories[2].Id,
            //                CreatedAt = DateTime.Now
            //            });
            //            topics.Add(new Topic()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Android Dev",
            //                CategoryId = categories[2].Id,
            //                CreatedAt = DateTime.Now
            //            });
            //            topics.Add(new Topic()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Artificial Intelligence",
            //                CategoryId = categories[2].Id,
            //                CreatedAt = DateTime.Now
            //            });
            //            topics.Add(new Topic()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Blockchain",
            //                CategoryId = categories[2].Id,
            //                CreatedAt = DateTime.Now
            //            });
            //            topics.Add(new Topic()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Cryptocurrency",
            //                CategoryId = categories[2].Id,
            //                CreatedAt = DateTime.Now
            //            });
            //            topics.Add(new Topic()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Cybersecurity",
            //                CategoryId = categories[2].Id,
            //                CreatedAt = DateTime.Now
            //            });
            //            topics.Add(new Topic()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Data Science",
            //                CategoryId = categories[2].Id,
            //                CreatedAt = DateTime.Now
            //            });
            //            topics.Add(new Topic()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "iOS Dev",
            //                CategoryId = categories[2].Id,
            //                CreatedAt = DateTime.Now
            //            });
            //
            //
            //            topics.Add(new Topic()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Addiction",
            //                CategoryId = categories[3].Id,
            //                CreatedAt = DateTime.Now
            //            });
            //            topics.Add(new Topic()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Creativity",
            //                CategoryId = categories[3].Id,
            //                CreatedAt = DateTime.Now
            //            });
            //            topics.Add(new Topic()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Family",
            //                CategoryId = categories[3].Id,
            //                CreatedAt = DateTime.Now
            //            });
            //            topics.Add(new Topic()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Health",
            //                CategoryId = categories[3].Id,
            //                CreatedAt = DateTime.Now
            //            });
            //
            //            topics.Add(new Topic()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Basic Income",
            //                CategoryId = categories[4].Id,
            //                CreatedAt = DateTime.Now
            //            });
            //
            //            topics.Add(new Topic()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Cities",
            //                CategoryId = categories[4].Id,
            //                CreatedAt = DateTime.Now
            //            });
            //            topics.Add(new Topic()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Name = "Eduction",
            //                CategoryId = categories[4].Id,
            //                CreatedAt = DateTime.Now
            //            });
            //
            //            context.Topics.AddRange(topics);
            //            context.Complete();
        }
    }
}