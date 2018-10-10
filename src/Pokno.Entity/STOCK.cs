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
    
    public partial class STOCK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STOCK()
        {
            this.STOCK_PACKAGE = new HashSet<STOCK_PACKAGE>();
            this.STOCK_PACKAGE_RELATIONSHIP = new HashSet<STOCK_PACKAGE_RELATIONSHIP>();
            this.STOCK_PURCHASED = new HashSet<STOCK_PURCHASED>();
            this.STOCK_PURCHASED_POOL = new HashSet<STOCK_PURCHASED_POOL>();
        }
    
        public long Stock_Id { get; set; }
        public string Stock_Name { get; set; }
        public long Stock_Type_Id { get; set; }
        public string Stock_Descrption { get; set; }
        public string Image_Path { get; set; }
    
        public virtual STOCK_TYPE STOCK_TYPE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STOCK_PACKAGE> STOCK_PACKAGE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STOCK_PACKAGE_RELATIONSHIP> STOCK_PACKAGE_RELATIONSHIP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STOCK_PURCHASED> STOCK_PURCHASED { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STOCK_PURCHASED_POOL> STOCK_PURCHASED_POOL { get; set; }
    }
}