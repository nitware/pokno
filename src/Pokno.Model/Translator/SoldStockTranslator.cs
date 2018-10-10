using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Entity;

namespace Pokno.Model
{
    public class SoldStockTranslator : TranslatorBase<SoldStock, SOLD_STOCK>
    {
        private ShelfTranslator shelfTranslator;
        private SoldStockBatchTranslator soldStockBatchTranslator;
        private StockPackageTranslator stockPackageTranslator;
        private StockPriceTranslator stockPriceTranslator;

        public SoldStockTranslator()
        {
            shelfTranslator = new ShelfTranslator();
            soldStockBatchTranslator = new SoldStockBatchTranslator();
            stockPackageTranslator = new StockPackageTranslator();
            stockPriceTranslator = new StockPriceTranslator();
        }

        public override SoldStock TranslateToModel(SOLD_STOCK entity)
        {
            try
            {
                SoldStock model = null;
                if (entity != null)
                {
                    model = new SoldStock();
                    model.Id = entity.Sold_Stock_Id;
                    model.ShelfStock = shelfTranslator.Translate(entity.SHELF);
                    model.Price = stockPriceTranslator.Translate(entity.STOCK_PRICE);
                    model.Batch = soldStockBatchTranslator.Translate(entity.SOLD_STOCK_BATCH);
                    model.Discount = Math.Round((decimal)entity.Discount, 2);
                    model.Quantity = entity.Quantity;
                    model.Returned = entity.Returned;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override SOLD_STOCK TranslateToEntity(SoldStock model)
        {
            try
            {
                SOLD_STOCK entity = null;
                if (model != null)
                {
                    entity = new SOLD_STOCK();
                    entity.Sold_Stock_Id = model.Id;
                    entity.Shelf_Id = model.ShelfStock.Id;
                    entity.Stock_Price_Id = model.Price.Id;
                    entity.Sold_Stock_Batch_Id = model.Batch.Id;
                    entity.Quantity = model.Quantity;
                    entity.Discount = model.Discount;
                    entity.Returned = model.Returned;
                }

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }





    }


}
