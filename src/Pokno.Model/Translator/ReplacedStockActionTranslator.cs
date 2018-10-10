using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;

namespace Pokno.Model.Translator
{
    public class ReplacedStockActionTranslator : TranslatorBase<ReplacedStockAction, REPLACED_STOCK_ACTION>
    {
        public override ReplacedStockAction TranslateToModel(REPLACED_STOCK_ACTION entity)
        {
            try
            {
                ReplacedStockAction model = null;
                if (entity != null)
                {
                    model = new ReplacedStockAction();
                    model.Id = (int)entity.Replaced_Stock_Action_Id;
                    model.Name = entity.Replaced_Stock_Action_Name;
                    model.Description = entity.Replaced_Stock_Action_Description;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override REPLACED_STOCK_ACTION TranslateToEntity(ReplacedStockAction model)
        {
            try
            {
                REPLACED_STOCK_ACTION entity = null;
                if (model != null)
                {
                    entity = new REPLACED_STOCK_ACTION();
                    entity.Replaced_Stock_Action_Id = model.Id;
                    entity.Replaced_Stock_Action_Name = model.Name;
                    entity.Replaced_Stock_Action_Description = model.Description;
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
