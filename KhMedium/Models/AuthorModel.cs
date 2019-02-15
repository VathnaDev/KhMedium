using KhMedium.Models;

namespace KhMedium.Models
{
    using System;
    using System.Collections.Generic;

    public class AuthorModel
    {
        public AuthorModel()
        {
            this.Articles = new HashSet<ArticleModel>();
            this.Followers = new HashSet<FollowerModel>();
            this.Followings = new HashSet<FollowingModel>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string ProfilePicture { get; set; }
        public string PublicationId { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }

        public virtual ICollection<ArticleModel> Articles { get; set; }
        public virtual PublicationModel Publication { get; set; }
        public virtual ICollection<FollowerModel> Followers { get; set; }
        public virtual ICollection<FollowingModel> Followings { get; set; }
    }
}