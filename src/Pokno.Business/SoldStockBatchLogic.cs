using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Transactions;

using Pokno.Model;
using Pokno.Entity;
using System.Linq.Expressions;
using Pokno.Model.Model;
using Pokno.Business.Interfaces;
using System.Data.Entity.Core;
using Pokno.Model.Views;
using Pokno.NumberConverter;
using Pokno.Business.Helper;

namespace Pokno.Business
{
    public class SoldStockBatchLogic : BusinessLogicBase<SoldStockBatch, SOLD_STOCK_BATCH>
    {
        private PaymentLogic _paymentLogic;
        private SoldStockLogic _soldStockLogic;
        private PaymentDetailLogic _paymentDetailLogic;
        private PersonCompanyLogic _personCompanyLogic;
        private StockPurchaseBatchLogic _stockPurchaseBatchLogic;
        private PersonLogic _personLogic;
        private ShelfLogic _shelfLogic;

        public SoldStockBatchLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new SoldStockBatchTranslator();
            _shelfLogic = new ShelfLogic(repository);
            _paymentLogic = new PaymentLogic(repository);
            _personLogic = new PersonLogic(repository);
            _paymentDetailLogic = new PaymentDetailLogic(repository);
            _personCompanyLogic = new PersonCompanyLogic(repository);
            _soldStockLogic = new SoldStockLogic(repository);
            _stockPurchaseBatchLogic = new StockPurchaseBatchLogic(repository);
        }

