using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Entity;
using Pokno.Model.Translator;

namespace Pokno.Model
{
   public class PaymentTranslator : TranslatorBase<Payment, PAYMENT>
    {
       private TransactionTypeTranslator _transactionTypeTranslator;

       public PaymentTranslator()
       {
           _transactionTypeTranslator = new TransactionTypeTranslator();
       }

        public override Payment TranslateToModel(PAYMENT paymentEntity)
        {
            try
            {
                Payment payment = null;
                if (paymentEntity != null)
                {
                    payment = new Payment();
                    payment.Id = paymentEntity.Payment_Id;
                    payment.AmountPayable = Math.Round(paymentEntity.Amount_Payable, 2);
                    payment.TransactionType = _transactionTypeTranslator.Translate(paymentEntity.TRANSACTION_TYPE);
                    payment.SerialNumber = paymentEntity.Serial_Number;
                    payment.InvoiceNumber = paymentEntity.Invoice_Number;
                    payment.DatePaid = paymentEntity.Date_Paid;
                }

                return payment;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override PAYMENT TranslateToEntity(Payment payment)
        {
            try
            {
                PAYMENT paymentEntity = null;
                if (payment != null)
                {
                    paymentEntity = new PAYMENT();
                    paymentEntity.Payment_Id = payment.Id;
                    paymentEntity.Amount_Payable = payment.AmountPayable;
                    paymentEntity.Transaction_Type_Id = payment.TransactionType.Id;
                    paymentEntity.Serial_Number = payment.SerialNumber;
                    paymentEntity.Invoice_Number = payment.InvoiceNumber;
                    paymentEntity.Date_Paid = payment.DatePaid;
                }

                return paymentEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }





    }
}
