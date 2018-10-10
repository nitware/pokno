using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;

namespace Pokno.Model.Translator
{
    public class EsnecilTranslator : TranslatorBase<Esnecil, ESNECIL>
    {
        public override Esnecil TranslateToModel(ESNECIL entity)
        {
            try
            {
                Esnecil model = null;
                if (entity != null)
                {
                    model = new Esnecil();
                    model.Id = (int)entity.Esnecil_Id;
                    model.ValidationKey = entity.Validation_Key;
                    model.MachineCode = entity.Machine_Code;
                    model.EsnecilCode = entity.Esnecil_Code;
                    model.SerialCode = entity.Serial_Code;
                    model.ActivationDate = entity.Activation_Date;
                    model.IsEvaluation = entity.Is_Evaluation;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override ESNECIL TranslateToEntity(Esnecil model)
        {
            try
            {
                ESNECIL entity = null;
                if (model != null)
                {
                    entity = new ESNECIL();
                    entity.Esnecil_Id = model.Id;
                    entity.Validation_Key = model.ValidationKey;
                    entity.Machine_Code = model.MachineCode;
                    entity.Esnecil_Code = model.EsnecilCode;
                    entity.Serial_Code = model.SerialCode;
                    entity.Activation_Date = model.ActivationDate;
                    entity.Is_Evaluation = model.IsEvaluation;
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
