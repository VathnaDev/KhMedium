//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using KhMedium.Model;

namespace KhMedium.Models
{
    using System;
    using System.Collections.Generic;
    
    public  class ArticleTag
    {
        public int Id { get; set; }
        public string ArticleId { get; set; }
        public string TagId { get; set; }
    
        public virtual Article Article { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
