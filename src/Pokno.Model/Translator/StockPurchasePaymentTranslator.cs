using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Entity;
using Pokno.Model.Views;

namespace Pokno.Model.Translator
{
    public class StockPurchasePaymentTranslator
    {
        public StockPurchasePayment Translate(VW_STOCK_PURCHASE_PAYMENT entity)
        {
            try
            {
                return TranslateToModel(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StockPurchasePayment> Translate(List<VW_STOCK_PURCHASE_PAYMENT> entities)
        {
            try
            {
                List<StockPurchasePayment> stockPurchasePayments = new List<StockPurchasePayment>();
                foreach (VW_STOCK_PURCHASE_PAYMENT entity in entities)
                {
                    stockPurchasePayments.Add(TranslateToModel(entity));
                }

                return stockPurchasePayments;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private StockPurchasePayment TranslateToModel(VW_STOCK_PURCHASE_PAYMENT stockPurchasePaymentEntity)
        {
            try
            {
                StockPurchasePayment stockPurchasePayment = null;
                if (stockPurchasePaymentEntity != null)
                {
                    stockPurchasePayment = new StockPurchasePayment();
                    stockPurchasePayment.AmountPaid = Math.Round(stockPurchasePaymentEntity.Amount_Paid, 2);
                    stockPurchasePayment.AmountPayable = Math.Round(stockPurchasePaymentEntity.Amount_Payable, 2);
                    stockPurchasePayment.TransactionDate = stockPurchasePaymentEntity.Transaction_Date;
                    //stockPurchasePayment.Name = stockPurchasePaymentEntity.Name;
                    stockPurchasePayment.Id = (int)stockPurchasePaymentEntity.Person_Id;
                    stockPurchasePayment.PaymentType = stockPurchasePaymentEntity.Payment_Name;

                    //stockPurchasePayment.Payment = paymentTranslator.TranslateToModel(stockPurchasePaymentEntity.Payment_Id);
                }

                return stockPurchasePayment;
            }
            catch (Exception)
            {
                throw;
            }
        }



    }


}
