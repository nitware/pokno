using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Entity;

namespace Pokno.Model
{
    public class StockPurchasedTranslator : TranslatorBase<StockPurchased, STOCK_PURCHASED>
    {
        private StockPackageTranslator stockPackageTranslator;
        private StockPurchaseBatchTranslator stockPurchaseBatchTranslator;
        private StockPackageRelationshipTranslator stockPackageRelationshipTranslator;
        private StockTranslator stockTranslator;

        public StockPurchasedTranslator()
        {
            stockPackageTranslator = new StockPackageTranslator();
            stockPurchaseBatchTranslator = new StockPurchaseBatchTranslator();
            stockPackageRelationshipTranslator = new StockPackageRelationshipTranslator();
            stockTranslator = new StockTranslator();
        }

        public override StockPurchased TranslateToModel(STOCK_PURCHASED stockPurchasedEntity)
        {
            try
            {
                StockPurchased stockPurchased = null;

                if (stockPurchasedEntity != null)
                {
                    stockPurchased = new StockPurchased();
                    stockPurchased.Id = stockPurchasedEntity.Stock_Purchased_Id;
                    stockPurchased.Quantity = (int)stockPurchasedEntity.Quantity;
                    stockPurchased.UnitCost = Math.Round(stockPurchasedEntity.Unit_Cost, 2);
                    stockPurchased.Cost = Math.Round(stockPurchasedEntity.Cost, 2);
                    stockPurchased.StockPackage = stockPackageTranslator.Translate(stockPurchasedEntity.STOCK_PACKAGE);
                    stockPurchased.Batch = stockPurchaseBatchTranslator.Translate(stockPurchasedEntity.STOCK_PURCHASE_BATCH);
                    stockPurchased.Stock = stockTranslator.Translate(stockPurchasedEntity.STOCK);
                    stockPurchased.StockPackageRelationship = stockPackageRelationshipTranslator.Translate(stockPurchasedEntity.STOCK_PACKAGE_RELATIONSHIP);

                }

                return stockPurchased;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override STOCK_PURCHASED TranslateToEntity(StockPurchased stockPurchased)
        {
            try
            {
                STOCK_PURCHASED stockPurchasedEntity = null;

                if (stockPurchased != null)
                {
                    stockPurchasedEntity = new STOCK_PURCHASED();
                    stockPurchasedEntity.Quantity = (long)stockPurchased.Quantity;
                    stockPurchasedEntity.Unit_Cost = stockPurchased.UnitCost;
                    stockPurchasedEntity.Stock_Package_Id = stockPurchased.StockPackage.Id;
                    stockPurchasedEntity.Stock_Id = stockPurchased.Stock.Id;
                    stockPurchasedEntity.Stock_Purchase_Batch_Id = stockPurchased.Batch.Id;
                    stockPurchasedEntity.Cost = stockPurchased.Cost;
                    stockPurchasedEntity.Stock_Package_Relationship_Id = stockPurchased.StockPackageRelationship.Id;
                }

                return stockPurchasedEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }





    }
}

