using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Transactions;

using Pokno.Entity;
using Pokno.Model;
using System.Linq.Expressions;
using Pokno.Model.Model;
using Pokno.Business.Helper;
using Pokno.Model.Views;
using Pokno.Business.Interfaces;

namespace Pokno.Business
{
    public class SoldStockLogic : BusinessLogicBase<SoldStock, SOLD_STOCK>
    {
        private StockLogic _stockLogic;
        private ShelfLogic _shelfLogic;
        private PackageLogic _packageLogic;
        private PersonLogic _personLogic;
        private PaymentLogic _paymentLogic;

        public SoldStockLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new SoldStockTranslator();
            _shelfLogic = new ShelfLogic(repository);
            _stockLogic = new StockLogic(repository);
            _packageLogic = new PackageLogic(repository);
            _personLogic = new PersonLogic(repository);
            _paymentLogic = new PaymentLogic(repository);
        }

        public override SoldStock Add(SoldStock stockForSale)
        {
            try
            {
                SoldStock soldStock = base.Add(stockForSale);
                if (soldStock == null || soldStock.Id <= 0)
                {
                    throw new Exception("Sold stock save operation failed!");
                }

                bool sold = _shelfLogic.SellStock(stockForSale.ShelfStock);
                if (sold == false)
                {
                    throw new Exception("Marking shelf stock as sold failed! " + TryAgain);
                }

                return soldStock;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public override int Add(List<SoldStock> stocksForSale)
        {
            try
            {
                foreach(SoldStock stockForSale in stocksForSale)
                {
                    Add(stockForSale);
                }

                return stocksForSale.Count;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public bool Return(SoldStock soldStock)
        {
            try
            {
                if (soldStock == null || soldStock.Id <= 0)
                {
                    throw new ArgumentNullException("soldStock");
                }

                Expression<Func<SOLD_STOCK, bool>> selector = os => os.Sold_Stock_Id == soldStock.Id;
                SOLD_STOCK entity = base.GetEntityBy(selector);
                if (entity == null || entity.Sold_Stock_Id <= 0)
                {
                    throw new Exception("Sold stock could not be marked as Returned! Please try again, but contact your system administrator after three unsuccessful trials.");
                }

                entity.Returned = true;

                return base.Save() > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public bool Modify(List<SoldStock> newStocksSold)
        //{
        //    try
        //    {
        //        if (newStocksSold != null && newStocksSold.Count > 0)
        //        {
        //            long batchId = newStocksSold[0].Batch.Id;
        //            Expression<Func<SOLD_STOCK, bool>> selector = os => os.Sold_Stock_Batch_Id == batchId;
        //            List<SoldStock> oldOutgoingStocks = GetModelsBy(selector);

        //            if (oldOutgoingStocks == null || oldOutgoingStocks.Count <= 0)
        //            {
        //                throw new Exception("No sold stock found in the system!");
        //            }

        //            List<SoldStock> outgoingStocksToRemove = new List<SoldStock>();
        //            foreach (SoldStock oldOutgoingStock in oldOutgoingStocks)
        //            {
        //                bool exist = false;
        //                foreach (SoldStock newOutgoingStock in newStocksSold)
        //                {
        //                    if (newOutgoingStock.Id == oldOutgoingStock.Id)
        //                    {
        //                        exist = true;
        //                        continue;
        //                    }
        //                }

        //                if (!exist)
        //                {
        //                    outgoingStocksToRemove.Add(oldOutgoingStock);
        //                }
        //            }

        //            bool done = true;
        //            if (outgoingStocksToRemove.Count > 0)
        //            {
        //                done = Remove(outgoingStocksToRemove);
        //            }

        //            return done;
        //        }
        //        else
        //        {
        //            throw new Exception("Items to modify cannot be empty!");
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

      
        public bool Remove(List<SoldStock> soldStocks)
        {
            try
            {
                if (soldStocks == null || soldStocks.Count <= 0)
                {
                    throw new ArgumentNullException("soldStocks");
                }

                List<Shelf> shelfs = new List<Shelf>();
                foreach (SoldStock shelfBoundStocks in soldStocks)
                {
                    Expression<Func<SOLD_STOCK, bool>> selector = os => os.Sold_Stock_Id == shelfBoundStocks.Id;
                    SOLD_STOCK entity = GetEntityBy(selector);
                    
                    base.Remove(selector);

                    shelfs.Add(shelfBoundStocks.ShelfStock);
                }

                if (shelfs.Count <= 0)
                {
                    throw new Exception("Stocks to be returned to the shelf could not be aggregated! " + TryAgain);
                }

                _shelfLogic.repository = repository;
                return _shelfLogic.ReturnStock(shelfs);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<SoldStock> GetByBatch(SoldStockBatch soldStockBatch)
        {
            try
            {
                Expression<Func<SOLD_STOCK, bool>> selector = os => os.Sold_Stock_Batch_Id == soldStockBatch.Id && os.Returned == false;
                return GetModelsBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<SoldStock> GetBy(string invoiceNo)
        {
            try
            {
                Expression<Func<SOLD_STOCK, bool>> selector = os => os.SOLD_STOCK_BATCH.PAYMENT.Invoice_Number == invoiceNo && os.Returned == false;
                return GetModelsBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Methods for report

        public List<SoldStockView> GetSoldStockByDateRange(DateTime startDate, DateTime endDate)
        {
            List<SoldStockView> soldStocks = null;

            try
            {
                endDate = Range.Get(DateRange.End, endDate);
                startDate = Range.Get(DateRange.Start, startDate);

                string query = "SELECT * FROM VW_SOLD_STOCK where Date_Sold >= '" + startDate.ToString(BusinessLogicUtility.DateTimeFormat) + "' AND Date_Sold <= '" + endDate.ToString(BusinessLogicUtility.DateTimeFormat) + "' ORDER BY Date_Sold";

                soldStocks = (from ss in repository.DbContext.Database.SqlQuery<VW_SOLD_STOCK>(query)
                              select new SoldStockView
                              {
                                  Quantity = (int)ss.Quantity,
                                  StockName = ss.Stock_Name,
                                  PackageName = ss.Package_Name,
                                  CustomerName = ss.Customer_Name,
                                  CostPrice = ss.Cost_Price.Value,
                                  SellingPrice = ss.Selling_Price.HasValue ? ss.Selling_Price.Value : (decimal)0,
                                  Discount = ss.Discount.HasValue ? ss.Discount.Value : (decimal)0,
                                  TotalDiscount = ss.Total_Discount,
                                  DateSold = ss.Date_Sold,
                                  Profit = ss.Profit.HasValue ? ss.Profit.Value : (decimal)0
                              }).ToList();

                              //}).OrderBy(s => s.DateSold).ToList();
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return soldStocks;
        }

        public List<SoldStockView> GetSoldStockDetailByDateRange(DateTime startDate, DateTime endDate)
        {
            List<SoldStockView> soldStock = null;

            try
            {
                endDate = Range.Get(DateRange.End, endDate);
                startDate = Range.Get(DateRange.Start, startDate);

                string query = "SELECT * FROM VW_SOLD_STOCK_DETAIL where Date_Sold >= '" + startDate.ToString(BusinessLogicUtility.DateTimeFormat) + "' AND Date_Sold <= '" + endDate.ToString(BusinessLogicUtility.DateTimeFormat) + "' ORDER BY Date_Sold";
                soldStock = (from ss in base.repository.DbContext.Database.SqlQuery<VW_SOLD_STOCK_DETAIL>(query)
                             select new SoldStockView
                             {
                                 BatchId = ss.Sold_Stock_Batch_Id,
                                 Quantity = ss.Quantity.HasValue ? ss.Quantity.Value : (int)0,
                                 StockId = ss.Stock_Id,
                                 StockName = ss.Stock_Name,
                                 PackageName = ss.Package_Name,
                                 CustomerName = ss.Customer_Name,
                                 CostPrice = ss.Cost_Price.HasValue ? ss.Cost_Price.Value : (decimal)0,
                                 SellingPrice = ss.Selling_Price.HasValue ? ss.Selling_Price.Value : (decimal)0,
                                 Discount = ss.Discount.HasValue ? ss.Discount.Value : (decimal)0,
                                 TotalDiscount = ss.Total_Discount.HasValue ? ss.Total_Discount.Value : (decimal)0,
                                 Profit = ss.Profit.HasValue ? ss.Profit.Value : (decimal)0,
                                 InvoiceNumber = ss.Invoice_Number,
                                 DateSold = ss.Date_Sold,
                             }).ToList();

                             //}).OrderBy(s => s.DateSold).ToList();
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return soldStock;
        }
        public List<SoldStockView> GetSoldStockDetailByDateRangeAndStock(DateTime startDate, DateTime endDate, Stock stock)
        {
            List<SoldStockView> soldStock = null;

            try
            {
                endDate = Range.Get(DateRange.End, endDate);
                startDate = Range.Get(DateRange.Start, startDate);

                string query = "SELECT * FROM VW_SOLD_STOCK_DETAIL where Date_Sold >= '" + startDate.ToString(BusinessLogicUtility.DateTimeFormat) + "' AND Date_Sold <= '" + endDate.ToString(BusinessLogicUtility.DateTimeFormat) + "' AND Stock_Id = " + stock.Id + " ORDER BY Date_Sold";

                soldStock = (from ss in base.repository.DbContext.Database.SqlQuery<VW_SOLD_STOCK_DETAIL>(query)
                             select new SoldStockView
                         {
                             BatchId = ss.Sold_Stock_Batch_Id,
                             Quantity = ss.Quantity.HasValue ? ss.Quantity.Value : (int)0,
                             StockId = ss.Stock_Id,
                             StockName = ss.Stock_Name,
                             PackageName = ss.Package_Name,
                             CustomerName = ss.Customer_Name,
                             CostPrice = ss.Cost_Price.HasValue ? ss.Cost_Price.Value : (decimal)0,
                             SellingPrice = ss.Selling_Price.HasValue ? ss.Selling_Price.Value : (decimal)0,
                             Discount = ss.Discount.HasValue ? ss.Discount.Value : (decimal)0,
                             TotalDiscount = ss.Total_Discount.HasValue ? ss.Total_Discount.Value : (decimal)0,
                             DateSold = ss.Date_Sold,
                             Profit = ss.Profit.HasValue ? ss.Profit.Value : (decimal)0
                         }).ToList();

                         //}).OrderBy(s => s.DateSold).ToList();

            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return soldStock;
        }



        #endregion

        public List<StoreSalesFrequency> GetSalesFrequencyBy(bool isTop5, int year, int month)
        {
            List<StoreSalesFrequency> sales = null;

            try
            {
                string currentMonth = BusinessLogicUtility.GetMonthString(month);

                string query = "SELECT * FROM VW_STOCK_SALES_FREQUENCY_SUMMARY_MONTHLY WHERE Year_Sold = '" + year + "' AND Month_Sold = '" + currentMonth + "' ORDER BY Frequency";
                query = isTop5 ? query += " DESC" : query += " ASC";

                sales = GetSalesFrequency(query);
                sales = GetSalesFrequencyByHelper(sales);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return sales;
        }

        public List<StoreSalesFrequency> GetSalesFrequencyBy(bool isTop5, DateTime fromDate, DateTime toDate)
        {
            List<StoreSalesFrequency> sales = null;

            try
            {
                string query = "SELECT Stock_Id, Stock, Stock_Name, Package_Id, Package_Name, SUM(frequency) AS Frequency, SUM(cost_price) AS Cost_Price";
                query += ", SUM(selling_price) AS Selling_Price, SUM(Profit) AS Profit, Month_Sold, Year_Sold FROM VW_STOCK_SALES_FREQUENCY WHERE Date(Date_Sold) BETWEEN '" + fromDate.ToString(BusinessLogicUtility.DateFormat) + "' AND '" + toDate.ToString(BusinessLogicUtility.DateFormat) + "' ";
                query += "GROUP BY Stock_Id, Stock, stock_name, package_id, package_name ORDER BY SUM(frequency)";

                //string query = "SELECT * FROM VW_STOCK_SALES_FREQUENCY_SUMMARY WHERE Year_Sold = '" + year + "' ORDER BY Frequency";
                query = isTop5 ? query += " DESC" : query += " ASC";

                sales = GetSalesFrequency(query);
                sales = GetSalesFrequencyByHelper(sales);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return sales;
        }
        public List<StoreSalesFrequency> GetSalesFrequencyBy(bool isTop5, int year)
        {
            List<StoreSalesFrequency> sales = null;

            try
            {
                string query = "SELECT Stock_Id, Stock, Stock_Name, Package_Id, Package_Name, SUM(frequency) AS Frequency, SUM(cost_price) AS Cost_Price,";
                query += " SUM(selling_price) AS Selling_Price, SUM(Profit) AS Profit, Month_Sold, Year_Sold FROM VW_STOCK_SALES_FREQUENCY WHERE Year_Sold = '" + year + "' ";
                query += "GROUP BY Stock_Id, Stock, stock_name, package_id, package_name ORDER BY SUM(frequency)";

                //string query = "SELECT * FROM VW_STOCK_SALES_FREQUENCY_SUMMARY WHERE Year_Sold = '" + year + "' ORDER BY Frequency";
                query = isTop5 ? query += " DESC" : query += " ASC";

                sales = GetSalesFrequency(query);
                sales = GetSalesFrequencyByHelper(sales);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return sales;
        }
        public List<StoreSalesFrequency> GetTopProfitableStockBy(bool isTop5, int year, int month)
        {
            List<StoreSalesFrequency> sales = null;

            try
            {
                string currentMonth = BusinessLogicUtility.GetMonthString(month);

                string query = "SELECT * FROM VW_STOCK_SALES_FREQUENCY_SUMMARY_MONTHLY WHERE Year_Sold = '" + year + "' AND Month_Sold = '" + currentMonth + "' ORDER BY Profit";
                query = isTop5 ? query += " DESC" : query += " ASC";

                sales = GetSalesFrequency(query);
                sales = GetTopProfitableStockByHelper(sales);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return sales;
        }
        public List<StoreSalesFrequency> GetTopProfitableStockBy(bool isTop5, DateTime fromDate, DateTime toDate)
        {
            List<StoreSalesFrequency> sales = null;

            try
            {
                string query = "SELECT Stock_Id, Stock, Stock_Name, Package_Id, Package_Name, SUM(frequency) AS Frequency, SUM(cost_price) AS Cost_Price";
                query += ", SUM(selling_price) AS Selling_Price, SUM(Profit) AS Profit, Month_Sold, Year_Sold FROM VW_STOCK_SALES_FREQUENCY WHERE Date(Date_Sold) BETWEEN '" + fromDate.ToString(BusinessLogicUtility.DateFormat) + "' AND '" + toDate.ToString(BusinessLogicUtility.DateFormat) + "' ";
                query += "GROUP BY Stock_Id, Stock, stock_name, package_id, package_name ORDER BY SUM(Profit)";


                //string query = "SELECT * FROM VW_STOCK_SALES_FREQUENCY_SUMMARY WHERE Year_Sold = '" + year + "' ORDER BY Profit";
                query = isTop5 ? query += " DESC" : query += " ASC";

                sales = GetSalesFrequency(query);
                sales = GetTopProfitableStockByHelper(sales);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return sales;
        }
        public List<StoreSalesFrequency> GetTopProfitableStockBy(bool isTop5, int year)
        {
            List<StoreSalesFrequency> sales = null;

            try
            {
                string query = "SELECT Stock_Id, Stock, Stock_Name, Package_Id, Package_Name, SUM(frequency) AS Frequency, SUM(cost_price) AS Cost_Price";
                query += ", SUM(selling_price) AS Selling_Price, SUM(Profit) AS Profit, Month_Sold, Year_Sold FROM VW_STOCK_SALES_FREQUENCY WHERE Year_Sold = '" + year + "' ";
                query += "GROUP BY Stock_Id, Stock, stock_name, package_id, package_name ORDER BY SUM(Profit)";


                //string query = "SELECT * FROM VW_STOCK_SALES_FREQUENCY_SUMMARY WHERE Year_Sold = '" + year + "' ORDER BY Profit";
                query = isTop5 ? query += " DESC" : query += " ASC";

                sales = GetSalesFrequency(query);
                sales = GetTopProfitableStockByHelper(sales);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return sales;
        }

        private List<StoreSalesFrequency> GetSalesFrequency(string query)
        {
            try
            {
                List<StoreSalesFrequency> sales = (from sf in repository.DbContext.Database.SqlQuery<VW_STOCK_SALES_FREQUENCY_SUMMARY>(query)
                                                   select new StoreSalesFrequency
                                                   {
                                                       StockId = sf.Stock_Id,
                                                       Stock = sf.Stock,
                                                       StockName = sf.Stock_Name,
                                                       PackageId = sf.Package_Id,
                                                       PackageName = sf.Package_Name,
                                                       Frequency = sf.Frequency,
                                                       CostPrice = sf.Cost_Price,
                                                       SellingPrice = sf.Selling_Price,
                                                       Profit = sf.Profit,
                                                       YearSold = sf.Year_Sold,
                                                       MonthSold = sf.Month_Sold,
                                                   }).ToList();

                return sales;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<StoreSalesFrequency> GetSalesFrequencyByHelper(List<StoreSalesFrequency> sales)
        {
            try
            {
                List<StoreSalesFrequency> top5Sales = null;
                if (sales != null && sales.Count > 0)
                {
                    top5Sales = sales.Take(5).ToList();
                    if (top5Sales != null && top5Sales.Count > 0)
                    {
                        StoreSalesFrequency salesFrequency = top5Sales.LastOrDefault();
                        List<StoreSalesFrequency> stockSales = sales.Skip(5).Where(s => s.Frequency == salesFrequency.Frequency).ToList();
                        if (stockSales != null && stockSales.Count > 0)
                        {
                            if (stockSales.Count >= 5)
                            {
                                stockSales = stockSales.Take(4).ToList();
                            }

                            top5Sales.AddRange(stockSales);
                        }
                    }

                    sales = top5Sales;
                }

                return sales;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private List<StoreSalesFrequency> GetTopProfitableStockByHelper(List<StoreSalesFrequency> sales)
        {
            try
            {
                List<StoreSalesFrequency> top5Sales = null;
                if (sales != null && sales.Count > 0)
                {
                    top5Sales = sales.Take(5).ToList();
                    if (top5Sales != null && top5Sales.Count > 0)
                    {
                        StoreSalesFrequency salesFrequency = top5Sales.LastOrDefault();
                        List<StoreSalesFrequency> stockSales = sales.Skip(5).Where(s => s.Profit == salesFrequency.Profit).ToList();
                        if (stockSales != null && stockSales.Count > 0)
                        {
                            if (top5Sales.Count >= 5)
                            {
                                top5Sales = top5Sales.Take(5).ToList();
                            }

                            top5Sales.AddRange(stockSales);
                        }
                    }

                    sales = top5Sales;
                }

                return sales;
            }
            catch (Exception)
            {
                throw;
            }
        }




      
        public List<StoreCustomerStatistics> GetCustomerTransactionFrequencyByDateRange(bool isTop5, DateTime fromDate, DateTime toDate)
        {
            List<StoreCustomerStatistics> transactions = null;

            try
            {
                string query = "SELECT Customer, SUM(frequency) AS Frequency, SUM(selling_price) AS Selling_Price, SUM(Profit) AS Profit, Month_Sold, Year_Sold ";
                query += "FROM VW_STOCK_SALES_FREQUENCY WHERE Date(Date_Sold) BETWEEN '" + fromDate.ToString(BusinessLogicUtility.DateFormat) + "' AND '" + toDate.ToString(BusinessLogicUtility.DateFormat) + "' AND REPLACE(Customer,' ','') <> '' ";
                query += "GROUP BY Customer ORDER BY SUM(Frequency)";

                //string query = "SELECT Customer, SUM(frequency) AS Frequency, SUM(selling_price) AS Selling_Price, SUM(Profit) AS Profit, Month_Sold, Year_Sold ";
                //query += "FROM VW_STOCK_SALES_FREQUENCY WHERE Date(Date_Sold) BETWEEN '2007-01-01' AND '2007-12-31' AND REPLACE(Customer,' ','') <> '' ";
                //query += "GROUP BY Customer ORDER BY SUM(Profit)";

                query = isTop5 ? query += " DESC" : query += " ASC";

                transactions = GetCustomerTransaction(query);
                transactions = GetTopCustomerTransactionFrequencyHelper(transactions);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return transactions;
        }
        public List<StoreCustomerStatistics> GetTopCustomerTransactionFrequencyBy(bool isTop5, int year)
        {
            List<StoreCustomerStatistics> transactions = null;

            try
            {
                string query = "SELECT Customer, SUM(frequency) AS Frequency, SUM(selling_price) AS Selling_Price, SUM(Profit) AS Profit, Month_Sold, Year_Sold ";
                query += "FROM VW_STOCK_SALES_FREQUENCY WHERE Year_Sold = '" + year.ToString() + "' AND REPLACE(Customer,' ','') <> '' ";
                query += "GROUP BY Customer ORDER BY SUM(Frequency)";

                //string query = "SELECT Customer, SUM(frequency) AS Frequency, SUM(selling_price) AS Selling_Price, SUM(Profit) AS Profit, Month_Sold, Year_Sold ";
                //query += "FROM VW_STOCK_SALES_FREQUENCY WHERE Date(Date_Sold) BETWEEN '2007-01-01' AND '2007-12-31' AND REPLACE(Customer,' ','') <> '' ";
                //query += "GROUP BY Customer ORDER BY SUM(Profit)";

                query = isTop5 ? query += " DESC" : query += " ASC";

                transactions = GetCustomerTransaction(query);
                transactions = GetTopCustomerTransactionFrequencyHelper(transactions);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return transactions;
        }
       
        public List<StoreCustomerStatistics> GetCustomerTransactionVolumeByDateRange(bool isTop5, DateTime fromDate, DateTime toDate)
        {
            List<StoreCustomerStatistics> transactions = null;

            try
            {
                string query = "SELECT Customer, SUM(frequency) AS Frequency, SUM(selling_price) AS Selling_Price, SUM(Profit) AS Profit, Month_Sold, Year_Sold ";
                query += "FROM VW_STOCK_SALES_FREQUENCY WHERE Date(Date_Sold) BETWEEN '" + fromDate.ToString(BusinessLogicUtility.DateFormat) + "' AND '" + toDate.ToString(BusinessLogicUtility.DateFormat) + "' AND REPLACE(Customer,' ','') <> '' ";
                query += "GROUP BY Customer ORDER BY SUM(Selling_Price)";



                //string query = "SELECT Customer, SUM(frequency) AS Frequency, SUM(selling_price) AS Selling_Price, SUM(Profit) AS Profit, Month_Sold, Year_Sold ";
                //query += "FROM VW_STOCK_SALES_FREQUENCY WHERE Year_Sold = '" + year.ToString() + "' AND REPLACE(Customer,' ','') <> '' ";
                //query += "GROUP BY Customer ORDER BY SUM(selling_price)";

                query = isTop5 ? query += " DESC" : query += " ASC";

                transactions = GetCustomerTransaction(query);
                transactions = GetTopCustomerTransactionVolumeByHelper(transactions);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return transactions;
        }
        public List<StoreCustomerStatistics> GetTopCustomerTransactionVolumeBy(bool isTop5, int year)
        {
            List<StoreCustomerStatistics> transactions = null;

            try
            {
                string query = "SELECT Customer, SUM(frequency) AS Frequency, SUM(selling_price) AS Selling_Price, SUM(Profit) AS Profit, Month_Sold, Year_Sold ";
                query += "FROM VW_STOCK_SALES_FREQUENCY WHERE Year_Sold = '" + year.ToString() + "' AND REPLACE(Customer,' ','') <> '' ";
                query += "GROUP BY Customer ORDER BY SUM(selling_price)";

                query = isTop5 ? query += " DESC" : query += " ASC";

                transactions = GetCustomerTransaction(query);
                transactions = GetTopCustomerTransactionVolumeByHelper(transactions);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return transactions;
        }

        public List<StoreCustomerStatistics> GetCustomerTransactionProfitByDateRange(bool isTop5, DateTime fromDate, DateTime toDate)
        {
            List<StoreCustomerStatistics> transactions = null;

            try
            {
                string query = "SELECT Customer, SUM(frequency) AS Frequency, SUM(selling_price) AS Selling_Price, SUM(Profit) AS Profit, Month_Sold, Year_Sold ";
                query += "FROM VW_STOCK_SALES_FREQUENCY WHERE Date(Date_Sold) BETWEEN '" + fromDate.ToString(BusinessLogicUtility.DateFormat) + "' AND '" + toDate.ToString(BusinessLogicUtility.DateFormat) + "' AND REPLACE(Customer,' ','') <> '' ";
                query += "GROUP BY Customer ORDER BY SUM(Profit)";



                //string query = "SELECT Customer, SUM(frequency) AS Frequency, SUM(selling_price) AS Selling_Price, SUM(Profit) AS Profit, Month_Sold, Year_Sold ";
                //query += "FROM VW_STOCK_SALES_FREQUENCY WHERE Year_Sold = '" + year.ToString() + "' AND REPLACE(Customer,' ','') <> '' ";
                //query += "GROUP BY Customer ORDER BY SUM(Profit)";

                query = isTop5 ? query += " DESC" : query += " ASC";

                transactions = GetCustomerTransaction(query);
                transactions = GetCustomerTransactionProfitByHelper(transactions);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return transactions;
        }
        public List<StoreCustomerStatistics> GetCustomerTransactionProfitBy(bool isTop5, int year)
        {
            List<StoreCustomerStatistics> transactions = null;

            try
            {
                string query = "SELECT Customer, SUM(frequency) AS Frequency, SUM(selling_price) AS Selling_Price, SUM(Profit) AS Profit, Month_Sold, Year_Sold ";
                query += "FROM VW_STOCK_SALES_FREQUENCY WHERE Year_Sold = '" + year.ToString() + "' AND REPLACE(Customer,' ','') <> '' ";
                query += "GROUP BY Customer ORDER BY SUM(Profit)";

                query = isTop5 ? query += " DESC" : query += " ASC";

                transactions = GetCustomerTransaction(query);
                transactions = GetCustomerTransactionProfitByHelper(transactions);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return transactions;
        }
        private List<StoreCustomerStatistics> GetCustomerTransaction(string query)
        {
            try
            {
                List<StoreCustomerStatistics> transactions = (from sf in repository.DbContext.Database.SqlQuery<VW_CUSTOMER_STATISTICS>(query)
                                                              select new StoreCustomerStatistics
                                                              {
                                                                  Customer = sf.Customer,
                                                                  Frequency = sf.Frequency,
                                                                  SellingPrice = sf.Selling_Price,
                                                                  Profit = sf.Profit,
                                                                  TransactionMonth = sf.Year_Sold,
                                                                  TransactionYear = sf.Month_Sold,
                                                              }).ToList();
                return transactions;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<StoreCustomerStatistics> GetTopCustomerTransactionFrequencyHelper(List<StoreCustomerStatistics> transactions)
        {
            try
            {
                List<StoreCustomerStatistics> top5Transactions = null;
                if (transactions != null && transactions.Count > 0)
                {
                    top5Transactions = transactions.Take(5).ToList();
                    if (top5Transactions != null && top5Transactions.Count > 0)
                    {
                        StoreCustomerStatistics transactionFrequency = top5Transactions.LastOrDefault();
                        List<StoreCustomerStatistics> saleTransactions = transactions.Skip(5).Where(s => s.Frequency == transactionFrequency.Frequency).ToList();
                        if (saleTransactions != null && saleTransactions.Count > 0)
                        {
                            if (saleTransactions.Count >= 5)
                            {
                                saleTransactions = saleTransactions.Take(4).ToList();
                            }

                            top5Transactions.AddRange(saleTransactions);
                        }
                    }

                    transactions = top5Transactions;
                }

                return transactions;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<StoreCustomerStatistics> GetTopCustomerTransactionVolumeByHelper(List<StoreCustomerStatistics> transactions)
        {
            try
            {
                List<StoreCustomerStatistics> top5Transactions = null;
                if (transactions != null && transactions.Count > 0)
                {
                    top5Transactions = transactions.Take(5).ToList();
                    if (top5Transactions != null && top5Transactions.Count > 0)
                    {
                        StoreCustomerStatistics salesTransaction = top5Transactions.LastOrDefault();
                        List<StoreCustomerStatistics> salesTransactions = transactions.Skip(5).Where(s => s.SellingPrice == salesTransaction.SellingPrice).ToList();
                        if (salesTransactions != null && salesTransactions.Count > 0)
                        {
                            if (salesTransactions.Count >= 5)
                            {
                                salesTransactions = salesTransactions.Take(4).ToList();
                            }

                            top5Transactions.AddRange(salesTransactions);
                        }
                    }

                    transactions = top5Transactions;
                }

                return transactions;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private List<StoreCustomerStatistics> GetCustomerTransactionProfitByHelper(List<StoreCustomerStatistics> transactions)
        {
            try
            {
                List<StoreCustomerStatistics> top5Transactions = null;
                if (transactions != null && transactions.Count > 0)
                {
                    top5Transactions = transactions.Take(5).ToList();
                    if (top5Transactions != null && top5Transactions.Count > 0)
                    {
                        StoreCustomerStatistics salesTransaction = top5Transactions.LastOrDefault();
                        List<StoreCustomerStatistics> salesTransactions = transactions.Skip(5).Where(s => s.Profit == salesTransaction.Profit).ToList();
                        if (salesTransactions != null && salesTransactions.Count > 0)
                        {
                            if (salesTransactions.Count >= 5)
                            {
                                salesTransactions = salesTransactions.Take(4).ToList();
                            }

                            top5Transactions.AddRange(salesTransactions);
                        }
                    }

                    transactions = top5Transactions;
                }

                return transactions;
            }
            catch (Exception)
            {
                throw;
            }
        }




        



    }
}
