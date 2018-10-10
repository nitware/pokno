using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Model;
using Pokno.Entity;

namespace Pokno.Model
{
    public class CurrentStockPriceTranslator : TranslatorBase<CurrentStockPrice, CURRENT_STOCK_PRICE>
    {
        private StockPriceTranslator stockPriceTranslator;

        public CurrentStockPriceTranslator()
        {
            stockPriceTranslator = new StockPriceTranslator();
        }



        public override CurrentStockPrice TranslateToModel(CURRENT_STOCK_PRICE entity)
        {
            try
            {
                CurrentStockPrice model = null;

                if (entity != null)
                {
                    model = new CurrentStockPrice();
                    model.StockPrice = new StockPrice();
                    model.StockPrice.Id = entity.Stock_Price_Id;

                    if (entity.STOCK_PRICE != null)
                    {
                        model.StockPrice = stockPriceTranslator.Translate(entity.STOCK_PRICE);
                    }                   
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override CURRENT_STOCK_PRICE TranslateToEntity(CurrentStockPrice currentStockPrice)
        {
            try
            {
                CURRENT_STOCK_PRICE currentStockPriceEntity = null;
                if (currentStockPrice != null)
                {
                    currentStockPriceEntity = new CURRENT_STOCK_PRICE();
                    currentStockPriceEntity.Stock_Price_Id = currentStockPrice.StockPrice.Id;                
                }

                return currentStockPriceEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
