using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;

namespace Pokno.Model.Translator
{
    public class StockReturnActionTranslator : TranslatorBase<StockReturnAction, STOCK_RETURN_ACTION>
    {
        public override StockReturnAction TranslateToModel(STOCK_RETURN_ACTION entity)
        {
            try
            {
                StockReturnAction model = null;
                if (entity != null)
                {
                    model = new StockReturnAction();
                    model.Id = (int)entity.Stock_Return_Action_Id;
                    model.Name = entity.Stock_Return_Action_Name;
                    model.Description = entity.Stock_Return_Action_Description;
                }
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override STOCK_RETURN_ACTION TranslateToEntity(StockReturnAction model)
        {
            try
            {
                STOCK_RETURN_ACTION entity = null;
                if (model != null)
                {
                    entity = new STOCK_RETURN_ACTION();
                    entity.Stock_Return_Action_Id = model.Id;
                    entity.Stock_Return_Action_Name = model.Name;
                    entity.Stock_Return_Action_Description = model.Description;
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
