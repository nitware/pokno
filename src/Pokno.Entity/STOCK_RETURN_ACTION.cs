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
    
    public partial class STOCK_RETURN_ACTION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STOCK_RETURN_ACTION()
        {
            this.RETURNED_STOCK_DETAIL = new HashSet<RETURNED_STOCK_DETAIL>();
        }
    
        public long Stock_Return_Action_Id { get; set; }
        public string Stock_Return_Action_Name { get; set; }
        public string Stock_Return_Action_Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RETURNED_STOCK_DETAIL> RETURNED_STOCK_DETAIL { get; set; }
    }
}
