using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Views
{
    public class VW_PAYMENT_TRANSACTION
    {
        public long? Person_Id { get; set; }
        public long Payment_Id { get; set; }
        public DateTime Transaction_Date { get; set; }
        public decimal? Amount_Payable { get; set; }
        public decimal? Amount_Paid { get; set; }
        public decimal? Balance { get; set; }

        public long Transaction_Type_Id { get; set; }
        public string Transaction_Type_Name { get; set; }
    }


}
