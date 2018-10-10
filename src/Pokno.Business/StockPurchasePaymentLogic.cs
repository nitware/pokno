using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using Pokno.Data;
using Pokno.Model.Translator;
using Pokno.Model;
using Pokno.Entity;
using System.Linq.Expressions;
using Pokno.Model.Views;
using Pokno.Business.Interfaces;

namespace Pokno.Business
{
    public class StockPurchasePaymentLogic 
    {
        private IRepository _repository;
        private PaymentLogic paymentLogic;
        private StockPurchasePaymentTranslator stockPurchasePaymentTranslator;

        protected const string ITEM_WITH_THE_SAME_KEY = "An item with the same key has already been added";
        protected const string CONNECTION_WAS_CLOSED = "Connection was closed, statement was terminated";
        protected const string CONTEXT_CANNOT_BE_USED = "The context cannot be used while the model is being created. This exception may be thrown if the context";
        protected const string EDMTYPE_CANNOT_BE_MAPPED = "An EdmType cannot be mapped to CLR classes multiple times. The EdmType";


        public StockPurchasePaymentLogic(IRepository repository)
        {
            _repository = repository;
            stockPurchasePaymentTranslator = new StockPurchasePaymentTranslator();
            paymentLogic = new PaymentLogic(repository);
        }

        public List<StockPurchasePayment> GetSupplierPaymentHistory(Person person)
        {
            List<StockPurchasePayment> purchasePayments = null;

            try
            {
                string query = "SELECT * FROM VW_STOCK_PURCHASE_PAYMENT where Person_Id = " + person.Id;
                List<VW_STOCK_PURCHASE_PAYMENT> stockPurchasePayments = _repository.DbContext.Database.SqlQuery<VW_STOCK_PURCHASE_PAYMENT>(query).ToList();

                if (stockPurchasePayments != null)
                {
                    purchasePayments = new List<StockPurchasePayment>();
                    foreach (VW_STOCK_PURCHASE_PAYMENT stockPurchasePaymentEntity in stockPurchasePayments)
                    {
                        StockPurchasePayment stockPurchasePayment = new StockPurchasePayment();
                        stockPurchasePayment.AmountPaid = Math.Round(stockPurchasePaymentEntity.Amount_Paid, 2);
                        stockPurchasePayment.AmountPayable = Math.Round(stockPurchasePaymentEntity.Amount_Payable, 2);
                        stockPurchasePayment.Balance = Math.Round(stockPurchasePaymentEntity.Balance.GetValueOrDefault(), 2);
                        stockPurchasePayment.TransactionDate = stockPurchasePaymentEntity.Transaction_Date;
                        stockPurchasePayment.Name = stockPurchasePaymentEntity.Name;
                        stockPurchasePayment.Id = (int)stockPurchasePaymentEntity.Person_Id;
                        stockPurchasePayment.PaymentType = stockPurchasePaymentEntity.Payment_Name;
                        stockPurchasePayment.Payment = paymentLogic.GetById(stockPurchasePaymentEntity.Payment_Id);

                        purchasePayments.Add(stockPurchasePayment);
                    }
                }
            }
            catch (Exception ex)
            {
                SuppressError(ex);
            }

            return purchasePayments;
        }


        protected void SuppressError(Exception ex)
        {
            try
            {
                string message = ex.Message;
                if (!message.Contains(ITEM_WITH_THE_SAME_KEY) && !message.Contains(CONNECTION_WAS_CLOSED) && !message.Contains(CONTEXT_CANNOT_BE_USED) && !message.Contains(EDMTYPE_CANNOT_BE_MAPPED))
                {
                    throw ex;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

     




    }


}
