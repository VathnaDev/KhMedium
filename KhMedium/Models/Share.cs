//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using KhMedium.Entities;
using Article = KhMedium.Model.Article;

namespace KhMedium.Models
{
    using System;
    using System.Collections.Generic;
    
    public class Share
    {
        public string Id { get; set; }
        public string ArticleId { get; set; }
        public string UserId { get; set; }
        public System.DateTime CreatedAt { get; set; }
    
        public virtual Article Article { get; set; }
//        public virtual AspNetUser { get; set; }
    }
}
