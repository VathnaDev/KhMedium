//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using KhMedium.Entities;

namespace KhMedium.Models
{
    using System;
    using System.Collections.Generic;
    
    public class TagModel
    {
        public TagModel()
        {
            this.ArticleTags = new List<ArticleTagModel>();
        }
    
        public string Id { get; set; }
        public string Name { get; set; }
        public System.DateTime CreatedAt { get; set; }
    
        public virtual ICollection<ArticleTagModel> ArticleTags { get; set; }
    }
}
