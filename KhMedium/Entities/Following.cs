//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KhMedium.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Following
    {
        public string Id { get; set; }
        public string FollowingId { get; set; }
        public string UserId { get; set; }
        public string PublicationId { get; set; }
        public string TopicId { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public string AuthorId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Publication Publication { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual Author Author { get; set; }
    }
}
