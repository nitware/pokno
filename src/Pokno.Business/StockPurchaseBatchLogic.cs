using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Transactions;

using Pokno.Model;
using Pokno.Entity;
using System.Linq.Expressions;
using Pokno.Business.Interfaces;
using System.Data.Entity.Core;

namespace Pokno.Business
{
    public class StockPurchaseBatchLogic : BusinessLogicBase<StockPurchaseBatch, STOCK_PURCHASE_BATCH>
    {
        private PersonLogic personLogic;
        private PaymentLogic paymentLogic;
        private StockPurchasedLogic stockPurchasedLogic;

        private const string INCLUDE = "PAYMENT, PERSON, PERSON1, STOCK_PURCHASE_BATCH_TYPE";

        public StockPurchaseBatchLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new StockPurchaseBatchTranslator();
            paymentLogic = new PaymentLogic(repository);
            stockPurchasedLogic = new StockPurchasedLogic(repository);
            personLogic = new PersonLogic(repository);
        }

        public DateTime GetPurchaseDate(bool isMinimum)
        {
            const int TOP_ONE = 1;

            try
            {
                StockPurchaseBatch stockPurchaseBatch = null;
                Expression<Func<STOCK_PURCHASE_BATCH, bool>> selector = sp => sp.Stock_Purchase_Batch_Id > 0;
                Func<IQueryable<STOCK_PURCHASE_BATCH>, IOrderedQueryable<STOCK_PURCHASE_BATCH>> orderBy = null;

                if (isMinimum)
                {
                    orderBy = spb => spb.OrderBy(sp => sp.Date_Puchased);
                }
                else
                {
                    orderBy = spb => spb.OrderByDescending(sp => sp.Date_Puchased);
                }

                List<StockPurchaseBatch> purchaseBatches = base.GetTopBy(TOP_ONE, selector, orderBy);
                if (purchaseBatches != null && purchaseBatches.Count > 0)
                {
                    stockPurchaseBatch = purchaseBatches.FirstOrDefault();
                }

                if (stockPurchaseBatch != null)
                {
                    return stockPurchaseBatch.DatePurchased;
                }

                return DateTime.MinValue;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StockPurchaseBatch> GetPurchaseBatchNotOnShelf()
        {
            List<StockPurchaseBatch> stockPurchaseBatches = null;

            try
            {
                string query = "SELECT Max(Date_Entered) FROM SHELF";
                DateTime? lastStockOnShelfDate = repository.DbContext.Database.SqlQuery<DateTime?>(query).SingleOrDefault();
                                
                if (lastStockOnShelfDate != null)
                {
                    Expression<Func<STOCK_PURCHASE_BATCH, bool>> selector = s => s.Date_Puchased > lastStockOnShelfDate;
                    stockPurchaseBatches = base.GetModelsBy(selector, null, INCLUDE);
                }
                else
                {
                    stockPurchaseBatches = GetAll();
                }
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return stockPurchaseBatches;
        }

        public override List<StockPurchaseBatch> GetAll()
        {
            int TOP_HUNDRED = 100;

            try
            {
                Expression<Func<STOCK_PURCHASE_BATCH, bool>> selector = s => s.Stock_Purchase_Batch_Id > 0;
                Func<IQueryable<STOCK_PURCHASE_BATCH>, IOrderedQueryable<STOCK_PURCHASE_BATCH>> orderBy = spb => spb.OrderByDescending(sp => sp.Date_Puchased);

                List<StockPurchaseBatch> purchaseBatches = base.GetTopBy(TOP_HUNDRED, selector, orderBy);
                
                //if (purchaseBatches != null)
                //{
                //    purchaseBatches.OrderByDescending(spb => spb.DatePurchased).ToList();
                //}

                return purchaseBatches;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public StockPurchaseBatch Get(long id)
        {
            try
            {
                Expression<Func<STOCK_PURCHASE_BATCH, bool>> selector = spb => spb.Stock_Purchase_Batch_Id == id;
                return base.GetModelBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }
      
        public override StockPurchaseBatch Add(StockPurchaseBatch stockPurchaseBatch)
        {
            try
            {
                base.OpenDatabaseConnectionIfClosed();
                using (IDbTransaction ctxTrans = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    paymentLogic.repository = repository;
                    Payment payment = paymentLogic.Add(stockPurchaseBatch.Payment);
                    if (payment == null || payment.Id <= 0)
                    {
                        throw new Exception("Creation of associated payment for stock purchased failed! Please try again.");
                    }

                    stockPurchaseBatch.Payment = payment;
                    StockPurchaseBatch newPurchaseBatch = base.Add(stockPurchaseBatch);
                    if (newPurchaseBatch == null || newPurchaseBatch.Id <= 0)
                    {
                        throw new Exception("Creation Purchase Batch failed! Please try again.");
                    }

                    foreach (StockPurchased purchasedStock in stockPurchaseBatch.StockPurchases)
                    {
                        purchasedStock.Batch = newPurchaseBatch;
                    }

                    stockPurchasedLogic.repository = repository;
                    int addedPurchasestocks = stockPurchasedLogic.Add(stockPurchaseBatch.StockPurchases);
                    if (addedPurchasestocks <= 0 || addedPurchasestocks != stockPurchaseBatch.StockPurchases.Count)
                    {
                        throw new Exception("Purchase Stock Save operation failed! Please try again.");
                    }

                    base.CommitTransaction(ctxTrans);

                    return newPurchaseBatch;
                }
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(ArgumentNullException);
            }
            catch (UpdateException)
            {
                throw new UpdateException(UpdateException);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public List<StockPurchaseBatch> GetUnRegisteredStockPurchaseInBatch()
        //{
        //    try
        //    {
        //    //    IEnumerable<StockPurchaseBatch> stockPurchaseBatches = from batch in base.GetAll() select batch = stockPurchasedLogic.LoadStockPurchaseByBatch(batch);
        //        List<StockPurchaseBatch> filteredStockBatch = new List<StockPurchaseBatch>();
        //    //    foreach (StockPurchaseBatch batch in stockPurchaseBatches)
        //    //    {
        //    //        foreach (StockPurchased stockPurchase in batch.StockPurchases)
        //    //        {
        //    //            if (stockPurchase != null)
        //    //            {
        //    //                //int unRegisteredQuantity = incomingStockBatchLogic.GetUnRegisteredQuantityInUnits(stockPurchase);
        //    //                if (unRegisteredQuantity > 0)
        //    //                {
        //    //                    // A break occures in the inner foreach loop,when code Detects that a StockPurchased of a Batch is not or partly registered.
        //    //                    //When this happens batch will be returned.
        //    //                    batch.StockPurchases.Clear();
        //    //                    filteredStockBatch.Add(batch);
        //    //                    break;
        //    //                }
        //    //            }
        //    //        }
        //    //    }
        //        return filteredStockBatch;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public bool Remove(StockPurchaseBatch stockPurchaseBatch)
        {
            try
            {
                stockPurchasedLogic.LoadStockPurchaseByBatch(stockPurchaseBatch);
                using (TransactionScope scope = new TransactionScope())
                {
                    stockPurchasedLogic.Remove(stockPurchaseBatch);
                    Expression<Func<STOCK_PURCHASE_BATCH, bool>> selector = purchaseBatch => purchaseBatch.Stock_Purchase_Batch_Id == stockPurchaseBatch.Id;
                    base.Remove(selector);

                    //repository.Save();
                    paymentLogic.Remove(stockPurchaseBatch.Payment);
                    
                    scope.Complete();
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public StockPurchaseBatch LoadBatchStockPurchaseAndPaymentInformation(StockPurchaseBatch batch)
        {
            List<StockPurchased> stockPurchases  = new List<StockPurchased>();
            batch = stockPurchasedLogic.LoadStockPurchaseByBatch(batch);

            //if (batch.StockPurchases != null && batch.StockPurchases.Count > 0)
            //{
            //    int loopCount = 0;
            //    foreach (StockPurchased stockPurchase in batch.StockPurchases)
            //    {
            //        if (stockPurchase != null)
            //        {
            //            int unRegisteredQuantity = incomingStockBatchLogic.GetUnRegisteredQuantityInUnits(stockPurchase);
            //            if (unRegisteredQuantity > 0)
            //            {
            //                stockPurchases.Add(stockPurchase);
            //            }
            //        }
            //        loopCount++;
            //        if (loopCount == batch.StockPurchases.Count)
            //        {
            //            batch.StockPurchases = stockPurchases;
            //            break;
            //        }
            //    }
            //}

            batch.Payment = paymentLogic.LoadBatchPaymentWithPaymentDetails(batch.Payment);
            return batch;
        }

        //public decimal GetBatchTotalCostPrice(StockPurchaseBatch batch)
        //{
        //    try
        //    {
        //        Func<STOCK_PURCHASED, bool> selector = spb => spb.Stock_Purchase_Batch_Id == batch.Id;
        //        List<StockPurchased> purchasedStocks = GetBy(batch);

        //        return purchasedStocks.Sum(sp => sp.Cost);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public bool Modify(StockPurchaseBatch stockPurchaseBatch)
        {
            try
            {
                if (stockPurchaseBatch == null)
                {
                    throw new Exception("Purchase Stock Batch cannot be null! Please try again.");
                }

                decimal totalCost = 0;
                if (stockPurchaseBatch.StockPurchases != null && stockPurchaseBatch.StockPurchases.Count > 0)
                {
                    totalCost = stockPurchaseBatch.StockPurchases.Sum(s => s.Cost);
                    if (totalCost > stockPurchaseBatch.Payment.AmountPayable)
                    {
                        throw new Exception("Amount Payable '" + String.Format("{0:n}", stockPurchaseBatch.Payment.AmountPayable) + "' cannot be less than total cost of stocks purchased '" + String.Format("{0:n}", totalCost) + "' under this batch! Please modify Amount Payable");
                    }
                }

                OpenDatabaseConnectionIfClosed();
                using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    Expression<Func<STOCK_PURCHASE_BATCH, bool>> predicate = purchaseBatch => purchaseBatch.Stock_Purchase_Batch_Id == stockPurchaseBatch.Id;
                    STOCK_PURCHASE_BATCH stockPurchaseBatchEntity = GetEntityBy(predicate);

                    stockPurchaseBatchEntity.Date_Puchased = stockPurchaseBatch.DatePurchased;
                    stockPurchaseBatchEntity.Buyer_Id = stockPurchaseBatch.Buyer.Id;
                    stockPurchaseBatchEntity.Supplier_Id = stockPurchaseBatch.Supplier.Id;
                    stockPurchaseBatchEntity.Supplier_Expenses = stockPurchaseBatch.SupplierExpenses;
                    stockPurchaseBatchEntity.Invoice_Number = stockPurchaseBatch.InvoiceNumber;

                    paymentLogic.repository = repository;
                    paymentLogic.Modify(stockPurchaseBatch.Payment);
                    int rowAffected = repository.Save();
                    
                    if (stockPurchaseBatch.StockPurchases != null && stockPurchaseBatch.StockPurchases.Count > 0)
                    {
                        stockPurchasedLogic.repository = repository;
                        stockPurchasedLogic.Modify(stockPurchaseBatch);
                    }

                    base.CommitTransaction(transaction);

                    return true;
                }
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(ArgumentNullException);
            }
            catch (UpdateException)
            {
                throw new UpdateException(UpdateException);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //private bool AmountPayableIsLessThanStocksPurchased(StockPurchaseBatch batch)
        //{
        //    try
        //    {
        //        decimal totalCost = 0;
        //        if (batch != null && batch.Payment != null)
        //        {
        //            totalCost = stockPurchasedLogic.GetBatchTotalCostPrice(batch);
        //            if (totalCost > batch.Payment.AmountPayable)
        //            {
        //                return true;
        //            }
        //        }

        //        return false;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //loads StockPurchasBatches, When The User Specifies A  Date Range       
        public List<StockPurchaseBatch> GetStockPurchaseBatchByDateRange(DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                Expression<Func<STOCK_PURCHASE_BATCH, bool>> selector = purchaseBatch => purchaseBatch.Date_Puchased <= dateFrom.Date && purchaseBatch.Date_Puchased >= dateTo.Date;
                List<StockPurchaseBatch> stockPurchaseBatches = GetModelsBy(selector);
                return stockPurchaseBatches;
            }
            catch (Exception)
            {
                throw; 
            }
        }






    }
}
