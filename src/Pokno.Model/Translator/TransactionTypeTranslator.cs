using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;

namespace Pokno.Model.Translator
{
    public class TransactionTypeTranslator : TranslatorBase<TransactionType, TRANSACTION_TYPE>
    {
        public override TransactionType TranslateToModel(TRANSACTION_TYPE entity)
        {
            try
            {
                TransactionType model = null;
                if (entity != null)
                {
                    model = new TransactionType();
                    model.Id = (int)entity.Transaction_Type_Id;
                    model.Name = entity.Transaction_Type_Name;
                    model.Description = entity.Transaction_Type_Description;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override TRANSACTION_TYPE TranslateToEntity(TransactionType model)
        {
            try
            {
                TRANSACTION_TYPE entity = null;
                if (model != null)
                {
                    entity = new TRANSACTION_TYPE();
                    entity.Transaction_Type_Id = model.Id;
                    entity.Transaction_Type_Name = model.Name;
                    entity.Transaction_Type_Description = model.Description;
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
