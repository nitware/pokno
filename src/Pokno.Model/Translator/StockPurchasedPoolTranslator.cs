using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Model.Model;
using Pokno.Entity;

namespace Pokno.Model.Translator
{
    public class StockPurchasedPoolTranslator : TranslatorBase<StockPurchasedPool, STOCK_PURCHASED_POOL>
    {
        private StockTranslator stockTranslator;
        private StockPackageTranslator stockPackageTranslator;
        private StockPurchaseBatchTranslator stockPurchaseBatchTranslator;
        private StockPackageRelationshipTranslator stockPackageRelationshipTranslator;

        public StockPurchasedPoolTranslator()
        {
            stockTranslator = new StockTranslator();
            stockPackageTranslator = new StockPackageTranslator();
            stockPurchaseBatchTranslator = new StockPurchaseBatchTranslator();
            stockPackageRelationshipTranslator = new StockPackageRelationshipTranslator();
        }

        public override StockPurchasedPool TranslateToModel(STOCK_PURCHASED_POOL stockPurchasedPoolEntity)
        {
            try
            {
                StockPurchasedPool stockPurchasedPool = null;
                if (stockPurchasedPoolEntity != null)
                {
                    stockPurchasedPool = new StockPurchasedPool();
                    stockPurchasedPool.Id = stockPurchasedPoolEntity.Stock_Purchased_Pool_Id;
                    stockPurchasedPool.StockPurchaseBatch = stockPurchaseBatchTranslator.Translate(stockPurchasedPoolEntity.STOCK_PURCHASE_BATCH);
                    stockPurchasedPool.Stock = stockTranslator.Translate(stockPurchasedPoolEntity.STOCK);
                    stockPurchasedPool.Stock = stockTranslator.Translate(stockPurchasedPoolEntity.STOCK);
                    stockPurchasedPool.UnitItem = stockPackageTranslator.Translate(stockPurchasedPoolEntity.STOCK_PACKAGE);
                    stockPurchasedPool.Quantity = stockPurchasedPoolEntity.Quantity;
                    stockPurchasedPool.Date = stockPurchasedPoolEntity.Date;

                    stockPurchasedPool.StockPackageRelationship = stockPackageRelationshipTranslator.Translate(stockPurchasedPoolEntity.STOCK_PACKAGE_RELATIONSHIP);
                }

                return stockPurchasedPool;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override STOCK_PURCHASED_POOL TranslateToEntity(StockPurchasedPool stockPurchasedPool)
        {
            try
            {
                STOCK_PURCHASED_POOL stockPurchasedPoolEntity = null;
                if (stockPurchasedPool != null)
                {
                    stockPurchasedPoolEntity = new STOCK_PURCHASED_POOL();
                    stockPurchasedPoolEntity.Stock_Purchased_Pool_Id = stockPurchasedPool.Id;
                    stockPurchasedPoolEntity.Stock_Purchase_Batch_Id = stockPurchasedPool.StockPurchaseBatch.Id;
                    stockPurchasedPoolEntity.Stock_Id = stockPurchasedPool.Stock.Id;
                    stockPurchasedPoolEntity.Unit_Item_Package_Id = stockPurchasedPool.UnitItem.Id;
                    stockPurchasedPoolEntity.Quantity = stockPurchasedPool.Quantity;
                    stockPurchasedPoolEntity.Date = stockPurchasedPool.Date;

                    stockPurchasedPoolEntity.Stock_Package_Relationship_Id = stockPurchasedPool.StockPackageRelationship.Id;
                }

                return stockPurchasedPoolEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }



    }


}
