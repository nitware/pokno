//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pokno.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class EXPENSES_CATEGORY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EXPENSES_CATEGORY()
        {
            this.EXPENSES_DETAIL = new HashSet<EXPENSES_DETAIL>();
        }
    
        public long Expenses_Category_Id { get; set; }
        public string Expenses_Category_Name { get; set; }
        public string Expenses_Category_Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EXPENSES_DETAIL> EXPENSES_DETAIL { get; set; }
    }
}