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
    
    public partial class STOCK_PURCHASE_BATCH_TYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STOCK_PURCHASE_BATCH_TYPE()
        {
            this.STOCK_PURCHASE_BATCH = new HashSet<STOCK_PURCHASE_BATCH>();
        }
    
        public long Stock_Purchase_Batch_Type_Id { get; set; }
        public string Stock_Purchase_Batch_Type_Name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STOCK_PURCHASE_BATCH> STOCK_PURCHASE_BATCH { get; set; }
    }
}