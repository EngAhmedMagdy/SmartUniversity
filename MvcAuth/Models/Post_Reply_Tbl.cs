//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcAuth.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Post_Reply_Tbl
    {
        public int Post_ID { get; set; }
        public Nullable<int> St_ID { get; set; }
        public int Reply_ID { get; set; }
        public string Reply_Content { get; set; }
    
        public virtual PostTbl PostTbl { get; set; }
        public virtual StudentTbl StudentTbl { get; set; }
    }
}
