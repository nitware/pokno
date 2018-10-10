using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Model
{
    public class PaymentHistory
    {
        public long PersonId { get; set; }
        public string Name { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TotalAmountPayable { get; set; }
        public decimal AmountPayable { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Balance { get; set; }
        public decimal TotalAmountPaid { get; set; }
        public decimal TotalBalance { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentTypeId { get; set; }
        public long PaymentId { get; set; }
        public string PaymentName { get; set; }
        public long PaymentDetailId { get; set; }


    }



}
