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
    
    public partial class DELETED_SOLD_STOCK_BATCH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DELETED_SOLD_STOCK_BATCH()
        {
            this.DELETED_SOLD_STOCK = new HashSet<DELETED_SOLD_STOCK>();
        }
    
        public long Sold_Stock_Batch_Id { get; set; }
        public long Customer_Id { get; set; }
        public long Payment_Id { get; set; }
        public long Seller_Id { get; set; }
        public Nullable<decimal> Total_Discount { get; set; }
        public System.DateTime Date_Sold { get; set; }
        public System.DateTime Date_Deleted { get; set; }
        public string Deleted_Reason { get; set; }
        public long Deleted_By_Person_Id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DELETED_SOLD_STOCK> DELETED_SOLD_STOCK { get; set; }
        public virtual PERSON PERSON { get; set; }
        public virtual PERSON PERSON1 { get; set; }
        public virtual PAYMENT PAYMENT { get; set; }
        public virtual PERSON PERSON2 { get; set; }
    }
}
