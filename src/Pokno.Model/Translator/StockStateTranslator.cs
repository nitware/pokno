using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Entity;

namespace Pokno.Model
{
    public class StockStateTranslator : TranslatorBase<StockState, STOCK_STATE>
    {
        public override StockState TranslateToModel(STOCK_STATE stockStateEntity)
        {
            try
            {
                StockState stockState = null;
                if (stockStateEntity != null)
                {
                    stockState = new StockState();
                    stockState.Id = (int)stockStateEntity.Stock_State_Id;
                    stockState.Name = stockStateEntity.Stock_State_Name;
                    stockState.Description = stockStateEntity.Stock_State_Description;
                }
                return stockState;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override STOCK_STATE TranslateToEntity(StockState stockState)
        {
            try
            {
                STOCK_STATE stockStateEntity = null;
                if (stockState != null)
                {
                    stockStateEntity = new STOCK_STATE();
                    stockStateEntity.Stock_State_Id = stockState.Id;
                    stockStateEntity.Stock_State_Name = stockState.Name;
                    stockStateEntity.Stock_State_Description = stockState.Description;
                }
                return stockStateEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
