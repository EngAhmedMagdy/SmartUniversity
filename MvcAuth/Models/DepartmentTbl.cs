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
    
    public partial class DepartmentTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DepartmentTbl()
        {
            this.StudentTbls = new HashSet<StudentTbl>();
        }
    
        public int Dep_ID { get; set; }
        public string Dep_Name { get; set; }
        public Nullable<int> Prof_ID { get; set; }
    
        public virtual ProfessorTbl ProfessorTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentTbl> StudentTbls { get; set; }
    }
}
