using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;

namespace Pokno.Model.Translator
{
    public class DeletedSoldStockTranslator : TranslatorBase<DeletedSoldStock, DELETED_SOLD_STOCK>
    {
        private DeletedSoldStockBatchTranslator _deletedSoldStockBatchTranslator;
        private StockPriceTranslator _stockPriceTranslator;

        public DeletedSoldStockTranslator()
        {
            _deletedSoldStockBatchTranslator = new DeletedSoldStockBatchTranslator();
            _stockPriceTranslator = new StockPriceTranslator();
        }

        public override DeletedSoldStock TranslateToModel(DELETED_SOLD_STOCK entity)
        {
            try
            {
                DeletedSoldStock model = null;
                if (entity != null)
                {
                    model = new DeletedSoldStock();
                    model.Id = entity.Sold_Stock_Id;
                    model.ShelfId = entity.Shelf_Id;
                    model.Price = _stockPriceTranslator.Translate(entity.STOCK_PRICE);
                    model.Batch = _deletedSoldStockBatchTranslator.Translate(entity.DELETED_SOLD_STOCK_BATCH);
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

        public override DELETED_SOLD_STOCK TranslateToEntity(DeletedSoldStock model)
        {
            try
            {
                DELETED_SOLD_STOCK entity = null;
                if (model != null)
                {
                    entity = new DELETED_SOLD_STOCK();
                    entity.Sold_Stock_Id = model.Id;
                    entity.Shelf_Id = model.ShelfId;
                    entity.Stock_Price_Id = model.Price.Id;
                    entity.Sold_Stock_Batch_Id = model.Batch.Id;
                    entity.Quantity = model.Quantity;
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
