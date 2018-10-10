using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Model.Model;
using Pokno.Entity;
using Pokno.Model;
using System.Linq.Expressions;
using Pokno.Model.Translator;
using Pokno.Model.Views;
using Pokno.Business.Interfaces;

namespace Pokno.Business
{
    public class StockPurchasedPoolLogic : BusinessLogicBase<StockPurchasedPool, STOCK_PURCHASED_POOL>
    {
        private StockLogic stockLogic;
        private StockPurchasedPoolDetailLogic stockPurchasedPoolDetailLogic;
        private StockPackageRelationshipLogic stockPackageRelationshipLogic;

        public StockPurchasedPoolLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new StockPurchasedPoolTranslator();
            stockPurchasedPoolDetailLogic = new StockPurchasedPoolDetailLogic(repository);
            stockPackageRelationshipLogic = new StockPackageRelationshipLogic(repository);
            stockLogic = new StockLogic(repository);
        }

        public bool Add(StockPurchasedPool stockPurchasedPool, List<StockPurchased> stockPurchases)
        {
            try
            {
                bool added = false;

                if (stockPurchasedPool != null && stockPurchases != null)
                {
                    StockPurchasedPool addedStockPurchasedPool = base.Add(stockPurchasedPool);
                    if (addedStockPurchasedPool != null)
                    {
                        stockPurchasedPoolDetailLogic.repository = repository;
                        added = stockPurchasedPoolDetailLogic.Add(addedStockPurchasedPool, stockPurchases);
                    }
                }

                return added;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public bool Remove(StockPurchaseBatch purchasedBatch)
        //{
        //    try
        //    {
        //        bool removed = false;
        //        if (purchasedBatch != null && purchasedBatch.Id > 0)
        //        {
        //            //long batchId = stockPurchasedPools[0].StockPurchaseBatch.Id;
        //            Expression<Func<STOCK_PURCHASED_POOL, bool>> selector = spp => spp.Stock_Purchase_Batch_Id == purchasedBatch.Id;

        //            foreach (StockPurchasedPool stockPurchasedPool in stockPurchasedPools)
        //            {
        //                if (!stockPurchasedPoolDetailLogic.Remove(stockPurchasedPool))
        //                {
        //                    return false;
        //                }
        //            }

        //            removed = base.Remove(selector);
        //            //removed = repository.Save();
        //        }

        //        return removed;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        public bool Remove(List<StockPurchasedPool> stockPurchasedPools, StockPurchaseBatch purchasedBatch)
        {
            try
            {
                bool removed = false;
                if (stockPurchasedPools != null)
                {
                    stockPurchasedPoolDetailLogic.repository = repository;
                    foreach (StockPurchasedPool stockPurchasedPool in stockPurchasedPools)
                    {
                        if (!stockPurchasedPoolDetailLogic.Remove(stockPurchasedPool))
                        {
                            return false;
                        }
                    }

                    Expression<Func<STOCK_PURCHASED_POOL, bool>> selector = spp => spp.Stock_Purchase_Batch_Id == purchasedBatch.Id;
                    removed = base.Remove(selector);
                }

                return removed;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StockPurchasedPool> GetByStockPurchasedBatch(StockPurchaseBatch stockPurchaseBatch)
        {
            try
            {
                Expression<Func<STOCK_PURCHASED_POOL, bool>> selector = spp => spp.Stock_Purchase_Batch_Id == stockPurchaseBatch.Id;
                return GetModelsBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StockPurchasedPool> GetPoolsAtHand()
        {
            List<StockPurchasedPool> stockPurchasedPools = null;

            try
            {
                string query = "SELECT * FROM VW_STOCK_PURCHASED_POOL_SUMMARY where Remaining_Pool_Quantity > 0";
                List<VW_STOCK_PURCHASED_POOL_SUMMARY> remainingStocksInPool = repository.DbContext.Database.SqlQuery<VW_STOCK_PURCHASED_POOL_SUMMARY>(query).ToList();
                
                stockPurchasedPools = new List<StockPurchasedPool>();
                foreach (VW_STOCK_PURCHASED_POOL_SUMMARY remainingStockInPool in remainingStocksInPool)
                {
                    StockPurchasedPool stockPurchasedPool = new StockPurchasedPool();
                    stockPurchasedPool.StockPurchaseBatch = new StockPurchaseBatch();
                    stockPurchasedPool.Stock = new Stock();
                    stockPurchasedPool.UnitItem = new StockPackage();

                    stockPurchasedPool.Stock = stockLogic.Get(remainingStockInPool.Stock_Id);
                    //stockPurchasedPool.UnitItem.Id = remainingStockInPool.Unit_Item_Package_Id;
                    stockPurchasedPool.Quantity = (decimal)remainingStockInPool.Remaining_Pool_Quantity;
                    stockPurchasedPool.StockPackageRelationship = stockPackageRelationshipLogic.GetBy((int)remainingStockInPool.Stock_Package_Relationship_Id);

                    stockPurchasedPools.Add(stockPurchasedPool);
                }
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return stockPurchasedPools;
        }
      


    }




}
