using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;

namespace Pokno.Model.Translator
{
    public class ReturnedStockTranslator : TranslatorBase<ReturnedStock, RETURNED_STOCK>
    {
        private PersonTranslator personTranslator;

        public ReturnedStockTranslator()
        {
            personTranslator = new PersonTranslator();
        }

        public override ReturnedStock TranslateToModel(RETURNED_STOCK entity)
        {
            try
            {
                ReturnedStock model = null;
                if (entity != null)
                {
                    model = new ReturnedStock();
                    model.Id = entity.Returned_Stock_Id;
                    model.ReturnedDate = entity.Return_Date;
                    model.ReturnReason = entity.Return_Reason;
                    model.Remarks = entity.Remarks;
                    model.EnteredBy = personTranslator.Translate(entity.PERSON);
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override RETURNED_STOCK TranslateToEntity(ReturnedStock model)
        {
            try
            {
                RETURNED_STOCK entity = null;
                if (model != null)
                {
                    entity = new RETURNED_STOCK();
                    entity.Returned_Stock_Id = model.Id;
                    entity.Return_Date = model.ReturnedDate;
                    entity.Return_Reason = model.ReturnReason;
                    entity.Remarks = model.Remarks;
                    entity.Entered_By = model.EnteredBy.Id;
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
