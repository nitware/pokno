using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;
using Pokno.Model.Translator;
using Pokno.Business.Interfaces;
using System.Data;
using Pokno.Model;
using Pokno.Model.Views;

namespace Pokno.Business
{
    public class ReturnedStockLogic : BusinessLogicBase<ReturnedStock, RETURNED_STOCK>
    {
        private SoldStockLogic _soldStockLogic;
        private ReturnedStockDetailLogic _returnedStockDetailLogic;
        private ReturnedStockReplacementLogic _returnedStockReplacementLogic;
        private ShelfLogic _shelfLogic;

        public ReturnedStockLogic(IRepository repository) : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            translator = new ReturnedStockTranslator();
            _returnedStockDetailLogic = new ReturnedStockDetailLogic(repository);
            _returnedStockReplacementLogic = new ReturnedStockReplacementLogic(repository);
            _soldStockLogic = new SoldStockLogic(repository);
            _shelfLogic = new ShelfLogic(repository);
        }

        public override ReturnedStock Add(ReturnedStock returnedStock)
        {
            try
            {
                ReturnedStock newReturnedStock = null;
                if (returnedStock == null || returnedStock.Details == null || returnedStock.Details.Count <= 0)
                {
                    throw new ArgumentNullException("returnedStock");
                }

                base.OpenDatabaseConnectionIfClosed();
                using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    newReturnedStock = base.Add(returnedStock);
                    if (newReturnedStock == null || newReturnedStock.Id <= 0)
                    {
                        throw new Exception("Error occured during stock replacement.");
                    }

                    foreach (ReturnedStockDetail returnedStockDetail in returnedStock.Details)
                    {
                        _soldStockLogic.repository = repository;
                        returnedStockDetail.ReturnedStock = newReturnedStock;
                        bool stockSuccessfullyReturned = _soldStockLogic.Return(returnedStockDetail.SoldStock);
                        if (!stockSuccessfullyReturned)
                        {
                            throw new Exception("Marking sold stock as Returned, failed!");
                        }

                        _returnedStockDetailLogic.repository = repository;
                        ReturnedStockDetail newReturnedStockDetail = _returnedStockDetailLogic.Add(returnedStockDetail);
                        if (newReturnedStockDetail == null || newReturnedStockDetail.Id <= 0)
                        {
                            throw new Exception("Stock return process failed! " + TryAgain);
                        }

                        switch (returnedStockDetail.Action.Id)
                        {
                            case (int)StockReturnAction.Actions.Return:
                            case (int)StockReturnAction.Actions.Refund:
                                {
                                    //ReturnedStockDetail newReturnedStockDetail = _returnedStockDetailLogic.Add(returnedStockDetail);
                                    //if (newReturnedStockDetail == null || newReturnedStockDetail.Id <= 0)
                                    //{
                                    //    throw new Exception("Stock return process failed! " + TryAgain);
                                    //}

                                    bool restored = _shelfLogic.ReturnStock(returnedStockDetail.SoldStock.ShelfStock);
                                    if (restored == false)
                                    {
                                        throw new Exception("Putting back sold stock to shelf failed! " + TryAgain);
                                    }

                                    break;
                                }
                            case (int)StockReturnAction.Actions.Replace:
                                {
                                    //ReturnedStockDetail newReturnedStockDetail = _returnedStockDetailLogic.Add(returnedStockDetail);
                                    //if (newReturnedStockDetail == null || newReturnedStockDetail.Id <= 0)
                                    //{
                                    //    throw new Exception("Stock return process failed! " + TryAgain);
                                    //}

                                    returnedStockDetail.Id = newReturnedStockDetail.Id;
                                    Shelf stockOnShelf = _shelfLogic.GetUnsoldStockBy(returnedStockDetail.SoldStock.ShelfStock.StockPackage);
                              
                                    SoldStock soldStock = new SoldStock();
                                    soldStock.ShelfStock = stockOnShelf;
                                    soldStock.Price = returnedStockDetail.SoldStock.Price;
                                    soldStock.Batch = returnedStockDetail.SoldStock.Batch;
                                    soldStock.Quantity = returnedStockDetail.SoldStock.Quantity;
                                    soldStock.Discount = returnedStockDetail.SoldStock.Discount;
                                    soldStock.Returned = false;

                                    SoldStock soldStockReplacement = _soldStockLogic.Add(soldStock);
                                    if (soldStockReplacement == null || soldStockReplacement.Id <= 0)
                                    {
                                        throw new Exception("Sold stock replacement failed! " + TryAgain);
                                    }

                                    //bool sold = _shelfLogic.SellStock(stockOnShelf);
                                    //if (sold == false)
                                    //{
                                    //    throw new Exception("Marking shelf stock as sold failed! " + TryAgain);
                                    //}

                                    ReturnedStockReplacement stockReplacement = new ReturnedStockReplacement();
                                    stockReplacement.SoldStockReplacement = soldStockReplacement;
                                    stockReplacement.ReturnedDetail = returnedStockDetail;
                                    
                                    _returnedStockReplacementLogic.repository = repository;
                                    ReturnedStockReplacement newReturnedStockReplacement = _returnedStockReplacementLogic.Add(stockReplacement);
                                    if (newReturnedStockReplacement == null || newReturnedStockReplacement.Id <= 0)
                                    {
                                        throw new Exception("Sold stock replacement failed! " + TryAgain);
                                    }

                                    break;
                                }
                        }
                    }

                    base.CommitTransaction(transaction);

                    //transaction.Commit();
                    //repository.DbContext.Database.Connection.Close();
                }

                return newReturnedStock;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StoreReturnStock> GetReturnedStockBy(int year)
        {
            List<StoreReturnStock> returnedStocks = null;

            try
            {

                string query = "SELECT * FROM VW_RETURNED_STOCK WHERE Year = '" + year + "'";
                returnedStocks = GetReturnedStockByHelper(query);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return returnedStocks;
        }
        public List<StoreReturnStock> GetReturnedStockBy(DateTime fromDate, DateTime toDate)
        {
            List<StoreReturnStock> returnedStocks = null;

            try
            {

                string query = "SELECT * FROM VW_RETURNED_STOCK WHERE Date(Date) BETWEEN '" + fromDate.ToString(BusinessLogicUtility.DateFormat) + "' AND '" + toDate.ToString(BusinessLogicUtility.DateFormat) + "'";
                returnedStocks = GetReturnedStockByHelper(query);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return returnedStocks;
        }
        private List<StoreReturnStock> GetReturnedStockByHelper(string query)
        {
            try
            {
                List<StoreReturnStock> returnedStocks = (from ps in repository.DbContext.Database.SqlQuery<VW_RETURNED_STOCK>(query)
                                                         select new StoreReturnStock
                                                         {
                                                             Stock = ps.Stock,
                                                             Type = ps.Type,
                                                             Quantity = (int)ps.Returned_Quantity,
                                                             Month = ps.Month,
                                                             Year = ps.Year,
                                                             StockName = ps.Stock_Name,
                                                             PackageName = ps.Package_Name,
                                                             StockState = ps.Stock_State,
                                                             AmountRefunded = ps.Amount_Refunded,
                                                             Action = ps.Action,
                                                             Reason = ps.Reason,
                                                             Date = ps.Date,
                                                             Initiator = ps.Initiator,
                                                         }).ToList();

                return returnedStocks;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StoreReturnStock> GetReturnedStockBy(bool isTop5, int year, int month)
        {
            List<StoreReturnStock> returnedStocks = null;

            try
            {
                string currentMonth = BusinessLogicUtility.GetMonthString(month);

                string query = "SELECT * FROM VW_TOP_RETURNED_STOCK WHERE Year = '" + year + "' AND Month = '" + currentMonth  + "' ORDER BY Returned_Quantity";
                query = isTop5 ? query += " DESC" : query += " ASC";

                returnedStocks = GetTopReturnedStock(query);
                returnedStocks = GetReturnedStockByHelper(returnedStocks);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return returnedStocks;
        }

        

        public List<StoreReturnStock> GetReturnedStockBy(bool isTop5, DateTime fromDate, DateTime toDate)
        {
            List<StoreReturnStock> returnedStocks = null;

            try
            {
                string query = "SELECT Stock, Type, SUM(Returned_Quantity) AS Returned_Quantity, Month, Year FROM VW_RETURNED_STOCK ";
                query += "WHERE Type in ('Sold Stock Return', 'Purchased Stock Return') AND Date(Date) BETWEEN '" + fromDate.ToString(BusinessLogicUtility.DateFormat) + "' AND '" + toDate.ToString(BusinessLogicUtility.DateFormat) + "' GROUP BY Stock, Month, Year ORDER BY Returned_Quantity";


                //string query = "SELECT * FROM VW_TOP_RETURNED_STOCK WHERE Year = '" + year + "' ORDER BY Returned_Quantity";
                query = isTop5 ? query += " DESC" : query += " ASC";

                returnedStocks = GetTopReturnedStock(query);
                returnedStocks = GetReturnedStockByHelper(returnedStocks);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return returnedStocks;
        }
        public List<StoreReturnStock> GetReturnedStockBy(bool isTop5, int year)
        {
            List<StoreReturnStock> returnedStocks = null;

            try
            {
                string query = "SELECT * FROM VW_TOP_RETURNED_STOCK WHERE Year = '" + year + "' ORDER BY Returned_Quantity";
                query = isTop5 ? query += " DESC" : query += " ASC";

                returnedStocks = GetTopReturnedStock(query);
                returnedStocks = GetReturnedStockByHelper(returnedStocks);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return returnedStocks;
        }

        private List<StoreReturnStock> GetTopReturnedStock(string query)
        {
            try
            {
                List<StoreReturnStock> returnedStocks = (from ps in repository.DbContext.Database.SqlQuery<VW_TOP_RETURNED_STOCK>(query)
                                  select new StoreReturnStock
                                  {
                                      Stock = ps.Stock,
                                      Type = ps.Type,
                                      Quantity = (int)ps.Returned_Quantity,
                                      Month = ps.Month,
                                      Year = ps.Year,
                                  }).ToList();

                return returnedStocks;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private List<StoreReturnStock> GetReturnedStockByHelper(List<StoreReturnStock> returnedStocks)
        {
            try
            {
                List<StoreReturnStock> top5Stocks = null;
                if (returnedStocks != null && returnedStocks.Count > 0)
                {
                    top5Stocks = returnedStocks.Take(5).ToList();
                    if (top5Stocks != null && top5Stocks.Count > 0)
                    {
                        StoreReturnStock returnedStock = top5Stocks.LastOrDefault();
                        List<StoreReturnStock> orderReturnedStocks = returnedStocks.Skip(5).Where(s => s.Quantity == returnedStock.Quantity).ToList();
                        if (orderReturnedStocks != null && orderReturnedStocks.Count > 0)
                        {
                            if (orderReturnedStocks.Count >= 5)
                            {
                                orderReturnedStocks = orderReturnedStocks.Take(5).ToList();
                            }

                            top5Stocks.AddRange(orderReturnedStocks);
                        }
                    }

                    returnedStocks = top5Stocks;
                }

                return returnedStocks;
            }
            catch (Exception)
            {
                throw;
            }
        }




    }

}
