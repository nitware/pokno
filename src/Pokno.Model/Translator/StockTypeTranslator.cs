using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Entity;

namespace Pokno.Model
{
    public class StockTypeTranslator : TranslatorBase<StockType, STOCK_TYPE>
    {
        private StockCategoryTranslator stockCategoryTranslator;

        public StockTypeTranslator()
        {
            stockCategoryTranslator = new StockCategoryTranslator();
        }

        public override StockType TranslateToModel(STOCK_TYPE stockTypeEntity)
        {
            try
            {
                StockType stockType = null;
                if (stockTypeEntity != null)
                {
                    stockType = new StockType();
                    stockType.Id = (int)stockTypeEntity.Stock_Type_Id;
                    stockType.Name = stockTypeEntity.Stock_Type_Name;
                    stockType.Description = stockTypeEntity.Stock_Type_Description;
                    stockType.Category = stockCategoryTranslator.Translate(stockTypeEntity.STOCK_CATEGORY);
                }

                return stockType;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override STOCK_TYPE TranslateToEntity(StockType stockType)
        {
            try
            {
                STOCK_TYPE stockTypeEntity = null;
                if (stockType != null)
                {
                    stockTypeEntity = new STOCK_TYPE();
                    stockTypeEntity.Stock_Type_Id = stockType.Id;
                    stockTypeEntity.Stock_Type_Name = stockType.Name;
                    stockTypeEntity.Stock_Type_Description = stockType.Description;
                    stockTypeEntity.Stock_Category_Id = stockType.Category.Id;

                }

                return stockTypeEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
