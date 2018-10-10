using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;

namespace Pokno.Model.Translator
{
    public class ReturnedStockReplacementTranslator : TranslatorBase<ReturnedStockReplacement, RETURNED_STOCK_REPLACEMENT>
    {
        private SoldStockTranslator _soldStockTranslator;
        private ReturnedStockDetailTranslator _returnedStockDetailTranslator;
        private ReplacedStockActionTranslator _replacedStockActionTranslator;
        private PersonTranslator _personTranslator;

        public ReturnedStockReplacementTranslator()
        {
            _soldStockTranslator = new SoldStockTranslator();
            _returnedStockDetailTranslator = new ReturnedStockDetailTranslator();
            _replacedStockActionTranslator = new ReplacedStockActionTranslator();
            _personTranslator = new PersonTranslator();
        }

        public override ReturnedStockReplacement TranslateToModel(RETURNED_STOCK_REPLACEMENT entity)
        {
            try
            {
                ReturnedStockReplacement model = null;
                if (entity != null)
                {
                    model = new ReturnedStockReplacement();
                    model.Id = entity.Returned_Stock_Replacement_Id;
                    model.ReturnedDetail = _returnedStockDetailTranslator.Translate(entity.RETURNED_STOCK_DETAIL);
                    model.SoldStockReplacement = _soldStockTranslator.Translate(entity.SOLD_STOCK);
                    model.Action = _replacedStockActionTranslator.Translate(entity.REPLACED_STOCK_ACTION);
                    model.ActionReason = entity.Action_Reason;
                    model.ActionDate = entity.Action_Date;
                    model.ActionExecutor = _personTranslator.Translate(entity.PERSON);
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override RETURNED_STOCK_REPLACEMENT TranslateToEntity(ReturnedStockReplacement model)
        {
            try
            {
                RETURNED_STOCK_REPLACEMENT entity = null;
                if (model != null)
                {
                    entity = new RETURNED_STOCK_REPLACEMENT();
                    entity.Returned_Stock_Replacement_Id = model.Id;
                    entity.Returned_Stock_Detail_Id = model.ReturnedDetail.Id;
                    entity.Sold_Stock_Id = model.SoldStockReplacement.Id;
                    entity.Action_Reason = model.ActionReason;
                    entity.Action_Date = model.ActionDate;

                    if (model.Action != null && model.Action.Id > 0)
                    {
                        entity.Replaced_Stock_Action_Id = model.Action.Id;
                    }

                    if (model.ActionExecutor != null && model.ActionExecutor.Id > 0)
                    {
                        entity.Action_Executor_Id = model.ActionExecutor.Id;
                    }
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
