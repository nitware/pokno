using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Model;
using Pokno.Entity;

namespace Pokno.Model
{
    public class StockPriceTranslator : TranslatorBase<StockPrice, STOCK_PRICE>
    {
        private StockPackageTranslator stockPackageTranslator;
        //private CurrentStockPriceTranslator currentStockPriceTranslator;
        public StockPriceTranslator()
        {
            stockPackageTranslator = new StockPackageTranslator();
            //currentStockPriceTranslator = new CurrentStockPriceTranslator();
        }
        public override StockPrice TranslateToModel(STOCK_PRICE stockPriceEntity)
        {
            try
            {
                StockPrice stockPrice = null;
                if (stockPriceEntity != null)
                {
                    stockPrice = new StockPrice();
                    stockPrice.Id = stockPriceEntity.Stock_Price_Id;
                    stockPrice.CostPrice = stockPriceEntity.Cost_Price;
                    stockPrice.SellingPrice = stockPriceEntity.Selling_Price;
                    stockPrice.StockPackage = stockPackageTranslator.Translate(stockPriceEntity.STOCK_PACKAGE);
                    stockPrice.DateEntered = stockPriceEntity.Date_Entered;
                    //stockPrice.CurrentStockPrice = currentStockPriceTranslator.Translate(stockPriceEntity.CURRENT_STOCK_PRICE);

                }
                return stockPrice;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override STOCK_PRICE TranslateToEntity(StockPrice stockPrice)
        {
            try
            {
                STOCK_PRICE stockPriceEntity = null;
                if (stockPrice != null)
                {
                    stockPriceEntity = new STOCK_PRICE();
                    stockPriceEntity.Stock_Price_Id = stockPrice.Id;
                    stockPriceEntity.Cost_Price = stockPrice.CostPrice;
                    stockPriceEntity.Selling_Price = stockPrice.SellingPrice;
                    stockPriceEntity.Date_Entered = stockPrice.DateEntered;
                    stockPriceEntity.Stock_Package_Id = stockPrice.StockPackage.Id;
                }
                return stockPriceEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}
