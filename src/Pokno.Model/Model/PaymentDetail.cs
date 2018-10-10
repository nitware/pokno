using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using Pokno.Model.Model;

namespace Pokno.Model
{
    
    public class PaymentDetail : BaseModel
    {
        private DateTime _paymentDate;
        private PaymentType _paymentType;
        private decimal _amountPaid;

        public long Id { get; set; }
        public Payment Payment { get; set; }


        public Cheque Cheque { get; set; }

        public DateTime PaymentDate
        {
            get { return _paymentDate; }
            set
            {
                _paymentDate = value;
                base.OnPropertyChanged("PaymentDate");
            }
        }

        public PaymentType PaymentType 
        {
            get { return _paymentType; }
            set
            {
                _paymentType = value;
                base.OnPropertyChanged("PaymentType");
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


        

    }

}
