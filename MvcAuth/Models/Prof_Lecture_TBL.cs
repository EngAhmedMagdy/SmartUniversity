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
    
    public partial class Prof_Lecture_TBL
    {
        public Nullable<int> Prof_ID { get; set; }
        public byte[] Prof_Lecture { get; set; }
        public string Prof_Lecture_Name { get; set; }
        public int Prof_Lecture_ID { get; set; }
    
        public virtual ProfessorTbl ProfessorTbl { get; set; }
    }
}
