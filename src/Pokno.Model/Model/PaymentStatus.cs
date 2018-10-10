using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Pokno.Model.Model
{
    
    public class PaymentStatus
    {
        
        public long PaymentId { get; set; }
        public long PaymentDetailId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
        
        public string Status { get; set; }
        
        public decimal AmountPayable { get; set; }
        
        public decimal AmountPaid { get; set; }
        
        public decimal Balance { get; set; }

        
        public string InitiatorPersonType { get; set; }
        
        public string InitiatorName { get; set; }
        
        public string InitiatorContactAddress { get; set; }
        
        public string InitiatorEmail { get; set; }
        
        public string InitiatorMobilePhone { get; set; }

        
        public string RecipientPersonType { get; set; }
        
        public string RecipientName { get; set; }
        
        public string RecipientContactAddress { get; set; }
        
        public string RecipientEmail { get; set; }
        
        public string RecipientMobilePhone { get; set; }

        public string InvoiceNumber { get; set; }

        //public long? InvoiceNumber { get; set; }
       
    }


}
