using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Views
{
    public class VW_PAYMENT_SUMMARY
    {
        public long Payment_Id { get; set; }
        public string Invoice_Number { get; set; }
        public string Initiator_Name { get; set; }
        public string Recipient_Name { get; set; }
        public string Transaction_Type_Name { get; set; }
        public decimal? Amount_Payable { get; set; }
        public decimal? Amount_Paid { get; set; }
        public DateTime Payment_Date { get; set; }
        public decimal Balance { get; set; }
    }
}
