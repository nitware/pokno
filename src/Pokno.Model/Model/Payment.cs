using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using Pokno.Model.Model;

namespace Pokno.Model
{
    public class Payment : BaseModel
    {
        private decimal _amountPaid;
        private decimal _amountPayable;
        private decimal _balance;

        public enum Transaction
        {
            Purchase = 1,
            Sale = 2,
            Refund = 3
        }

        public long Id { get; set; }
        public long? SerialNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime DatePaid { get; set; }
                
        public decimal AmountPayable 
        {
            get { return _amountPayable; }
            set
            {
                _amountPayable = value;
                base.OnPropertyChanged("AmountPayable");
            }
        }
        
        public decimal AmountPaid 
        {
            get { return _amountPaid; }
            set
            {
                _amountPaid = value;
                base.OnPropertyChanged("AmountPaid");
            }
        }
        
        public decimal Balance 
        {
            get { return _balance; }
            set
            {
                _balance = value;
                base.OnPropertyChanged("Balance");
            }
        }

        public DateTime TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public List<PaymentDetail> Details { get; set; }

    }



}
