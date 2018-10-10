using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Views
{
    public class VW_STOCK_PURCHASE_PAYMENT
    {
        public long? Person_Id { get; set; }
        public long Person_Type_Id { get; set; }
        public DateTime Transaction_Date { get; set; }
        public string Name { get; set; }
        public decimal Amount_Payable { get; set; }
        public decimal Amount_Paid { get; set; }
        public decimal? Balance { get; set; }
        public DateTime Payment_Date { get; set; }
        public long Payment_Type_Id { get; set; }
        public long Payment_Id { get; set; }
        public string Payment_Name { get; set; }
        public long Payment_Detail_Id { get; set; }
        public string Invoice_Number { get; set; }
    }



}
