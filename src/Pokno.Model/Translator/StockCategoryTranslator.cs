using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pokno.Entity;

namespace Pokno.Model
{
    public class StockCategoryTranslator : TranslatorBase<StockCategory, STOCK_CATEGORY>
    {            
        public override StockCategory TranslateToModel(STOCK_CATEGORY stockCategoryEntity)
        {
            try
            {
                StockCategory stockCategory = null;
                if (stockCategoryEntity != null)
                {
                    stockCategory = new StockCategory();
                    stockCategory.Id = (int)stockCategoryEntity.Stock_Category_Id;
                    stockCategory.Name = stockCategoryEntity.Stock_Category_Name;
                    stockCategory.Description = stockCategoryEntity.Stock_Category_Description;
                }

                return stockCategory;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override STOCK_CATEGORY TranslateToEntity(StockCategory stockCategory)
        {
            try
            {
                STOCK_CATEGORY stockCategoryEntity = null;
                if (stockCategory != null)
                {
                    stockCategoryEntity = new STOCK_CATEGORY();
                    stockCategoryEntity.Stock_Category_Id = stockCategory.Id;
                    stockCategoryEntity.Stock_Category_Name = stockCategory.Name;
                    stockCategoryEntity.Stock_Category_Description = stockCategory.Description;
                }

                return stockCategoryEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }



    }



}