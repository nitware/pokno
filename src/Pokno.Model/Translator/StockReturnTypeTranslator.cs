using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Entity;

namespace Pokno.Model
{
    public class StockReturnTypeTranslator : TranslatorBase<StockReturnType, STOCK_RETURN_TYPE>
    {
        public override StockReturnType TranslateToModel(STOCK_RETURN_TYPE stockReturnTypeEntity)
        {
            try
            {
                StockReturnType stockReturnType = null;
                if (stockReturnTypeEntity != null)
                {
                    stockReturnType = new StockReturnType();
                    stockReturnType.Id = (int)stockReturnTypeEntity.Stock_Return_Type_Id;
                    stockReturnType.Name = stockReturnTypeEntity.Stock_Return_Type_Name;
                }
                return stockReturnType;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override STOCK_RETURN_TYPE TranslateToEntity(StockReturnType stockReturnType)
        {
            try
            {
                STOCK_RETURN_TYPE stockReturnTypeEntity = null;
                if (stockReturnType != null)
                {
                    stockReturnTypeEntity = new STOCK_RETURN_TYPE();
                    stockReturnTypeEntity.Stock_Return_Type_Id = stockReturnType.Id;
                    stockReturnTypeEntity.Stock_Return_Type_Name = stockReturnType.Name;

                }
                return stockReturnTypeEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