        public decimal GetMonthlySalesDiscount(int year, int month)
        {
            try
            {
                Expression<Func<SOLD_STOCK_BATCH, bool>> selector = ssb => ssb.Date_Sold.Year == year && ssb.Date_Sold.Month == month && ssb.Total_Discount > 0;
                return GetSalesDiscountHelper(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public decimal GetYearlySalesDiscount(int year)
        {
            try
            {
                Expression<Func<SOLD_STOCK_BATCH, bool>> selector = ssb => ssb.Date_Sold.Year == year && ssb.Total_Discount > 0;
                return GetSalesDiscountHelper(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private decimal GetSalesDiscountHelper(Expression<Func<SOLD_STOCK_BATCH, bool>> selector)
        {
            try
            {
                List<SoldStockBatch> soldStockBatches = base.GetModelsBy(selector);
                if (soldStockBatches != null)
                {
                    List<SoldStockBatch> soldStocks = (from ss in soldStockBatches
                                                       select new SoldStockBatch
                                                       {
                                                           Id = ss.Id,
                                                           TotalDiscount = ss.TotalDiscount,
                                                       }).ToList();
                }

                decimal totalDiscount = 0;
                if (soldStockBatches != null)
                {
                    totalDiscount = soldStockBatches.Sum(s => s.TotalDiscount);
                }

                return totalDiscount;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<SoldStockBatch> GetBy(string invoiceNo)
        {
            try
            {
                Expression<Func<SOLD_STOCK_BATCH, bool>> selector = ssb => ssb.PAYMENT.Invoice_Number == invoiceNo;
                return GetModelsBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<SoldStockBatch> GetByDateRange(DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                DateTime endDate = Range.Get(DateRange.End, dateTo);
                DateTime startDate = Range.Get(DateRange.Start, dateFrom);

                Expression<Func<SOLD_STOCK_BATCH, bool>> selector = osb => osb.Date_Sold >= startDate && osb.Date_Sold <= endDate;
                return GetModelsBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DateTime GetSoldDate(bool isMinimum)
        {
            const int TOP_ONE = 1;

            try
            {
                SoldStockBatch soldStockBatch = null;
                Expression<Func<SOLD_STOCK_BATCH, bool>> selector = osb => osb.Sold_Stock_Batch_Id > 0;
                Func<IQueryable<SOLD_STOCK_BATCH>, IOrderedQueryable<SOLD_STOCK_BATCH>> orderByDateSold = null;

                if (isMinimum)
                {
                    orderByDateSold = s => s.OrderBy(x => x.Date_Sold);
                }
                else
                {
                    orderByDateSold = s => s.OrderByDescending(x => x.Date_Sold);
                }

                List<SoldStockBatch> salesBatch = base.GetTopBy(TOP_ONE, selector, orderByDateSold);

                if (salesBatch != null)
                {
                    soldStockBatch = salesBatch.FirstOrDefault();
                }

                return soldStockBatch != null ? soldStockBatch.DateSold : DateTime.MinValue;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override List<SoldStockBatch> GetAll()
        {
            const int TOP_HUNDRED = 100;

            try
            {
                Expression<Func<SOLD_STOCK_BATCH, bool>> selector = osb => osb.Sold_Stock_Batch_Id > 0;
                Func<IQueryable<SOLD_STOCK_BATCH>, IOrderedQueryable<SOLD_STOCK_BATCH>> orderByDateSold = s => s.OrderByDescending(x => x.Date_Sold);

                return base.GetTopBy(TOP_HUNDRED, selector, orderByDateSold);


                //List<SoldStockBatch> soldStockBatches = null;
                //List<SoldStockBatch> salesBatch = base.GetModelsBy(selector, orderByDateSold);
                //if (salesBatch != null && salesBatch.Count > 0)
                //{
                //    soldStockBatches = salesBatch.Take(100).ToList();
                //}

                //return soldStockBatches;


                //List<SoldStockBatch> soldStockBatches = null;
                //List<SoldStockBatch> salesBatch = base.GetAll();
                //if (salesBatch != null && salesBatch.Count > 0)
                //{
                //    soldStockBatches = salesBatch.OrderByDescending(ssb => ssb.DateSold).Take(100).ToList();
                //}

                //return soldStockBatches;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<SalesInvoice> GetSalesInvoiceBy(SoldStockBatch soldStockBatch)
        {
            List<SalesInvoice> salesInvoice = null;

            try
            {
                string query = "SELECT * FROM VW_SALES_INVOICE where Sold_Stock_Batch_Id = " + soldStockBatch.Id;
                salesInvoice = (from si in repository.DbContext.Database.SqlQuery<VW_SALES_INVOICE>(query)
                                                   select new SalesInvoice
                                                           {
                                                               SoldStockBatchId = si.Sold_Stock_Batch_Id,
                                                               StockName = si.Stock_Name,
                                                               PackageName = si.Package_Name,
                                                               Discount = si.Discount,
                                                               TotalDiscount = si.Total_Discount > 0 ? (decimal)si.Total_Discount : 0,
                                                               //UnitPrice = si.Unit_Price,
                                                               SellingPrice = si.Selling_Price,
                                                               Quantity = (int)si.Quantity,
                                                               DateSold = si.Date_Sold,
                                                               AmountPaid = si.Amount_Paid,
                                                               CashierName = si.Seller,
                                                               Customer = si.Customer,
                                                               InvoiceNumber = si.Invoice_Number,
                                                           }).ToList();

                NumberToWordConverter numberToWord = new NumberToWordConverter();
                foreach (SalesInvoice saleInvoice in salesInvoice)
                {
                    saleInvoice.AmountPaidInWord = numberToWord.Convert(saleInvoice.AmountPaid.ToString());
                    salesInvoice.Add(saleInvoice);
                }


                //List<SalesInvoice> salesInvoices = new List<SalesInvoice>();
                //foreach (VW_SALES_INVOICE salesInvoiceEntity in salesInvoiceEntities)
                //{
                //    SalesInvoice salesInvoice = new SalesInvoice();
                //    salesInvoice.SoldStockBatchId = salesInvoiceEntity.Sold_Stock_Batch_Id;
                //    salesInvoice.StockName = salesInvoiceEntity.Stock_Name;
                //    salesInvoice.PackageName = salesInvoiceEntity.Package_Name;
                //    salesInvoice.Discount = salesInvoiceEntity.Discount != null ? (decimal)salesInvoiceEntity.Discount : 0;
                //    salesInvoice.TotalDiscount = salesInvoiceEntity.Total_Discount > 0 ? (decimal)salesInvoiceEntity.Total_Discount : 0;
                //    salesInvoice.UnitPrice = salesInvoiceEntity.Unit_Price;
                //    salesInvoice.SellingPrice = salesInvoiceEntity.Actual_Selling_Price;
                //    salesInvoice.Quantity = salesInvoiceEntity.Quantity;
                //    salesInvoice.DateSold = salesInvoiceEntity.Date_Sold;

                //    //if (salesInvoiceEntity.Seller_Id > 0)
                //    //{
                //    //    PersonCompany personCompany = personCompanyLogic.Get(salesInvoiceEntity.Seller_Id);
                //    //    if (personCompany != null)
                //    //    {
                //    //        salesInvoice.CashierName = personCompany.Person.Name;
                //    //        salesInvoice.CashierCompany = personCompany.Company.Name;
                //    //        salesInvoice.CashierCompanyAddress = personCompany.Company.Address;
                //    //        salesInvoice.CashierCompanyEmail = personCompany.Company.Email;
                //    //        salesInvoice.CashierCompanyPhone = personCompany.Company.Phone;
                //    //        salesInvoice.CashierCompanyWebsite = personCompany.Company.Website;
                //    //    }
                //    //}

                //    //if (salesInvoiceEntity.Customer_Id != null)
                //    //{
                //    //    Person customer = personLogic.GetBy((int)salesInvoiceEntity.Customer_Id);
                //    //    salesInvoice.Customer = customer != null ? customer.FullName : "";
                //    //    salesInvoice.Address = customer != null ? customer.ContactAddress : null;
                //    //}

                //    List<PaymentDetail> paymentDetails = paymentDetailLogic.GetPaymenDetailsByPaymentId(salesInvoiceEntity.Payment_Id);
                //    salesInvoice.AmountPaid = paymentDetails != null ? paymentDetails.Sum(pd => pd.AmountPaid) : 0;
                //    salesInvoice.AmountPaidInWord = numberToWords.Convert(salesInvoice.AmountPaid.ToString());
                //    salesInvoices.Add(salesInvoice);
                //}

                
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return salesInvoice;
        }




        //public bool Modify(Payment payment, SoldStockBatch soldStockBatch)
        //{
        //    try
        //    {
        //        if (soldStockBatch != null)
        //        {
        //            Expression<Func<SOLD_STOCK_BATCH, bool>> predicate = ssb => ssb.Sold_Stock_Batch_Id == soldStockBatch.Id;
        //            SOLD_STOCK_BATCH soldStockBatchEntity = GetEntityBy(predicate);

        //            if (soldStockBatch.Customer != null)
        //            {
        //                soldStockBatchEntity.Customer_Id = soldStockBatch.Customer.Id;
        //            }
        //            else
        //            {
        //                soldStockBatchEntity.Customer_Id = null;
        //            }
        //        }

        //        bool done = false;
        //        using (TransactionScope transaction = new TransactionScope())
        //        {
        //            int rowAffected = repository.Save();
        //            if (rowAffected > 0)
        //            {
        //                if (payment != null && payment.Details != null)
        //                {
        //                    done = paymentLogic.Modify(payment);
        //                    if (done)
        //                    {
        //                        transaction.Complete();
        //                    }
        //                }
        //            }
        //        }

        //        return done;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public bool Modify(SoldStockBatch soldStockBatch)
        {
            try
            {
                if (soldStockBatch == null || soldStockBatch.Id <= 0)
                {
                    throw new Exception("Sold Stock Batch cannot be null! Please try again.");
                }

                if (soldStockBatch.Payment == null || soldStockBatch.Payment.Id <= 0 || soldStockBatch.Payment.Details == null || soldStockBatch.Payment.Details.Count <= 0)
                {
                    throw new Exception("Payment or Payment Details cannot be empty!");
                }

                SOLD_STOCK_BATCH soldStockBatchEntity = GetEntityBy(ssb => ssb.Sold_Stock_Batch_Id == soldStockBatch.Id);
                if (soldStockBatch.Customer != null)
                {
                    soldStockBatchEntity.Customer_Id = soldStockBatch.Customer.Id;
                }
                else
                {
                    soldStockBatchEntity.Customer_Id = null;
                }

                bool modified = false;
                base.OpenDatabaseConnectionIfClosed();
                using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    repository.Save();

                    _soldStockLogic.repository = repository;
                    bool removed = _soldStockLogic.Remove(soldStockBatch.SoldStocks);
                    if (removed == false)
                    {
                        throw new Exception("Sold Stock modification failed! Please try again.");
                    }
                   
                    _paymentLogic.repository = repository;
                    modified = _paymentLogic.Modify(soldStockBatch.Payment);
                    if (modified)
                    {
                        transaction.Commit();
                        repository.DbContext.Database.Connection.Close();
                    }
                }

                return modified;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public bool Modify(SoldStockBatch soldStockBatch)
        //{
        //    try
        //    {
        //        if (soldStockBatch == null || soldStockBatch.Id <= 0)
        //        {
        //            throw new Exception("Sold Stock Batch cannot be null! Please try again.");
        //        }

        //        if (soldStockBatch.Payment == null || soldStockBatch.Payment.Id <= 0 || soldStockBatch.Payment.Details == null || soldStockBatch.Payment.Details.Count <= 0)
        //        {
        //            throw new Exception("Payment or Payment Details cannot be empty!");
        //        }

        //        SOLD_STOCK_BATCH soldStockBatchEntity = GetEntityBy(ssb => ssb.Sold_Stock_Batch_Id == soldStockBatch.Id);
        //        if (soldStockBatch.Customer != null)
        //        {
        //            soldStockBatchEntity.Customer_Id = soldStockBatch.Customer.Id;
        //        }
        //        else
        //        {
        //            soldStockBatchEntity.Customer_Id = null;
        //        }

        //        bool modified = false;
        //        using (TransactionScope transaction = new TransactionScope())
        //        {
        //            repository.Save();

        //            if (soldStockLogic.Remove(soldStockBatch.SoldStocks))
        //            {
        //                modified = paymentLogic.Modify(soldStockBatch.Payment);
        //                if (modified)
        //                {
        //                    transaction.Complete();
        //                }
        //            }
        //            else
        //            {
        //                throw new Exception("Sold Stock modification failed! Please try again.");
        //            }
        //        }

        //        return modified;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public override SoldStockBatch Add(SoldStockBatch soldStockBatch)
        {
            SoldStockBatch newSoldStockBatch = null;

            try
            {
                _paymentLogic.repository = repository;
                Payment payment = _paymentLogic.Add(soldStockBatch.Payment);
                if (payment == null || payment.Id <= 0)
                {
                    throw new Exception("Payment information save operation failed! " + TryAgain);
                }

                soldStockBatch.Payment = payment;
                newSoldStockBatch = base.Add(soldStockBatch);
                if (newSoldStockBatch == null || newSoldStockBatch.Id <= 0)
                {
                    throw new Exception("Sold stock batch information save operation failed! " + TryAgain);
                }

                return newSoldStockBatch;
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

        public SoldStockBatch SellStock(SoldStockBatch soldStockBatch)
        {
            try
            {
                DateTime minimumPurchaseDate = _stockPurchaseBatchLogic.GetPurchaseDate(true);
                if (soldStockBatch.DateSold < minimumPurchaseDate)
                {
                    throw new Exception("Sold date entered '" + soldStockBatch.DateSold.ToLongDateString() + "' cannot be less than the minimum purchase date '" + minimumPurchaseDate.ToLongDateString() + ". Kindly modify your sold date to continue");
                }

                if (soldStockBatch != null && (soldStockBatch.SoldStocks != null && soldStockBatch.SoldStocks.Count() > 0))
                {
                    base.OpenDatabaseConnectionIfClosed();
                    using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                    {
                        SoldStockBatch newSoldStockBatch = this.Add(soldStockBatch);
                        if (newSoldStockBatch == null || newSoldStockBatch.Id <= 0)
                        {
                            throw new Exception("Creation of sales header information failed! " + TryAgain);
                        }

                        _shelfLogic.repository = repository;
                        List<SoldStock> stocksforSale = new List<SoldStock>();
                        foreach (SoldStock stockforSale in soldStockBatch.SoldStocks)
                        {
                            List<Shelf> shelfStocks = new List<Shelf>();
                            Expression<Func<SHELF, bool>> selector = s => s.Stock_Package_Id == stockforSale.ShelfStock.StockPackage.Id && s.Stock_Package_Relationship_Id == stockforSale.ShelfStock.StockPackageRelationship.Id && s.Sold == false;
                            
                            shelfStocks = _shelfLogic.GetTopBy((int)stockforSale.Quantity, selector);
                            if (shelfStocks == null || shelfStocks.Count <= 0 || shelfStocks.Count != stockforSale.Quantity)
                            {
                                throw new Exception(shelfStocks.Count + " " + stockforSale.ShelfStock.StockPackage.Package.Name + " of " + stockforSale.ShelfStock.StockPackage.Stock.Name + " remaining on shelf is not enough to service the current request.");
                            }

                            foreach (Shelf shelfStock in shelfStocks)
                            {
                                //bool sold = _shelfLogic.SellStock(shelfStock);
                                //if (sold == false)
                                //{
                                //    throw new Exception("Marking shelf stock as sold failed! " + TryAgain);
                                //}

                                SoldStock soldStock = new SoldStock();
                                soldStock.ShelfStock = shelfStock;
                                soldStock.Price = stockforSale.Price;
                                soldStock.Discount = 0;
                                soldStock.Quantity = 1;
                                soldStock.Returned = false;
                                soldStock.Batch = newSoldStockBatch;

                                stocksforSale.Add(soldStock);
                            }
                        }

                        _soldStockLogic.repository = repository;
                        _soldStockLogic.Add(stocksforSale);

                        base.CommitTransaction(transaction);

                        newSoldStockBatch.SoldStocks = soldStockBatch.SoldStocks;
                        return newSoldStockBatch;
                    }
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(SoldStockBatch soldStockBatch)
        {
            IDbTransaction transaction = null;

            try
            {
                if (soldStockBatch == null || soldStockBatch.Id <= 0 || soldStockBatch.SoldStocks == null || soldStockBatch.SoldStocks.Count <= 0)
                {
                    throw new ArgumentNullException("soldStockBatch");
                }

                base.OpenDatabaseConnectionIfClosed();
                using (transaction = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    if (soldStockBatch.SoldStocks != null && soldStockBatch.SoldStocks.Count > 0)
                    {
                        _soldStockLogic.repository = repository;
                        _soldStockLogic.Remove(soldStockBatch.SoldStocks);
                    }

                    if (!RemoveHelper(soldStockBatch))
                    {
                        throw new Exception("Sold stock batch removal failed! Please try again");
                    }

                    _paymentLogic.repository = repository;
                    if (!_paymentLogic.Remove(soldStockBatch.Payment))
                    {
                        throw new Exception("Sold stock batch payment removal failed! Please try again");
                    }

                    base.CommitTransaction(transaction);

                    //transaction.Commit();
                    //repository.DbContext.Database.Connection.Close();
                    
                    return true;
                }
            }
            catch (Exception)
            {
                //base.RoolBackTransaction(transaction);
                throw;
            }
        }

        private bool RemoveHelper(SoldStockBatch soldStockBatch)
        {
            try
            {
                Expression<Func<SOLD_STOCK_BATCH, bool>> selector = outgoingBatch => outgoingBatch.Sold_Stock_Batch_Id == soldStockBatch.Id;
                return base.Remove(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SoldStockBatch LoadOutgoingBatchWithOutgoingStocksAndPayment(SoldStockBatch outgoingStockBatch)
        {
            try
            {
                Expression<Func<SOLD_STOCK, bool>> selector = outgoing => outgoing.Sold_Stock_Batch_Id == outgoingStockBatch.Id;
                outgoingStockBatch.SoldStocks = _soldStockLogic.GetModelsBy(selector);
                _paymentLogic.LoadBatchPaymentWithPaymentDetails(outgoingStockBatch.Payment);
                return outgoingStockBatch;
            }
            catch (Exception)
            {
                throw;
            }
        }

        





    }
}
