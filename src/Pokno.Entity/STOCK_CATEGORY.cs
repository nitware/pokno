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
    
    public partial class STOCK_CATEGORY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STOCK_CATEGORY()
        {
            this.STOCK_TYPE = new HashSet<STOCK_TYPE>();
        }
    
        public long Stock_Category_Id { get; set; }
        public string Stock_Category_Name { get; set; }
        public string Stock_Category_Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STOCK_TYPE> STOCK_TYPE { get; set; }
    }
}
