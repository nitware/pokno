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
using Pokno.Business.Helper;

namespace Pokno.Business
{
    public class ShelfLogic : BusinessLogicBase<Shelf, SHELF>
    {
        private StockTypeLogic stockTypeLogic;
        private StockPriceLogic stockPriceLogic;
        private PackageRelationshipLogic packageQuantityLogic;
        private StockPackageLogic stockPackageLogic;
        private PackageLogic packageLogic;
        private StockLogic stockLogic;
        
        public ShelfLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new ShelfTranslator();
            packageQuantityLogic = new PackageRelationshipLogic(repository);
            stockPackageLogic = new StockPackageLogic(repository);
            stockPriceLogic = new StockPriceLogic(repository);
            packageLogic = new PackageLogic(repository);
            stockLogic = new StockLogic(repository);
            stockTypeLogic = new StockTypeLogic(repository);
        }

        public Shelf GetUnsoldStockBy(StockPackage stockPackage)
        {
            const int TOP_ONE = 1;

            try
            {
                //List<Shelf> shelfStocks = GetTopBy(s => s.Stock_Package_Id == stockPackage.Id && s.Sold == false, 1);

                Expression<Func<SHELF, bool>> selector = s => s.Stock_Package_Id == stockPackage.Id && s.Sold == false;
                List<Shelf> shelfStocks = GetTopBy(TOP_ONE, selector);
                                
                if (shelfStocks == null || shelfStocks.Count <= 0)
                {
                    throw new Exception("No more " + stockPackage.Package.Name + " of " + stockPackage.Stock.Name + " available on the shelf, for replacement! Kindly put more on the shelf before trying again.");
                }

                if (shelfStocks.Count > 1)
                {
                    throw new Exception("Multiple result set detected! " + TryAgain);
                }

                Shelf stockOnShelf = shelfStocks.SingleOrDefault();
                if (stockOnShelf == null || stockOnShelf.Id <= 0)
                {
                    throw new Exception("Retrieval of stock on the shelf faild! " + TryAgain);
                }

                return stockOnShelf;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Shelf> GetByEnteredDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                endDate = Range.Get(DateRange.End, endDate);
                startDate = Range.Get(DateRange.Start, startDate);

                Expression<Func<SHELF, bool>> selector = sos => sos.Date_Entered >= startDate && sos.Date_Entered <= endDate;
                return base.GetModelsBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Shelf> GetLatestHundred()
        {
            const int TOP_HUNDRED = 100;

            try
            {
                Expression<Func<SHELF, bool>> selector = s => s.Shelf_Id > 0;
                Func<IQueryable<SHELF>, IOrderedQueryable<SHELF>> orderBy = p => p.OrderByDescending(s => s.Date_Entered);

                return base.GetTopBy(TOP_HUNDRED, selector, orderBy);



                //Expression<Func<SHELF, bool>> selector = s => s.Shelf_Id > 0;
                //return base.GetAll().OrderByDescending(sos => sos.DateEntered).Take(100).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SellStock(Shelf shelfStock)
        {
            try
            {
                SHELF shelfEntity = base.GetEntityBy(s => s.Shelf_Id == shelfStock.Id);
                if (shelfEntity == null || shelfEntity.Shelf_Id <= 0)
                {
                    throw new Exception("Shelf stock could not be marked as sold! " + TryAgain);
                }

                shelfEntity.Sold = true;
                return base.Save() > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ReturnStock(List<Shelf> shelfs)
        {
            try
            {
                if (shelfs == null || shelfs.Count <= 0)
                {
                    throw new ArgumentNullException("shelfs");
                }

                foreach (Shelf shelf in shelfs)
                {
                    Expression<Func<SHELF, bool>> selector = s => s.Shelf_Id == shelf.Id;
                    SHELF entity = base.GetEntityBy(selector);
                    if (entity == null || entity.Shelf_Id <= 0)
                    {
                        throw new Exception(shelf.StockPackage.Package.Name + " of " + shelf.StockPackage.Stock.Name + " cannot be returned to the shelf! " + TryAgain);
                    }

                    entity.Sold = false;
                }

                return base.Save() > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ReturnStock(Shelf shelf)
        {
            try
            {
                if (shelf == null || shelf.Id <= 0)
                {
                    throw new ArgumentNullException("shelf");
                }

                Expression<Func<SHELF, bool>> selector = s => s.Shelf_Id == shelf.Id;
                SHELF entity = base.GetEntityBy(selector);
                if (entity == null || entity.Shelf_Id <= 0)
                {
                    throw new Exception(shelf.StockPackage.Package.Name + " of " + shelf.StockPackage.Stock.Name + " cannot be returned to the shelf! " + TryAgain);
                }

                entity.Sold = false;

                return base.Save() > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ArrangeOnShelf(Shelf shelf)
        {
            try
            {
                if (StockPriceNotSet(shelf))
                {
                    throw new Exception("Cannot add " + shelf.StockPackage.Package.Name + " of " + shelf.StockPackage.Stock.Name + " to shelve, because it's price has not been set! Please click Stock Setup > Stock Price to set the price for this stock packages.");
                }

                int itemsAdded = 0;
                decimal unitItemQuantityAtHand = GetUnitItemQuantityAtHandByStock(shelf.StockPackage.Stock);
                decimal unitItemQuantityToBeShelfed = packageQuantityLogic.GetTotalUnitItem(shelf.StockPackage, shelf.StockPackageRelationship) * shelf.Quantity;

                if (unitItemQuantityToBeShelfed > unitItemQuantityAtHand)
                {
                    throw new Exception("The total number of items " + unitItemQuantityToBeShelfed + " to be put on the shelve, exceeds the total quantity in the system " + unitItemQuantityAtHand + "! Please adjust, and try again.");
                }

                base.OpenDatabaseConnectionIfClosed();
                int totalQuantityToBePutOnShelf = (int)shelf.Quantity;
                using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    List<Shelf> shelfs = new List<Shelf>();
                    decimal totalStockPackageUnitItemQuantity = packageQuantityLogic.GetTotalUnitItem(shelf.StockPackage, shelf.StockPackageRelationship);
                    for (int i = 0; i < totalQuantityToBePutOnShelf; i++)
                    {
                        shelf.Quantity = 1;
                        shelf.TotalUnitQuantity = totalStockPackageUnitItemQuantity;
                        shelfs.Add(shelf);
                    }

                    itemsAdded = base.Add(shelfs);
                    if (itemsAdded != totalQuantityToBePutOnShelf)
                    {
                        throw new Exception("Selected stocks/items could not be successfully put on the shelf! " + TryAgain);
                    }

                    transaction.Commit();
                    repository.DbContext.Database.Connection.Close();
                }

                return itemsAdded;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public int ArrangeOnShelf(Shelf shelf)
        //{
        //    try
        //    {
        //        if (StockPriceNotSet(shelf))
        //        {
        //            throw new Exception("Cannot add " + shelf.StockPackage.Package.Name + " of " + shelf.StockPackage.Stock.Name + " to shelve, because it's price has not been set! Please click Stock Setup > Stock Price to set the price for this stock packages.");
        //        }

        //        int itemsAdded = 0;
        //        long unitItemQuantityAtHand = GetUnitItemQuantityAtHandByStock(shelf.StockPackage.Stock);
        //        long unitItemQuantityToBeShelfed = packageQuantityLogic.GetTotalUnitItem(shelf.StockPackage, shelf.StockPackageRelationship) * shelf.Quantity;

        //        if (unitItemQuantityToBeShelfed > unitItemQuantityAtHand)
        //        {
        //            throw new Exception("The total number of items " + unitItemQuantityToBeShelfed + " to be put on the shelve, exceeds the total quantity in the system " + unitItemQuantityAtHand + "! Please adjust, and try again.");
        //        }

        //        base.OpenDatabaseConnectionIfClosed();
        //        int totalQuantityToBePutOnShelf = (int)shelf.Quantity;
        //        using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
        //        {
        //            List<Shelf> shelfs = new List<Shelf>();
        //            long totalStockPackageUnitItemQuantity = packageQuantityLogic.GetTotalUnitItem(shelf.StockPackage, shelf.StockPackageRelationship);
        //            for (int i = 0; i < totalQuantityToBePutOnShelf; i++)
        //            {
        //                shelf.Quantity = 1;
        //                shelf.TotalUnitQuantity = totalStockPackageUnitItemQuantity;
        //                shelfs.Add(shelf);
        //            }

        //            itemsAdded = base.Add(shelfs);
        //            if (itemsAdded != totalQuantityToBePutOnShelf)
        //            {
        //                throw new Exception("Selected stocks/items could not be successfully put on the shelf! " + TryAgain);
        //            }

        //            transaction.Commit();
        //            repository.DbContext.Database.Connection.Close();
        //        }

        //        return itemsAdded;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

      
        public List<Shelf> GetAllUnsoldByStockAndStockType(Stock stock, StockType stockType)
        {
            List<Shelf> stocksOnShelf = null;

            try
            {
                string query = "SELECT * FROM VW_STOCK_FOR_SALE_SUMMARY where Stock_Type_Id = " + stockType.Id + " AND Stock_Id = " + stock.Id;
                List<VW_STOCK_FOR_SALE_SUMMARY> unsoldStocks = repository.DbContext.Database.SqlQuery<VW_STOCK_FOR_SALE_SUMMARY>(query).ToList();
                
                if (unsoldStocks != null && unsoldStocks.Count > 0)
                {
                    stocksOnShelf = new List<Shelf>();
                    foreach (VW_STOCK_FOR_SALE_SUMMARY unsoldStock in unsoldStocks)
                    {
                        Shelf stockOnShelf = new Shelf();
                        stockOnShelf.StockPackage = stockPackageLogic.Get(unsoldStock.Stock_Package_Id);
                        stockOnShelf.Quantity = (int)unsoldStock.Unsold_Shelf_Quantity;
                        stockOnShelf.FakeQuantityOnShelf = (int)unsoldStock.Unsold_Shelf_Quantity;
                        stockOnShelf.StockType = stockType;
                        stockOnShelf.StockPackageRelationship = new StockPackageRelationship() { Id = unsoldStock.Stock_Package_Relationship_Id };
                        stockOnShelf.ReorderLevel = (long)unsoldStock.Unsold_Shelf_Quantity - (long)stockOnShelf.StockPackage.ReOrderLevel;

                        stocksOnShelf.Add(stockOnShelf);
                    }
                }
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return stocksOnShelf;
        }

        public List<StockOnShelfAtHand> GetUnsoldStocks()
        {
            try
            {
                List<StockOnShelfAtHand> stocksOnShelfAtHand = new List<StockOnShelfAtHand>();

                //get all stock types
                List<StockType> unsoldStockTypes = stockTypeLogic.GetAllUnsold();
                if (unsoldStockTypes != null && unsoldStockTypes.Count > 0)
                {
                    foreach (StockType unsoldStockType in unsoldStockTypes)
                    {
                        StockOnShelfAtHand stockOnShelfAtHand = new StockOnShelfAtHand();
                        stockOnShelfAtHand.UnsoldStockPackages = new List<UnsoldStockPackage>();

                        stockOnShelfAtHand.StockType = unsoldStockType;
                        List<Stock> unsoldStocks = stockLogic.GetAllUnsoldByType(unsoldStockType).OrderBy(us => us.Name).ToList();
                        if (unsoldStocks != null && unsoldStocks.Count > 0)
                        {
                            foreach (Stock unsoldStock in unsoldStocks)
                            {
                                UnsoldStockPackage unsoldStockPackage = new UnsoldStockPackage();
                                List<Shelf> stocksOnShelf = GetAllUnsoldByStockAndStockType(unsoldStock, unsoldStockType);
                                unsoldStockPackage.Stock = unsoldStock;
                                unsoldStockPackage.Shelfs = stocksOnShelf;

                                stockOnShelfAtHand.UnsoldStockPackages.Add(unsoldStockPackage);
                            }

                            stocksOnShelfAtHand.Add(stockOnShelfAtHand);
                        }
                    }
                }

                return stocksOnShelfAtHand;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StockAtHand> GetStocksAtHand(Stock stock)
        {
            List<StockAtHand> stocksAtHand = null;

            try
            {
                string query = "SELECT * FROM VW_STOCK_AT_HAND where Stock_Id = " + stock.Id;
                List<VW_STOCK_AT_HAND> stocksAtHandEntity = repository.DbContext.Database.SqlQuery<VW_STOCK_AT_HAND>(query).ToList();

                stocksAtHand = new List<StockAtHand>();
                foreach (VW_STOCK_AT_HAND stockAtHandEntity in stocksAtHandEntity)
                {
                    StockAtHand stockAtHand = new StockAtHand();
                    stockAtHand.Package = packageLogic.Get(stockAtHandEntity.Package_Id);
                    stockAtHand.Quantity = (int)stockAtHandEntity.Quantity;

                    stocksAtHand.Add(stockAtHand);
                }
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return stocksAtHand;
        }
               
        public StockForSale GetStockForSale(StockPackage stockPackage, int stockPackageRelationshipId)
        {
            StockForSale stockForSale = null;

            try
            {
                string query = "SELECT * FROM VW_STOCK_FOR_SALE_SUMMARY where Stock_Package_Id = " + stockPackage.Id + " AND Stock_Package_Relationship_Id = " + stockPackageRelationshipId;
                VW_STOCK_FOR_SALE_SUMMARY stockForSaleEntity = repository.DbContext.Database.SqlQuery<VW_STOCK_FOR_SALE_SUMMARY>(query).SingleOrDefault();
                                
                if (stockForSaleEntity != null)
                {
                    StockType stockType = stockTypeLogic.Get((int)stockForSaleEntity.Stock_Type_Id);
                    StockPrice stockPrice = stockPriceLogic.GetBy(stockForSaleEntity.Stock_Price_Id);

                    stockPrice.SellingPrice = Math.Round(stockPrice.SellingPrice);
                    stockPrice.CostPrice = Math.Round(stockPrice.CostPrice);

                    stockForSale = new StockForSale();
                    stockForSale.StockPackage = stockPackage;
                    stockForSale.StockType = stockType;
                    stockForSale.StockPrice = stockPrice;
                    stockForSale.OriginalStockPrice = stockPrice;
                    stockForSale.TotalSellingPrice = Math.Round(stockForSale.StockPrice.SellingPrice - stockForSale.Discount, 2);
                    stockForSale.Quantity = 1;
                    stockForSale.OriginalQuantity = 1;
                    stockForSale.StockPackageRelationshipId = stockForSaleEntity.Stock_Package_Relationship_Id;
                }
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return stockForSale;
        }
              
        private bool StockPriceNotSet(Shelf shelf)
        {
            try
            {
                if (shelf != null)
                {
                    List<StockPrice> stockPrices = stockPriceLogic.GetBy(shelf.StockPackage);
                    if (stockPrices == null || stockPrices.Count == 0)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public decimal GetUnitItemQuantityAtHandByStock(Stock stock)
        {
            decimal totalUnitItemQuantityInStore = 0;

            try
            {
                string query = "SELECT * FROM VW_STOCK_PURCHASED_POOL_SUMMARY where Stock_Id = " + stock.Id;
                List<VW_STOCK_PURCHASED_POOL_SUMMARY> stockPurchasePoolSummary = repository.DbContext.Database.SqlQuery<VW_STOCK_PURCHASED_POOL_SUMMARY>(query).ToList();
                if (stockPurchasePoolSummary == null)
                {
                    stockPurchasePoolSummary = new List<VW_STOCK_PURCHASED_POOL_SUMMARY>();
                }

                totalUnitItemQuantityInStore = stockPurchasePoolSummary.Sum(spps => spps.Remaining_Pool_Quantity).Value;
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return totalUnitItemQuantityInStore;
        }

        //public long GetUnitItemQuantityAtHandByStock(Stock stock)
        //{
        //    long totalUnitItemQuantityInStore = 0;

        //    try
        //    {
        //        string query = "SELECT * FROM VW_STOCK_PURCHASED_POOL_SUMMARY where Stock_Id = " + stock.Id;
        //        List<VW_STOCK_PURCHASED_POOL_SUMMARY> stockPurchasePoolSummary = repository.DbContext.Database.SqlQuery<VW_STOCK_PURCHASED_POOL_SUMMARY>(query).ToList();
        //        if (stockPurchasePoolSummary == null)
        //        {
        //            stockPurchasePoolSummary = new List<VW_STOCK_PURCHASED_POOL_SUMMARY>();
        //        }

        //        totalUnitItemQuantityInStore = stockPurchasePoolSummary.Sum(spps => spps.Remaining_Pool_Quantity).Value;
        //    }
        //    catch (Exception ex)
        //    {
        //        base.SuppressError(ex);
        //    }

        //    return totalUnitItemQuantityInStore;
        //}

        //public long GetTotalUnitOnShelfBy(StockPurchasedPool stockPurchasedPool)
        //{
        //    try
        //    {
        //        string query = "SELECT * FROM VW_STOCK_ON_SHELF where Stock_Purchased_Pool_Id = " + stockPurchasedPool.Id + " AND Unsold_Shelf_Quantity > 0";
        //        List<VW_STOCK_ON_SHELF> stockOnShelfs = repository.DbContext.Database.SqlQuery<VW_STOCK_ON_SHELF>(query).ToList();

        //        long unitItemQuantity = 0;
        //        if (stockOnShelfs != null && stockOnShelfs.Count > 0)
        //        {
        //            foreach (VW_STOCK_ON_SHELF stockOnShelf in stockOnShelfs)
        //            {
        //                StockPackage stockPackage = stockPackageLogic.GetById(stockOnShelf.Stock_Package_Id);
        //                if (stockPackage != null)
        //                {
        //                    long totalUnitInPackage = packageQuantityLogic.GetTotalUnitItem(stockPackage);
        //                    unitItemQuantity += (totalUnitInPackage * (long)stockOnShelf.Unsold_Shelf_Quantity);
        //                }
        //            }
        //        }

        //        return unitItemQuantity;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<Shelf> GetAllUntouched()
        {
            try
            {
                Expression<Func<SHELF, bool>> selector = s => s.Shelf_Id > 0;
                Func<IQueryable<SHELF>, IOrderedQueryable<SHELF>> orderBy = p => p.OrderByDescending(s => s.Date_Entered);

                return base.GetModelsBy(selector, orderBy);


                //return GetAll().OrderByDescending(sosb => sosb.DateEntered).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(Shelf shelf)
        {
            try
            {
                Expression<Func<SHELF, bool>> selector = sos => sos.Shelf_Id == shelf.Id;
                return base.Remove(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(List<Shelf> stocksOnShelf)
        {
            try
            {
                if (stocksOnShelf == null || stocksOnShelf.Count <= 0)
                {
                    throw new ArgumentNullException("stocksOnShelf");
                }

                int removedStockCount = 0;
                foreach (Shelf stockOnShelf in stocksOnShelf)
                {
                    Expression<Func<SHELF, bool>> selector = sos => sos.Shelf_Id == stockOnShelf.Id;
                    base.Remove(selector);
                    removedStockCount++;
                }

                return removedStockCount == stocksOnShelf.Count ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Methods for report

        public List<StoreStock> GetRemainingStockOnShelf()
        {
            List<StoreStock> remainingStocksOnShelf = null;

            try
            {
                string query = "SELECT * FROM VW_STOCK_FOR_SALE_SUMMARY where Unsold_Shelf_Quantity > 0";
                remainingStocksOnShelf = (from vsos in base.repository.DbContext.Database.SqlQuery<VW_STOCK_FOR_SALE_SUMMARY>(query)
                                          select new StoreStock
                                          {
                                              StockType = vsos.Stock_Type_Name,
                                              StockName = vsos.Stock_Name,
                                              PackageName = vsos.Package_Name,
                                              Quantity = vsos.Unsold_Shelf_Quantity.HasValue ? vsos.Unsold_Shelf_Quantity.Value : (int)0
                                          }).OrderBy(sos => sos.StockName).ToList();
            }
            catch (Exception ex)
            {
                SuppressError(ex);
            }

            return remainingStocksOnShelf;
        }

        #endregion

        public List<ExpiryDateAlert> GetAboutToExpiredStock()
        {
            List<ExpiryDateAlert> expiryDateAlerts = null;

            try
            {
                string query = "SELECT * FROM VW_EXPIRY_DATE_ALERT where Remainig_Alert_Days <= Expiry_Date_No_Of_Days_Alert or Remainig_Alert_Days < 0";
                expiryDateAlerts = (from eda in repository.DbContext.Database.SqlQuery<VW_EXPIRY_DATE_ALERT>(query)
                                                          select new ExpiryDateAlert
                                                          {
                                                              StockName = eda.Stock_Name,
                                                              PackageName = eda.Package_Name,
                                                              QuantityOnShelf = eda.Quantity_On_Shelf,
                                                              ExpiryDaysAlert = eda.Expiry_Date_No_Of_Days_Alert,
                                                              RemainingAlertDays = eda.Remainig_Alert_Days,
                                                              QuantityRemaining = (int)eda.Quantity_On_Shelf

                                                          }).ToList();
                
            }
            catch (Exception ex)
            {
                SuppressError(ex);
            }

            return expiryDateAlerts;
        }

        

    }

}
