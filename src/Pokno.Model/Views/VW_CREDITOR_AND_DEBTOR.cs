using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Views
{
    public class VW_CREDITOR_AND_DEBTOR
    {
        public long Payment_Id { get; set; }
        public DateTime Transaction_Date { get; set; }
        public string Status { get; set; }
        public decimal? Amount_Payable { get; set; }
        public decimal? Amount_Paid { get; set; }
        public decimal? Balance { get; set; }
        public string Initiator_Person_Type_Name { get; set; }
        public string Initiator_Name { get; set; }
        public string Initiator_Contact_Address { get; set; }
        public string Initiator_Email { get; set; }
        public string Initiator_Mobile_Phone { get; set; }
        public string Recipient_Name { get; set; }
        public string Recipient_Contact_Address { get; set; }
        public string Recipient_Email { get; set; }
        public string Recipient_Mobile_Phone { get; set; }
        public string Recipient_Person_Type_Name { get; set; }
        public string Invoice_Number { get; set; }
       

    }




}
