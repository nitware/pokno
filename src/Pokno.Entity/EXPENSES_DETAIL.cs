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
    
    public partial class EXPENSES_DETAIL
    {
        public long Expenses_Detail_Id { get; set; }
        public long Expenses_Id { get; set; }
        public long Expenses_Category_Id { get; set; }
        public string Collected_By { get; set; }
        public decimal Amount { get; set; }
        public long Payment_Type_Id { get; set; }
        public string Purpose { get; set; }
    
        public virtual EXPENSES EXPENSES { get; set; }
        public virtual EXPENSES_CATEGORY EXPENSES_CATEGORY { get; set; }
        public virtual PAYMENT_TYPE PAYMENT_TYPE { get; set; }
    }
}