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
using Pokno.Model.Views;
using Pokno.Business.Interfaces;
using System.Data.Entity.Core;

namespace Pokno.Business
{
    public class StockPriceLogic : BusinessLogicBase<StockPrice, STOCK_PRICE>
    {
        private StockPackageLogic stockPackageLogic;
        private CurrentStockPriceLogic currentPriceLogic;
        
        public StockPriceLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new StockPriceTranslator();
            currentPriceLogic = new CurrentStockPriceLogic(repository);
            stockPackageLogic = new StockPackageLogic(repository);
        }

        public StockPrice Get(long id)
        {
            try
            {
                Expression<Func<STOCK_PRICE, bool>> selector = s => s.Stock_Price_Id == id;
                return base.GetModelBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public StockPrice Get(DateTime dateEntered, StockPackage stockPackage)
        {
            try
            {
                Func<IQueryable<STOCK_PRICE>, IOrderedQueryable<STOCK_PRICE>> orderBy = s => s.OrderBy(sp => sp.Date_Entered);
                Expression<Func<STOCK_PRICE, bool>> selector = s => dateEntered >= s.Date_Entered && s.Stock_Package_Id == stockPackage.Id;
                List<StockPrice> stockPrices = base.GetModelsBy(selector, orderBy);

                StockPrice stockPrice = null;
                if (stockPrices != null && stockPrices.Count > 0)
                {
                    stockPrice = stockPrices.LastOrDefault();
                }
                else
                {
                    selector = s => s.Stock_Package_Id == stockPackage.Id;
                    stockPrices = base.GetModelsBy(selector, orderBy);
                    stockPrice = stockPrices.FirstOrDefault();
                }

                return stockPrice;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StoreStockPrice> Get()
        {
            List<StoreStockPrice> storeStockPrices = null;

            try
            {
                string query = "SELECT * FROM VW_CURRENT_STOCK_PRICE ORDER BY Stock_Name";
                List<VW_CURRENT_STOCK_PRICE> currentStockPriceEntities = repository.DbContext.Database.SqlQuery<VW_CURRENT_STOCK_PRICE>(query).ToList();

                storeStockPrices = new List<StoreStockPrice>();
                foreach (VW_CURRENT_STOCK_PRICE currentStockPriceEntity in currentStockPriceEntities)
                {
                    StockPrice stockPrice = this.Get(currentStockPriceEntity.Stock_Price_Id);
                    StockPackage stockPackage = stockPackageLogic.Get(currentStockPriceEntity.Stock_Package_Id);

                    StoreStockPrice storeStockPrice = new StoreStockPrice();
                    storeStockPrice.StockName = stockPackage.Stock.Name;
                    storeStockPrice.PackageName = stockPackage.Package.Name;
                    storeStockPrice.CostPrice = Math.Round(stockPrice.CostPrice, 2);
                    storeStockPrice.SellingPrice = Math.Round(stockPrice.SellingPrice, 2);

                    storeStockPrices.Add(storeStockPrice);
                }
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return storeStockPrices;
        }

        public List<StoreStockPrice> GetHistory()
        {
            try
            {
                Expression<Func<STOCK_PRICE, bool>> selector = s => s.Stock_Price_Id > 0;
                Func<IQueryable<STOCK_PRICE>, IOrderedQueryable<STOCK_PRICE>> orderBy = s => s.OrderByDescending(sp => sp.Date_Entered);
                List<StockPrice> stockPrices = base.GetModelsBy(selector, orderBy);

                List<StoreStockPrice> storeStockPrices = null;
                if (stockPrices != null && stockPrices.Count > 0)
                {
                    storeStockPrices = new List<StoreStockPrice>();
                    foreach (StockPrice stockPrice in stockPrices)
                    {
                        StoreStockPrice storeStockPrice = new StoreStockPrice();
                        storeStockPrice.StockName = stockPrice.StockPackage.Stock.Name;
                        storeStockPrice.PackageName = stockPrice.StockPackage.Package.Name;
                        storeStockPrice.CostPrice = Math.Round(stockPrice.CostPrice, 2);
                        storeStockPrice.SellingPrice = Math.Round(stockPrice.SellingPrice, 2);
                        storeStockPrice.DateEntered = stockPrice.DateEntered;

                        storeStockPrices.Add(storeStockPrice);
                    }
                }

                return storeStockPrices;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StoreStockPrice> GetHistory(Stock stock)
        {
            List<StoreStockPrice> storeStockPrices = null;

            try
            {
                string query = "SELECT * FROM VW_STOCK_PRICE where Stock_Id = " + stock.Id;
                List<VW_STOCK_PRICE> currentStockPriceEntities = repository.DbContext.Database.SqlQuery<VW_STOCK_PRICE>(query).ToList();
                
                storeStockPrices = (from vcsp in repository.DbContext.Database.SqlQuery<VW_STOCK_PRICE>(query)
                                                          select new StoreStockPrice
                                                          {
                                                              StockName = vcsp.Stock_Name,
                                                              PackageName = vcsp.Package_Name,
                                                              CostPrice = Math.Round(vcsp.Cost_Price, 2),
                                                              SellingPrice = Math.Round(vcsp.Selling_Price, 2),
                                                              DateEntered = vcsp.Date_Entered
                                                          }).OrderByDescending(d => d.DateEntered).ToList();
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return storeStockPrices;
        }

        public override List<StockPrice> GetAll()
        {
            List<StockPrice> stockPrices = null;

            try
            {
                string query = "SELECT * FROM VW_CURRENT_STOCK_PRICE where Stock_Price_Id > 0";
                List<VW_CURRENT_STOCK_PRICE> stockPriceEntities = repository.DbContext.Database.SqlQuery<VW_CURRENT_STOCK_PRICE>(query).ToList();
                stockPrices = ConvertToStockPriceModel(stockPriceEntities);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return stockPrices;
        }

        private List<StockPrice> ConvertToStockPriceModel(List<STOCK_PRICE> stockPriceEntities)
        {
            try
            {
                List<StockPrice> stockPrices = new List<StockPrice>();
                foreach (STOCK_PRICE stockPriceEntity in stockPriceEntities)
                {
                    StockPrice stockPrice = new StockPrice();
                    stockPrice.Id = stockPriceEntity.Stock_Price_Id;
                    stockPrice.StockPackage = stockPackageLogic.Get(stockPriceEntity.Stock_Package_Id);
                    stockPrice.CostPrice = stockPriceEntity.Cost_Price;
                    stockPrice.SellingPrice = stockPriceEntity.Selling_Price;
                    stockPrice.DateEntered = stockPriceEntity.Date_Entered;

                    stockPrices.Add(stockPrice);
                }

                return stockPrices;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<StockPrice> ConvertToStockPriceModel(List<VW_CURRENT_STOCK_PRICE> stockPriceEntities)
        {
            try
            {
                List<StockPrice> stockPrices = new List<StockPrice>();
                foreach (VW_CURRENT_STOCK_PRICE stockPriceEntity in stockPriceEntities)
                {
                    StockPrice stockPrice = new StockPrice();
                    stockPrice.Id = stockPriceEntity.Stock_Price_Id;
                    stockPrice.StockPackage = stockPackageLogic.Get(stockPriceEntity.Stock_Package_Id);
                    stockPrice.CostPrice = stockPriceEntity.Cost_Price;
                    stockPrice.SellingPrice = stockPriceEntity.Selling_Price;
                    stockPrice.DateEntered = stockPriceEntity.Date_Entered;

                    stockPrices.Add(stockPrice);
                }

                return stockPrices;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override StockPrice Add(StockPrice price)
        {
            try
            {
                StockPrice newStockPrice = base.Add(price);

                if (newStockPrice != null && newStockPrice.Id > 0)
                {
                    newStockPrice.StockPackage = price.StockPackage;
                    CurrentStockPrice currentStockPrice = new CurrentStockPrice() { StockPrice = newStockPrice };
                    currentPriceLogic.repository = repository;
                    currentPriceLogic.Add(currentStockPrice);
                }

                return newStockPrice;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override int Add(List<StockPrice> stockPrices)
        {
            try
            {
                if (stockPrices == null)
                {
                    throw new ArgumentNullException("stockPrices");
                }

                int addedRecordCount = 0;
                base.OpenDatabaseConnectionIfClosed();

                using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    currentPriceLogic.repository = repository;
                    currentPriceLogic.Remove(stockPrices[0].StockPackage.Stock);
                   
                    foreach (StockPrice stockPrice in stockPrices)
                    {
                        StockPrice newStockPrice = Add(stockPrice);
                        if (newStockPrice == null || newStockPrice.Id <= 0)
                        {
                            throw new Exception("Error occurred during Stock Price save operation! " + TryAgain);
                        }

                        addedRecordCount++;
                    }

                    if (addedRecordCount <= 0 || addedRecordCount != stockPrices.Count)
                    {
                        throw new Exception("Stock Price save operation failed! " + TryAgain);
                    }

                    base.CommitTransaction(transaction);

                    //transaction.Commit();
                    //repository.DbContext.Database.Connection.Close();
                }

                return addedRecordCount;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Modify(List<StockPrice> newStockPrices)
        {
            try
            {
                if (newStockPrices == null || newStockPrices.Count <= 0)
                {
                    throw new ArgumentNullException("newStockPrices");
                }

                int rowsAffected = 0;
                base.OpenDatabaseConnectionIfClosed();
                using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    currentPriceLogic.repository = repository;
                    bool removed = currentPriceLogic.Remove(newStockPrices[0].StockPackage.Stock);
                    if (removed == false)
                    {
                        throw new Exception("Removal of existing Current Stock Price failed! " + TryAgain);
                    }

                    foreach (StockPrice stockPrice in newStockPrices)
                    {
                        if (stockPrice.Id <= 0)
                        {
                            StockPrice newStockPrice = Add(stockPrice);
                            if (newStockPrice == null || newStockPrice.Id <= 0)
                            {
                                throw new Exception("Error occurred during Stock Price modification! " + TryAgain);
                            }

                            rowsAffected++;
                        }
                    }

                    if (rowsAffected <= 0)
                    {
                        throw new Exception("Stock Price modification failed! " + TryAgain);
                    }

                    base.CommitTransaction(transaction);

                    return rowsAffected > 0 ? true : false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        //public bool Modify(StockPrice stockPrice)
        //{
        //    try
        //    {
        //        Expression<Func<STOCK_PRICE, bool>> predicate = s => s.Stock_Price_Id == stockPrice.Id;
        //        STOCK_PRICE entity = GetEntityBy(predicate);
        //        entity.Cost_Price = stockPrice.CostPrice;
        //        entity.Selling_Price = stockPrice.SellingPrice;
        //        entity.Stock_Package_Id = stockPrice.StockPackage.Id;
        //        entity.Date_Entered = stockPrice.DateEntered;

        //        repository.Save();

        //        return true;
        //    }
        //    catch (NullReferenceException)
        //    {
        //        throw new NullReferenceException(ArgumentNullException);
        //    }
        //    catch (UpdateException)
        //    {
        //        throw new UpdateException(UpdateException);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        private List<StockPrice> GetListToRemove(List<StockPrice> newStockPrices, List<StockPrice> oldStockPrices)
        {
            try
            {
                List<StockPrice> stockPricesToRemove = new List<StockPrice>();
                foreach (StockPrice oldStockPrice in oldStockPrices)
                {
                    int matchCount = 0;
                    foreach (StockPrice newStockPrice in newStockPrices)
                    {
                        if (oldStockPrice.Id == newStockPrice.Id)
                        {
                            matchCount++;
                        }
                    }

                    if (matchCount == 0)
                    {
                        stockPricesToRemove.Add(oldStockPrice);
                    }
                    else
                    {
                        matchCount = 0;
                    }
                }

                return stockPricesToRemove;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StockPrice> GetBy(Stock stock)
        {
            List<StockPrice> stockPrices = null;

            try
            {
                string query = "SELECT * FROM VW_CURRENT_STOCK_PRICE where Stock_Id = " + stock.Id;
                List<VW_CURRENT_STOCK_PRICE> stockPriceEntities = repository.DbContext.Database.SqlQuery<VW_CURRENT_STOCK_PRICE>(query).ToList();
                
                stockPrices = ConvertToStockPriceModel(stockPriceEntities);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return stockPrices;
        }

        public StockPrice Get(StockPackage stockPackage)
        {
            StockPrice stockPrice = null;

            try
            {
                string query = "SELECT * FROM VW_CURRENT_STOCK_PRICE where Stock_Package_Id = " + stockPackage.Id;
                List<VW_CURRENT_STOCK_PRICE> stockPriceEntities = repository.DbContext.Database.SqlQuery<VW_CURRENT_STOCK_PRICE>(query).ToList();

                stockPrice = ConvertToStockPriceModel(stockPriceEntities).LastOrDefault();
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return stockPrice;
        }

        public List<StockPrice> GetBy(StockPackage stockPackage)
        {
            try
            {
                Expression<Func<STOCK_PRICE, bool>> selector = s => s.Stock_Package_Id == stockPackage.Id;
                List<STOCK_PRICE> stockPriceEntities = GetEntitiesBy(selector);

                return ConvertToStockPriceModel(stockPriceEntities);
            }
            catch (Exception)
            {
                throw;
            }
        }
       

        public StockPrice GetBy(long id)
        {
            try
            {
                Expression<Func<STOCK_PRICE, bool>> selector = sp => sp.Stock_Price_Id == id;
                return base.GetModelBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(Stock stock)
        {
            try
            {
                if (stock == null || stock.Id <= 0)
                {
                    throw new ArgumentNullException("stock");
                }

                if (NoStockPriceExistFor(stock))
                {
                    throw new Exception("No Stock Price exist for '" + stock.Name + "'");
                }

                bool deleted = false;
                base.OpenDatabaseConnectionIfClosed();
                using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    currentPriceLogic.repository = repository;
                    bool currentStockPackageRemoved = currentPriceLogic.Remove(stock);

                    Expression<Func<STOCK_PRICE, bool>> selector = sp => sp.STOCK_PACKAGE.Stock_Id == stock.Id;
                    deleted = base.Remove(selector);
                    if (deleted == false)
                    {
                        throw new Exception("No Stock Price found to delete!");
                    }

                    base.CommitTransaction(transaction);
                }

                return deleted;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool NoStockPriceExistFor(Stock stock)
        {
            try
            {
                if (stock == null || stock.Id <= 0)
                {
                    throw new ArgumentNullException("stock");
                }
                
                List<StockPrice> stockPrices = GetBy(stock);
                List<CurrentStockPrice> currentStockPrices = currentPriceLogic.GetBy(stock);
                if ((currentStockPrices == null || currentStockPrices.Count <= 0) && (stockPrices == null || stockPrices.Count <= 0))
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StoreProfitableStock> GetProfitableStockBy(bool isTop5)
        {
            List<StoreProfitableStock> profitableStockPrice = null;

            try
            {
                string query = "SELECT * FROM VW_PROFITABLE_STOCK ORDER BY Profit";
                query = isTop5 ? query += " DESC" : query += " ASC";

                profitableStockPrice = (from ps in repository.DbContext.Database.SqlQuery<VW_PROFITABLE_STOCK>(query)
                                        select new StoreProfitableStock
                                        {
                                             StockId = ps.Stock_Id,
                                             Stock = ps.Stock,
                                             StockName = ps.Stock_Name,
                                             PackageId = ps.Package_Id,
                                             PackageName = ps.Package_Name,
                                             CostPrice = ps.Cost_Price,
                                             SellingPrice = ps.Selling_Price,
                                             Profit = ps.Profit,
                                         }).ToList();

                profitableStockPrice = GetProfitableStockByHelper(profitableStockPrice);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return profitableStockPrice;
        }

        private List<StoreProfitableStock> GetProfitableStockByHelper(List<StoreProfitableStock> profitableStockPrice)
        {
            try
            {
                List<StoreProfitableStock> top5Stocks = null;
                if (profitableStockPrice != null && profitableStockPrice.Count > 0)
                {
                    top5Stocks = profitableStockPrice.Take(5).ToList();
                    if (top5Stocks != null && top5Stocks.Count > 0)
                    {
                        StoreProfitableStock topProfitableStock = top5Stocks.LastOrDefault();
                        List<StoreProfitableStock> profitableStocks = profitableStockPrice.Skip(5).Where(s => s.Profit == topProfitableStock.Profit).ToList();
                        if (profitableStocks != null && profitableStocks.Count > 0)
                        {
                            if (profitableStocks.Count > 5)
                            {
                                profitableStocks = profitableStocks.Take(5).ToList();
                            }

                            top5Stocks.AddRange(profitableStocks);
                        }
                    }

                    profitableStockPrice = top5Stocks;
                }

                return profitableStockPrice;
            }
            catch(Exception)
            {
                throw;
            }
        }








    }
}
