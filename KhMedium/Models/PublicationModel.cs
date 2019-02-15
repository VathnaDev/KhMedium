//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace KhMedium.Models
{
    using System;
    using System.Collections.Generic;
    
    public class PublicationModel
    {
        public PublicationModel()
        {
            this.Authors = new List<AuthorModel>();
            this.Followers = new List<FollowerModel>();
            this.Followings = new List<FollowingModel>();
        }
    
        public string Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
    
        public virtual ICollection<AuthorModel> Authors { get; set; }
        public virtual ICollection<FollowerModel> Followers { get; set; }
        public virtual ICollection<FollowingModel> Followings { get; set; }
    }
}
