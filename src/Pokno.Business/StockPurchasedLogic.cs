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
using Pokno.Business.Helper;
using Pokno.Model.Views;
using Pokno.Business.Interfaces;
using System.Data.Entity.Core;

namespace Pokno.Business
{
    public class StockPurchasedLogic : BusinessLogicBase<StockPurchased, STOCK_PURCHASED>
    {
        private StockPackageRelationshipLogic stockPackageRelationshipLogic;
        private PackageRelationshipLogic packageRelationshipLogic;
        private StockPurchasedPoolLogic stockPurchasedPoolLogic;
        private StockPackageLogic stockPackageLogic;
        private StockLogic stockLogic;

        public StockPurchasedLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new StockPurchasedTranslator();

            stockPurchasedPoolLogic = new StockPurchasedPoolLogic(repository);
            packageRelationshipLogic = new PackageRelationshipLogic(repository);
            stockPackageRelationshipLogic = new StockPackageRelationshipLogic(repository);
            stockPackageLogic = new StockPackageLogic(repository);
            stockLogic = new StockLogic(repository);
        }

        public List<StockPurchased> GetBy(StockPurchaseBatch batch)
        {
            try
            {
                string include = "STOCK_PACKAGE, STOCK, STOCK_PACKAGE_RELATIONSHIP, STOCK_PURCHASE_BATCH";

                Expression<Func<STOCK_PURCHASED, bool>> selector = spb => spb.Stock_Purchase_Batch_Id == batch.Id;
                return base.GetModelsBy(selector, null, include).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StoreStockPurchased> GetByDatePurchasedRange(DateTime startDate, DateTime endDate)
        {
            List<StoreStockPurchased> storeStockPurchases = null;

            try
            {
                endDate = Range.Get(DateRange.End, endDate);
                startDate = Range.Get(DateRange.Start, startDate);

                string query = "SELECT * FROM VW_STOCK_PURCHASED where Date_Puchased >= '" + startDate.ToString(BusinessLogicUtility.DateTimeFormat) + "' AND Date_Puchased <= '" + endDate.ToString(BusinessLogicUtility.DateTimeFormat) + "'";
                storeStockPurchases = (from ssp in repository.DbContext.Database.SqlQuery<VW_STOCK_PURCHASED>(query)
                                       select new StoreStockPurchased
                                       {
                                           PurchaseBatchId = ssp.Stock_Purchase_Batch_Id,
                                           StockName = ssp.Stock_Name,
                                           PackageName = ssp.Package_Name,
                                           Buyer = ssp.Buyer,
                                           Supplier = ssp.Supplier,
                                           AmountPayable = ssp.Amount_Payable,
                                           AmountPaid = ssp.Amount_Paid.HasValue ? ssp.Amount_Paid.Value : (decimal)0,
                                           DatePurchased = ssp.Date_Puchased,
                                           SupplierExpenses = ssp.Supplier_Expenses,
                                           Quantity = (int)ssp.Quantity,
                                           UnitCost = ssp.Unit_Cost,
                                           Cost = ssp.Cost
                                       }).ToList();
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return storeStockPurchases;
        }
        public List<StoreStockPurchased> GetByStockAndDatePurchasedRange(DateTime startDate, DateTime endDate, Stock stock)
        {
            List<StoreStockPurchased> storeStockPurchases = null;

            try
            {
                endDate = Range.Get(DateRange.End, endDate);
                startDate = Range.Get(DateRange.Start, startDate);

                string query = "SELECT * FROM VW_STOCK_PURCHASED where Date_Puchased >= '" + startDate.ToString(BusinessLogicUtility.DateTimeFormat) + "' AND Date_Puchased <= '" + endDate.ToString(BusinessLogicUtility.DateTimeFormat) + "' AND Stock_Id = " + stock.Id;
                storeStockPurchases = (from ssp in repository.DbContext.Database.SqlQuery<VW_STOCK_PURCHASED>(query)
                                       select new StoreStockPurchased
                                       {
                                           StockName = ssp.Stock_Name,
                                           PackageName = ssp.Package_Name,
                                           Buyer = ssp.Buyer,
                                           Supplier = ssp.Supplier,
                                           AmountPayable = ssp.Amount_Payable,
                                           AmountPaid = ssp.Amount_Paid.HasValue ? ssp.Amount_Paid.Value : (decimal)0,
                                           DatePurchased = ssp.Date_Puchased,
                                           SupplierExpenses = ssp.Supplier_Expenses,
                                           Quantity = (int)ssp.Quantity,
                                           UnitCost = ssp.Unit_Cost,
                                           Cost = ssp.Cost
                                       }).ToList();
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return storeStockPurchases;
        }

        public List<StoreStockPurchased> GetSummaryByDatePurchasedRange(DateTime startDate, DateTime endDate)
        {
            List<StoreStockPurchased> storeStockPurchases = null;

            try
            {
                endDate = Range.Get(DateRange.End, endDate);
                startDate = Range.Get(DateRange.Start, startDate);

                string query = "SELECT * FROM VW_STOCK_PURCHASED_SUMMARY where Date_Puchased >= '" + startDate.ToString(BusinessLogicUtility.DateTimeFormat) + "' AND Date_Puchased <= '" + endDate.ToString(BusinessLogicUtility.DateTimeFormat) + "'";
                storeStockPurchases = (from ssp in repository.DbContext.Database.SqlQuery<VW_STOCK_PURCHASED_SUMMARY>(query)
                                       select new StoreStockPurchased
                                       {
                                           Buyer = ssp.Buyer,
                                           Supplier = ssp.Supplier,
                                           AmountPayable = ssp.Amount_Payable.HasValue ? ssp.Amount_Payable.Value : (decimal)0,
                                           AmountPaid = ssp.Amount_Paid.HasValue ? ssp.Amount_Paid.Value : (decimal)0,
                                           DatePurchased = ssp.Date_Puchased,
                                           SupplierExpenses = ssp.Supplier_Expenses.HasValue ? ssp.Supplier_Expenses.Value : (decimal)0,
                                           Quantity = ssp.Quantity.HasValue ? ssp.Quantity.Value : (int)0,
                                           UnitCost = ssp.Unit_Cost.HasValue ? ssp.Unit_Cost.Value : (decimal)0,
                                           Cost = ssp.Cost.HasValue ? ssp.Cost.Value : (decimal)0
                                       }).ToList();
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return storeStockPurchases;
        }

        public bool Modify(StockPurchaseBatch purchaseBatch)
        {
            try
            {
                //bool removeSuceeded = false;

                bool modificationSuccessful = false;
                bool removeSuceeded = Remove(purchaseBatch);
                if (removeSuceeded == true && purchaseBatch.StockPurchases != null && purchaseBatch.StockPurchases.Count > 0)
                {
                    int modifiedRecordCount = Add(purchaseBatch.StockPurchases);
                    modificationSuccessful = (modifiedRecordCount > 0 && modifiedRecordCount == purchaseBatch.StockPurchases.Count) ? true : false;
                }

                //else
                //{
                //    removeSuceeded = Remove(purchaseBatch);
                //    modificationSuccessful = removeSuceeded;
                //}

                return modificationSuccessful;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(StockPurchaseBatch purchaseBatch)
        {
            try
            {
                bool removed = false;
                if (purchaseBatch != null && purchaseBatch.Id > 0)
                {
                    Expression<Func<STOCK_PURCHASED, bool>> selector = sp => sp.Stock_Purchase_Batch_Id == purchaseBatch.Id;
                    Expression<Func<STOCK_PURCHASED_POOL, bool>> purchasedPoolSelector = sp => sp.Stock_Purchase_Batch_Id == purchaseBatch.Id;

                    List<StockPurchasedPool> stockPurchasedPools = stockPurchasedPoolLogic.GetModelsBy(purchasedPoolSelector);
                    if (stockPurchasedPools != null && stockPurchasedPools.Count > 0)
                    {
                        stockPurchasedPoolLogic.repository = repository;
                        if (stockPurchasedPoolLogic.Remove(stockPurchasedPools, purchaseBatch))
                        {
                            removed = base.Remove(selector);
                        }
                    }
                    else
                    {
                        removed = true;
                    }
                }

                return removed;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override int Add(List<StockPurchased> stockPurchases)
        {
            try
            {
                if (stockPurchases == null || stockPurchases.Count <= 0)
                {
                    throw new Exception("stockPurchases");
                }

                long batchId = stockPurchases[0].Batch.Id;
                Expression<Func<STOCK_PURCHASED, bool>> selector = sp => sp.Stock_Purchase_Batch_Id == batchId;

                List<StockPurchased> existingPurchasedStocks = GetModelsBy(selector);
                if (existingPurchasedStocks != null && existingPurchasedStocks.Count > 0)
                {
                    throw new Exception("The stock purchased for this batch has already been registered, but you Can modify");
                }

                foreach (StockPurchased stockPurchased in stockPurchases)
                {
                    stockPurchased.StockPackageRelationship = stockPackageRelationshipLogic.GetBy(stockPurchased.Stock);
                }

                int changeCount = 0;
                List<StockPurchased> addedStocksPurchased = base.AddCollection(stockPurchases);

                if (addedStocksPurchased != null && addedStocksPurchased.Count > 0)
                {
                    List<StockPurchased> addedPurchasedStocks = GetBy(stockPurchases[0].Batch);
                    if (AddStockPurchasePool(addedPurchasedStocks))
                    {
                        changeCount = addedPurchasedStocks.Count;
                    }
                    else
                    {
                        changeCount = -1;
                    }
                }

                return changeCount;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<StockPurchased> GetAddedPurchasedStock(List<StockPurchased> purchasedStocks)
        {
            try
            {
                //List<StockPurchased> purchasedStocks = null;

                //Expression<Func<STOCK_PURCHASED, bool>> selector = sp => sp.Stock_Purchase_Batch_Id == purchasedStocks[0].Id;
                //List<STOCK_PURCHASED> addedStockPurchaseEntities = GetEntitiesBy(selector, null, "STOCK_PACKAGE_RELATIONSHIP");

                if (purchasedStocks == null || purchasedStocks.Count <= 0)
                {
                    return null;
                }

                //purchasedStocks = new List<StockPurchased>();
                //foreach (StockPurchased entity in purchasedStocks)
                //    {
                //        StockPurchased purchasedStock = new StockPurchased();
                //        purchasedStock.Id = entity.Stock_Purchased_Id;
                //        purchasedStock.Batch = purchasedStocks[0].Batch;
                //        purchasedStock.Stock = stockLogic.GetModelBy(s => s.Stock_Id == entity.Stock_Id);
                //        purchasedStock.StockPackage = stockPackageLogic.GetModelBy(s => s.Stock_Package_Id == entity.Stock_Package_Id);
                //        purchasedStock.Quantity = entity.Quantity;
                //        purchasedStock.UnitCost = entity.Unit_Cost;
                //        purchasedStock.Cost = entity.Cost;
                //        purchasedStock.StockPackageRelationship = new StockPackageRelationship() { Id = entity.Stock_Package_Relationship_Id };

                //        purchasedStocks.Add(purchasedStock);
                //    }


                return purchasedStocks;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //private List<StockPurchased> GetAddedPurchasedStock(StockPurchaseBatch purchaseBatch)
        //{
        //    try
        //    {
        //        List<StockPurchased> purchasedStocks = null;

        //        Expression<Func<STOCK_PURCHASED, bool>> selector = sp => sp.Stock_Purchase_Batch_Id == purchaseBatch.Id;
        //        List<STOCK_PURCHASED> addedStockPurchaseEntities = GetEntitiesBy(selector, null, "STOCK_PACKAGE_RELATIONSHIP");

        //        if (addedStockPurchaseEntities != null && addedStockPurchaseEntities.Count > 0)
        //        {
        //            purchasedStocks = new List<StockPurchased>();
        //            foreach (STOCK_PURCHASED entity in addedStockPurchaseEntities)
        //            {
        //                StockPurchased purchasedStock = new StockPurchased();
        //                purchasedStock.Id = entity.Stock_Purchased_Id;
        //                purchasedStock.Batch = purchaseBatch;
        //                purchasedStock.Stock = stockLogic.GetModelBy(s => s.Stock_Id == entity.Stock_Id);
        //                purchasedStock.StockPackage = stockPackageLogic.GetModelBy(s => s.Stock_Package_Id == entity.Stock_Package_Id);
        //                purchasedStock.Quantity = entity.Quantity;
        //                purchasedStock.UnitCost = entity.Unit_Cost;
        //                purchasedStock.Cost = entity.Cost;
        //                purchasedStock.StockPackageRelationship = new StockPackageRelationship() { Id = entity.Stock_Package_Relationship_Id };

        //                purchasedStocks.Add(purchasedStock);
        //            }
        //        }

        //        return purchasedStocks;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public bool AddStockPurchasePool(List<StockPurchased> stockPurchases)
        //{
        //    try
        //    {
        //        bool added = false;
        //        if (stockPurchases != null && stockPurchases.Count > 0)
        //        {
        //            List<long> stockIds = GetDistinctStocks(stockPurchases);
        //            if (stockIds != null)
        //            {
        //                stockPurchasedPoolLogic.repository = repository;
        //                StockPurchaseBatch stockPurchaseBatch = stockPurchases[0].Batch;
        //                foreach (long stockId in stockIds)
        //                {
        //                    Expression<Func<STOCK, bool>> stockSelector = s => s.Stock_Id == stockId;
        //                    Stock stock = stockLogic.GetModelBy(stockSelector);
        //                    if (stock == null || stock.Id <= 0)
        //                    {
        //                        throw new Exception("Stock with ID of " + stockId + " + could not be found for Stock Purchased Pool creation! " + TryAgain);
        //                    }
                                                        
        //                    List<PackageRelationship> packageRelationships = packageRelationshipLogic.GetBy(stock);
        //                    if (packageRelationships == null || packageRelationships.Count <= 0)
        //                    {
        //                        throw new Exception("No Package Relationship found for " + stock.Name + ". Please setup Package Relationship for " + stock.Name + " before continuing.");
        //                    }

        //                    List<StockPurchased> purchasesForStock = stockPurchases.Where(sp => sp.Stock.Id == stockId).ToList();

        //                    long totalQuantityInUnitItem = packageRelationshipLogic.GetTotalUnitItem(purchasesForStock);
        //                    StockPackage stockPackage = packageRelationshipLogic.GetSmallestPackageBy(stock);
        //                    if (stockPackage == null || stockPackage.Id <= 0)
        //                    {
        //                        throw new Exception("No Stock Package found for " + stock.Name + ". Please create Stock Packages for " + stock.Name + " before continuing.");
        //                    }

        //                    StockPackageRelationship stockPackageRelationship = stockPackageRelationshipLogic.GetBy(stock);
        //                    StockPurchasedPool stockPurchasedPool = CreateStockPurchasedPool(stockPurchaseBatch, stock, totalQuantityInUnitItem, stockPackage, stockPackageRelationship);
        //                    added = stockPurchasedPoolLogic.Add(stockPurchasedPool, purchasesForStock);
        //                }

        //                return added;
        //            }
        //        }

        //        return added;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public bool AddStockPurchasePool(List<StockPurchased> stockPurchases)
        {
            try
            {
                bool added = false;
                if (stockPurchases != null && stockPurchases.Count > 0)
                {
                    List<long> stockIds = GetDistinctStocks(stockPurchases);
                    if (stockIds != null)
                    {
                        stockPurchasedPoolLogic.repository = repository;
                        StockPurchaseBatch stockPurchaseBatch = stockPurchases[0].Batch;
                        foreach (long stockId in stockIds)
                        {
                            Expression<Func<STOCK, bool>> stockSelector = s => s.Stock_Id == stockId;
                            Stock stock = stockLogic.GetModelBy(stockSelector);
                            if (stock == null || stock.Id <= 0)
                            {
                                throw new Exception("Stock with ID of " + stockId + " + could not be found for Stock Purchased Pool creation! " + TryAgain);
                            }

                            List<PackageRelationship> packageRelationships = packageRelationshipLogic.GetBy(stock);
                            if (packageRelationships == null || packageRelationships.Count <= 0)
                            {
                                throw new Exception("No Package Relationship found for " + stock.Name + ". Please setup Package Relationship for " + stock.Name + " before continuing.");
                            }

                            List<StockPurchased> purchasesForStock = stockPurchases.Where(sp => sp.Stock.Id == stockId).ToList();

                            decimal totalQuantityInUnitItem = packageRelationshipLogic.GetTotalUnitItem(purchasesForStock);
                            StockPackage stockPackage = packageRelationshipLogic.GetSmallestPackageBy(stock);
                            if (stockPackage == null || stockPackage.Id <= 0)
                            {
                                throw new Exception("No Stock Package found for " + stock.Name + ". Please create Stock Packages for " + stock.Name + " before continuing.");
                            }

                            StockPackageRelationship stockPackageRelationship = stockPackageRelationshipLogic.GetBy(stock);
                            StockPurchasedPool stockPurchasedPool = CreateStockPurchasedPool(stockPurchaseBatch, stock, totalQuantityInUnitItem, stockPackage, stockPackageRelationship);
                            added = stockPurchasedPoolLogic.Add(stockPurchasedPool, purchasesForStock);
                        }

                        return added;
                    }
                }

                return added;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private StockPurchasedPool CreateStockPurchasedPool(StockPurchaseBatch stockPurchaseBatch, Stock stock, decimal totalQuantityInUnitItem, StockPackage stockPackage, StockPackageRelationship stockPackageRelationship)
        {
            try
            {
                StockPurchasedPool stockPurchasedPool = new StockPurchasedPool();
                stockPurchasedPool.StockPackageRelationship = stockPackageRelationship;
                stockPurchasedPool.Date = stockPurchaseBatch.DatePurchased; //UtilityLogic.GetDate();
                stockPurchasedPool.StockPurchaseBatch = stockPurchaseBatch;
                stockPurchasedPool.Quantity = totalQuantityInUnitItem;
                stockPurchasedPool.UnitItem = stockPackage;
                stockPurchasedPool.Stock = stock;

                return stockPurchasedPool;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //private StockPurchasedPool CreateStockPurchasedPool(StockPurchaseBatch stockPurchaseBatch, Stock stock, long totalQuantityInUnitItem, StockPackage stockPackage, StockPackageRelationship stockPackageRelationship)
        //{
        //    try
        //    {
        //        StockPurchasedPool stockPurchasedPool = new StockPurchasedPool();
        //        stockPurchasedPool.StockPackageRelationship = stockPackageRelationship;
        //        stockPurchasedPool.Date = stockPurchaseBatch.DatePurchased; //UtilityLogic.GetDate();
        //        stockPurchasedPool.StockPurchaseBatch = stockPurchaseBatch;
        //        stockPurchasedPool.Quantity = totalQuantityInUnitItem;
        //        stockPurchasedPool.UnitItem = stockPackage;
        //        stockPurchasedPool.Stock = stock;

        //        return stockPurchasedPool;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public override StockPurchased Add(StockPurchased stockPurchased)
        {
            try
            {
                if (stockPurchased != null)
                {
                    Expression<Func<STOCK_PURCHASED, bool>> selector = stp => stp.Stock_Purchase_Batch_Id == stockPurchased.Batch.Id;
                    StockPurchased RetrievedstockPurchase = GetModelBy(selector);
                    if (RetrievedstockPurchase == null)
                    {
                        return base.Add(stockPurchased);
                    }

                    throw new Exception("The stock purchase For this batch has been registered,You Can Modify ");
                }
                return stockPurchased;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public StockPurchaseBatch LoadStockPurchaseByBatch(StockPurchaseBatch stockPurchaseBatch)
        {
            try
            {
                Expression<Func<STOCK_PURCHASED, bool>> selector = sp => sp.Stock_Purchase_Batch_Id == stockPurchaseBatch.Id;
                stockPurchaseBatch.StockPurchases = GetModelsBy(selector);
                return stockPurchaseBatch;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Modify(StockPurchased stockPurchased)
        {
            try
            {
                Expression<Func<STOCK_PURCHASED, bool>> predicate = sp => sp.Stock_Purchased_Id == stockPurchased.Id;
                STOCK_PURCHASED stockPurchasedEntity = GetEntityBy(predicate);

                stockPurchasedEntity.Quantity = (long)stockPurchased.Quantity;
                stockPurchasedEntity.Unit_Cost = stockPurchased.UnitCost;
                stockPurchasedEntity.Stock_Package_Id = stockPurchased.StockPackage.Id;
                stockPurchasedEntity.Stock_Id = stockPurchased.StockPackage.Stock.Id;
                stockPurchasedEntity.Stock_Purchase_Batch_Id = stockPurchased.Batch.Id;
                stockPurchasedEntity.Cost = stockPurchased.Cost;

                int rowAffected = repository.Save();
                if (rowAffected > 0)
                {
                    return true;
                }
                else
                {
                    throw new Exception(NoItemModified);
                }
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(ArgumentNullException);
            }
            catch (ConstraintException)
            {
                throw new ConstraintException("");
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

        public List<long> GetDistinctStocks(List<StockPurchased> stockPurchases)
        {
            try
            {
                if (stockPurchases != null)
                {
                    return stockPurchases.GroupBy(sp => sp.Stock.Id).Select(s => s.Key).ToList();
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StockPurchasedAtHand> GetStockPurchasedAtHand()
        {
            try
            {
                List<StockPurchasedPool> stockPurchasedPools = stockPurchasedPoolLogic.GetPoolsAtHand();
                if (stockPurchasedPools == null || stockPurchasedPools.Count == 0)
                {
                    return null;
                }

                decimal totalUnitItemCount = 0;
                decimal totalPackageQuantity = 0;
                List<StockPurchasedAtHand> stockPurchasesAtHand = new List<StockPurchasedAtHand>();

                for (int i = 0; i < stockPurchasedPools.Count; i++)
                {
                    StockPurchasedPool stockPurchasedPool = stockPurchasedPools[i];
                    StockPurchasedAtHand stockPurchasedAtHand = new StockPurchasedAtHand();
                    stockPurchasedAtHand.StockPurchases = new List<StockPurchased>();
                    stockPurchasedAtHand.Stock = new Stock();

                    stockPurchasedAtHand.Stock = stockPurchasedPool.Stock;
                    stockPurchasedAtHand.StockPurchasedPool = stockPurchasedPool;
                    decimal totalUnitItemQuantityAtHand = stockPurchasedPool.Quantity;

                    List<PackageRelationship> stockTotalPackageQuantities = packageRelationshipLogic.GetBy(stockPurchasedPool.StockPackageRelationship);
                    if (stockTotalPackageQuantities == null || stockTotalPackageQuantities.Count <= 0)
                    {
                        continue;
                    }

                    for (int j = 0; j < stockTotalPackageQuantities.Count; j++)
                    {
                        PackageRelationship packageRelationship = stockTotalPackageQuantities[j];
                        List<PackageRelationship> packageRelationships = packageRelationshipLogic.GetBy(packageRelationship);

                        if (packageRelationships != null && packageRelationships.Count > 0)
                        {
                            totalUnitItemCount = packageRelationshipLogic.GetTotalUnitItem(packageRelationships);

                            if ((totalUnitItemCount <= totalUnitItemQuantityAtHand) && (j < stockTotalPackageQuantities.Count))
                            {
                                totalPackageQuantity = Math.Truncate(totalUnitItemQuantityAtHand / totalUnitItemCount);
                                totalUnitItemQuantityAtHand = totalUnitItemQuantityAtHand - (totalPackageQuantity * totalUnitItemCount);

                                StockPurchased stockPurchased = CreateStockPurchasedForStockPurchasedAtHand(totalPackageQuantity, stockPurchasedPool, packageRelationship.Package);
                                stockPurchasedAtHand.StockPurchases.Add(stockPurchased);
                            }

                            if (j == stockTotalPackageQuantities.Count - 1)
                            {
                                if (totalUnitItemQuantityAtHand > 0)
                                {
                                    StockPurchased stockPurchased = CreateStockPurchasedForStockPurchasedAtHand(totalUnitItemQuantityAtHand, stockPurchasedPool, packageRelationship.SubPackage);
                                    stockPurchasedAtHand.StockPurchases.Add(stockPurchased);
                                }
                            }
                        }
                    }

                    if (stockPurchasedAtHand.StockPurchases != null && stockPurchasedAtHand.StockPurchases.Count > 0)
                    {
                        stockPurchasesAtHand.Add(stockPurchasedAtHand);
                    }
                }

                return stockPurchasesAtHand.OrderBy(spah => spah.Stock.Name).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public List<StockPurchasedAtHand> GetStockPurchasedAtHand()
        //{
        //    try
        //    {
        //        List<StockPurchasedPool> stockPurchasedPools = stockPurchasedPoolLogic.GetPoolsAtHand();
        //        if (stockPurchasedPools == null || stockPurchasedPools.Count == 0)
        //        {
        //            return null;
        //        }

        //        long totalUnitItemCount = 0;
        //        double totalPackageQuantity = 0;
        //        List<StockPurchasedAtHand> stockPurchasesAtHand = new List<StockPurchasedAtHand>();

        //        for (int i = 0; i < stockPurchasedPools.Count; i++)
        //        {
        //            StockPurchasedPool stockPurchasedPool = stockPurchasedPools[i];
        //            StockPurchasedAtHand stockPurchasedAtHand = new StockPurchasedAtHand();
        //            stockPurchasedAtHand.StockPurchases = new List<StockPurchased>();
        //            stockPurchasedAtHand.Stock = new Stock();

        //            stockPurchasedAtHand.Stock = stockPurchasedPool.Stock;
        //            stockPurchasedAtHand.StockPurchasedPool = stockPurchasedPool;
        //            double totalUnitItemQuantityAtHand = stockPurchasedPool.Quantity;

        //            List<PackageRelationship> stockTotalPackageQuantities = packageRelationshipLogic.GetBy(stockPurchasedPool.StockPackageRelationship);
        //            if (stockTotalPackageQuantities == null || stockTotalPackageQuantities.Count <= 0)
        //            {
        //                continue;
        //            }

        //            for (int j = 0; j < stockTotalPackageQuantities.Count; j++)
        //            {
        //                PackageRelationship packageRelationship = stockTotalPackageQuantities[j];
        //                List<PackageRelationship> packageRelationships = packageRelationshipLogic.GetBy(packageRelationship);

        //                if (packageRelationships != null && packageRelationships.Count > 0)
        //                {
        //                    totalUnitItemCount = packageRelationshipLogic.GetTotalUnitItem(packageRelationships);

        //                    //if ((totalUnitItemCount < totalUnitItemQuantityAtHand) && (j < stockTotalPackageQuantities.Count))
        //                    if ((totalUnitItemCount <= totalUnitItemQuantityAtHand) && (j < stockTotalPackageQuantities.Count))
        //                    {
        //                        totalPackageQuantity = Math.Truncate(totalUnitItemQuantityAtHand / (double)totalUnitItemCount);
        //                        totalUnitItemQuantityAtHand = totalUnitItemQuantityAtHand - (totalPackageQuantity * totalUnitItemCount);

        //                        StockPurchased stockPurchased = CreateStockPurchasedForStockPurchasedAtHand(totalPackageQuantity, stockPurchasedPool, packageRelationship.Package);
        //                        stockPurchasedAtHand.StockPurchases.Add(stockPurchased);
        //                    }

        //                    if (j == stockTotalPackageQuantities.Count - 1)
        //                    {
        //                        if (totalUnitItemQuantityAtHand > 0)
        //                        {
        //                            StockPurchased stockPurchased = CreateStockPurchasedForStockPurchasedAtHand(totalUnitItemQuantityAtHand, stockPurchasedPool, packageRelationship.SubPackage);
        //                            stockPurchasedAtHand.StockPurchases.Add(stockPurchased);
        //                        }
        //                    }
        //                }
        //            }

        //            if (stockPurchasedAtHand.StockPurchases != null && stockPurchasedAtHand.StockPurchases.Count > 0)
        //            {
        //                stockPurchasesAtHand.Add(stockPurchasedAtHand);
        //            }
        //        }

        //        return stockPurchasesAtHand.OrderBy(spah => spah.Stock.Name).ToList();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public List<StoreStock> GetStocksInStore()
        //{
        //    try
        //    {
        //        List<StoreStock> storeStocks = null;
        //        List<StockPurchasedAtHand> stocksInStore = GetStockPurchasedAtHand();
        //        if (stocksInStore != null && stocksInStore.Count > 0)
        //        {
        //            storeStocks = new List<StoreStock>();
        //            foreach (StockPurchasedAtHand stockInStore in stocksInStore)
        //            {
        //                foreach (StockPurchased stockPurchased in stockInStore.StockPurchases)
        //                {
        //                    StoreStock storeStock = new StoreStock();
        //                    storeStock.StockName = stockInStore.Stock.Name;
        //                    storeStock.PackageName = stockPurchased.StockPackage.Package.Name;
        //                    storeStock.Quantity = stockPurchased.Quantity;

        //                    storeStocks.Add(storeStock);
        //                }
        //            }
        //        }

        //        return storeStocks;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public List<StoreStock> GetStocksInStore()
        {
            try
            {
                List<StoreStock> storeStocks = null;
                List<StockPurchasedAtHand> stocksInStore = GetStockPurchasedAtHand();
                if (stocksInStore != null && stocksInStore.Count > 0)
                {
                    storeStocks = new List<StoreStock>();
                    foreach (StockPurchasedAtHand stockInStore in stocksInStore)
                    {
                        foreach (StockPurchased stockPurchased in stockInStore.StockPurchases)
                        {
                            StoreStock storeStock = new StoreStock();
                            storeStock.StockName = stockInStore.Stock.Name;
                            storeStock.PackageName = stockPurchased.StockPackage.Package.Name;
                            storeStock.Quantity = stockPurchased.Quantity;

                            storeStocks.Add(storeStock);
                        }
                    }
                }

                return storeStocks;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static StockPurchased CreateStockPurchasedForStockPurchasedAtHand(decimal totalPackageQuantity, StockPurchasedPool stockPurchasedPool, StockPackage stockPackage)
        {
            try
            {
                StockPurchased stockPurchased = new StockPurchased();
                stockPurchased.StockPackage = new StockPackage();
                stockPurchased.Stock = new Stock();

                stockPurchased.Quantity = totalPackageQuantity;
                stockPurchased.Stock = stockPurchasedPool.Stock;
                stockPurchased.StockPackage = stockPackage;
                stockPurchased.StockPackageRelationship = stockPurchasedPool.StockPackageRelationship;

                return stockPurchased;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //private static StockPurchased CreateStockPurchasedForStockPurchasedAtHand(double totalPackageQuantity, StockPurchasedPool stockPurchasedPool, StockPackage stockPackage)
        //{
        //    try
        //    {
        //        StockPurchased stockPurchased = new StockPurchased();
        //        stockPurchased.StockPackage = new StockPackage();
        //        stockPurchased.Stock = new Stock();

        //        stockPurchased.Quantity = Convert.ToInt32(totalPackageQuantity);
        //        stockPurchased.Stock = stockPurchasedPool.Stock;
        //        stockPurchased.StockPackage = stockPackage;
        //        stockPurchased.StockPackageRelationship = stockPurchasedPool.StockPackageRelationship;

        //        return stockPurchased;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}



    }


}
