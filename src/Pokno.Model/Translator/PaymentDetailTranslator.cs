using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Entity;

namespace Pokno.Model
{
    public class PaymentDetailTranslator : TranslatorBase<PaymentDetail, PAYMENT_DETAIL>
    {
        private ChequeTranslator chequeTranslator;
        private PaymentTranslator paymentTranslator;
        private PaymentTypeTranslator paymentTypeTranslator;
        
        public PaymentDetailTranslator()
        {
            paymentTranslator = new PaymentTranslator();
            paymentTypeTranslator = new PaymentTypeTranslator();
            chequeTranslator = new ChequeTranslator();
        }

        public override PaymentDetail TranslateToModel(PAYMENT_DETAIL paymentDetailEntity)
        {
            try
            {
                PaymentDetail paymentDetail = null;
                if (paymentDetailEntity != null)
                {
                    paymentDetail = new PaymentDetail();
                    paymentDetail.Id = paymentDetailEntity.Payment_Detail_Id;
                    paymentDetail.AmountPaid = Math.Round(paymentDetailEntity.Amount_Paid, 2);
                    paymentDetail.PaymentDate = paymentDetailEntity.Payment_Date;
                    paymentDetail.Payment = paymentTranslator.Translate(paymentDetailEntity.PAYMENT);
                    paymentDetail.Cheque = chequeTranslator.Translate(paymentDetailEntity.CHEQUE);
                    paymentDetail.PaymentType = paymentTypeTranslator.Translate(paymentDetailEntity.PAYMENT_TYPE);
                }

                return paymentDetail;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override PAYMENT_DETAIL TranslateToEntity(PaymentDetail paymentDetail)
        {
            try
            {
                PAYMENT_DETAIL paymentDetailEntity = null;
                if (paymentDetail != null)
                {
                    paymentDetailEntity = new PAYMENT_DETAIL();
                    paymentDetailEntity.Payment_Detail_Id = paymentDetail.Id;
                    paymentDetailEntity.Amount_Paid = paymentDetail.AmountPaid;
                    paymentDetailEntity.Payment_Date = paymentDetail.PaymentDate;
                    paymentDetailEntity.Payment_Id = paymentDetail.Payment.Id;
                    paymentDetailEntity.Payment_Type_Id = paymentDetail.PaymentType.Id;

                }
                return paymentDetailEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }





    }
}
