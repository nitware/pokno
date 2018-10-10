using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

using System.Data;
using Pokno.Model;
using Pokno.Entity;
using System.Linq.Expressions;
using Pokno.Model.Model;
using Pokno.Business.Interfaces;
using System.Data.Entity.Core;

namespace Pokno.Business
{
    public class StockPackageLogic : BusinessLogicBase<StockPackage, STOCK_PACKAGE>
    {
        private CurrentStockPackageLogic currentStockPackageLogic;

        public StockPackageLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new StockPackageTranslator();
            currentStockPackageLogic = new CurrentStockPackageLogic(repository);
        }

        public override List<StockPackage> GetAll()
        {
            try
            {
                List<CurrentStockPackage> currentStockPackages = currentStockPackageLogic.GetAll();
                return GetHelper(currentStockPackages);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public List<StockPackage> GetBy(Stock stock)
        {
            try
            {
                List<CurrentStockPackage> currentStockPackages = currentStockPackageLogic.GetBy(stock);
                return GetHelper(currentStockPackages);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<StockPackage> GetHelper(List<CurrentStockPackage> currentStockPackages)
        {
            try
            {
                if (currentStockPackages == null || currentStockPackages.Count <= 0)
                {
                    return null;
                }

                List<StockPackage> stockPackages = new List<StockPackage>();
                foreach (CurrentStockPackage currentStockPackage in currentStockPackages)
                {
                    stockPackages.Add(currentStockPackage.StockPackage);
                }

                return stockPackages;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public override int Add(List<StockPackage> stockPackages)
        {
            try
            {
                if (stockPackages == null || stockPackages.Count <= 0)
                {
                    throw new ArgumentNullException("stockPackages");
                }

                int rowsAdded = 0;
                base.OpenDatabaseConnectionIfClosed();
                using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    rowsAdded = AddHelper(stockPackages);
                    if (rowsAdded <= 0 || rowsAdded != stockPackages.Count)
                    {
                        throw new Exception("Stock Package save operation failed! " + TryAgain);
                    }

                    base.CommitTransaction(transaction);

                    //transaction.Commit();
                    //repository.DbContext.Database.Connection.Close();
                }

                return rowsAdded;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private int AddHelper(List<StockPackage> stockPackages)
        {
            try
            {
                int rowsAdded = 0;
                currentStockPackageLogic.repository = repository;
                currentStockPackageLogic.Remove(stockPackages[0].Stock);

                foreach (StockPackage stockPackage in stockPackages)
                {
                    StockPackage newStockPackage = base.Add(stockPackage);
                    if (newStockPackage == null || newStockPackage.Id < 0)
                    {
                        throw new Exception("Stock Package creation failed! " + TryAgain);
                    }

                    CurrentStockPackage currentStockPackage = new CurrentStockPackage();
                    currentStockPackage.StockPackage = newStockPackage;
                    currentStockPackageLogic.Add(currentStockPackage);

                    rowsAdded++;
                }

                return rowsAdded;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Modify(List<StockPackage> stockPackages)
        {
            try
            {
                if (stockPackages == null || stockPackages.Count <= 0)
                {
                    throw new ArgumentNullException("stockPackages");
                }

                int rowsAdded = 0;
                base.OpenDatabaseConnectionIfClosed();
                using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    rowsAdded = AddHelper(stockPackages);
                    if (rowsAdded <= 0 || rowsAdded != stockPackages.Count)
                    {
                        throw new Exception("Stock Package modification failed! " + TryAgain);
                    }

                    base.CommitTransaction(transaction);

                    //transaction.Commit();
                    //repository.DbContext.Database.Connection.Close();
                }

                return rowsAdded > 0 ? true : false;
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public StockPackage Get(long id)
        {
            try
            {
                Expression<Func<STOCK_PACKAGE, bool>> selector = spb => spb.Stock_Package_Id == id;
                return base.GetModelBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StoreStock> Get()
        {
            try
            {
                List<StockPackage> stockPackages = GetAll();
                List<StoreStock> storeStocks = new List<StoreStock>();
                if (stockPackages != null)
                {
                    foreach (StockPackage stockPackage in stockPackages)
                    {
                        StoreStock storeStock = new StoreStock();
                        storeStock.StockName = stockPackage.Stock.Name;
                        storeStock.PackageName = stockPackage.Package.Name;
                        storeStock.Quantity = stockPackage.ReOrderLevel;

                        storeStocks.Add(storeStock);
                    }
                }

                return storeStocks;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public StockPackage GetById(long id)
        {
            try
            {
                Expression<Func<STOCK_PACKAGE, bool>> selector = sp => sp.Stock_Package_Id == id;
                return GetModelBy(selector);
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

                if (NoPackageExistFor(stock))
                {
                    throw new Exception("No Package exist for '" + stock.Name + "'");
                }

                bool deleted = false;
                base.OpenDatabaseConnectionIfClosed();
                using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    currentStockPackageLogic.repository = repository;
                    bool currentStockPackageRemoved = currentStockPackageLogic.Remove(stock);

                    if (currentStockPackageRemoved == false)
                    {
                        throw new Exception("Current Stock Package deletion operation failed! " + TryAgain);
                    }

                    Expression<Func<STOCK_PACKAGE, bool>> selector = sp => sp.Stock_Id == stock.Id;
                    deleted = base.Remove(selector);

                    base.CommitTransaction(transaction);

                    //transaction.Commit();
                    //repository.DbContext.Database.Connection.Close();
                }

                return deleted;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool NoPackageExistFor(Stock stock)
        {
            try
            {
                if (stock == null || stock.Id <= 0)
                {
                    throw new ArgumentNullException("stock");
                }

                List<StockPackage> stockStockPackages = GetBy(stock);
                List<CurrentStockPackage> currentStockPackages = currentStockPackageLogic.GetBy(stock);
                if ((currentStockPackages == null || currentStockPackages.Count <= 0) && (stockStockPackages == null || stockStockPackages.Count <= 0))
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







    }
}
