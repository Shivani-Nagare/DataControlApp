//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataControl_Project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblDep
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblDep()
        {
            this.tblEmp1 = new HashSet<tblEmp1>();
        }
    
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptDescription { get; set; }
        public int DeptLocation { get; set; }
        public bool IsActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEmp1> tblEmp1 { get; set; }
    }
}
