using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Entity;

namespace Pokno.Model
{
   public class StockTranslator  : TranslatorBase<Stock, STOCK>
    {
       private StockTypeTranslator stockTypeTranslator;
      
       public StockTranslator()
       {
           stockTypeTranslator = new StockTypeTranslator();
       }

       public override Stock TranslateToModel(STOCK stockEntity)
        {
            try
            {
                Stock stock = null;
                if (stockEntity != null)
                {

                    stock = new Stock();
                    stock.Id = stockEntity.Stock_Id;
                    stock.Name = stockEntity.Stock_Name;
                    stock.Description = stockEntity.Stock_Descrption;
                    stock.ImagePath = stockEntity.Image_Path;
                    stock.Type = stockTypeTranslator.Translate(stockEntity.STOCK_TYPE);

                }

                return stock;
            }
            catch (Exception)
            {
                throw;
            }
        }
       public override STOCK TranslateToEntity(Stock stock)
        {
            try
            {
                STOCK stockEntity = null;
                if (stock != null)
                {
                    stockEntity = new STOCK();
                    stockEntity.Stock_Id = stock.Id;
                    stockEntity.Stock_Name = stock.Name;
                    stockEntity.Stock_Descrption = stock.Description;
                    stockEntity.Image_Path = stock.ImagePath;
                    stockEntity.Stock_Type_Id = stock.Type.Id;

                }
                return stockEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
