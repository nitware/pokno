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
    
    public partial class TRANSACTION_TYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRANSACTION_TYPE()
        {
            this.PAYMENT = new HashSet<PAYMENT>();
        }
    
        public long Transaction_Type_Id { get; set; }
        public string Transaction_Type_Name { get; set; }
        public string Transaction_Type_Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAYMENT> PAYMENT { get; set; }
    }
}