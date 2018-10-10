using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using Pokno.Model;

namespace Pokno.Model
{
    
    public class StockPurchasePayment
    {
            
            public int? Id { get; set; }
            
            public string Name { get; set; }
            
            public decimal AmountPaid {get;set;}
            
            public decimal AmountPayable {get;set;}
            
            public decimal Balance { get; set; }
            
            public DateTime TransactionDate {get;set;}
             
            public Payment Payment {get;set;}
            
            public string PaymentType {get;set;}            
    }
}
