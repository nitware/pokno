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
    
    public partial class RETURNED_STOCK_REPLACEMENT
    {
        public long Returned_Stock_Replacement_Id { get; set; }
        public long Returned_Stock_Detail_Id { get; set; }
        public long Sold_Stock_Id { get; set; }
        public Nullable<long> Replaced_Stock_Action_Id { get; set; }
        public string Action_Reason { get; set; }
        public Nullable<System.DateTime> Action_Date { get; set; }
        public Nullable<long> Action_Executor_Id { get; set; }
    
        public virtual PERSON PERSON { get; set; }
        public virtual REPLACED_STOCK_ACTION REPLACED_STOCK_ACTION { get; set; }
        public virtual RETURNED_STOCK_DETAIL RETURNED_STOCK_DETAIL { get; set; }
        public virtual SOLD_STOCK SOLD_STOCK { get; set; }
    }
}
