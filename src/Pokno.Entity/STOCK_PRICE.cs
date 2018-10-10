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
    
    public partial class STOCK_PRICE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STOCK_PRICE()
        {
            this.DELETED_SOLD_STOCK = new HashSet<DELETED_SOLD_STOCK>();
            this.SOLD_STOCK = new HashSet<SOLD_STOCK>();
        }
    
        public long Stock_Price_Id { get; set; }
        public long Stock_Package_Id { get; set; }
        public decimal Cost_Price { get; set; }
        public decimal Selling_Price { get; set; }
        public System.DateTime Date_Entered { get; set; }
    
        public virtual CURRENT_STOCK_PRICE CURRENT_STOCK_PRICE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DELETED_SOLD_STOCK> DELETED_SOLD_STOCK { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOLD_STOCK> SOLD_STOCK { get; set; }
        public virtual STOCK_PACKAGE STOCK_PACKAGE { get; set; }
    }
}