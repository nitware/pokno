using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;

namespace Pokno.Model.Translator
{
    public class CurrentEsnecilTranslator : TranslatorBase<CurrentEsnecil, CURRENT_ESNECIL>
    {
        private EsnecilTranslator _esnecilTranslator;

        public CurrentEsnecilTranslator()
        {
            _esnecilTranslator = new EsnecilTranslator();
        }

        public override CurrentEsnecil TranslateToModel(CURRENT_ESNECIL entity)
        {
            try
            {
                CurrentEsnecil model = null;
                if (entity != null)
                {
                    model = new CurrentEsnecil();
                    model.Esnecil = _esnecilTranslator.Translate(entity.ESNECIL);
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override CURRENT_ESNECIL TranslateToEntity(CurrentEsnecil model)
        {
            try
            {
                CURRENT_ESNECIL entity = null;
                if (model != null)
                {
                    entity = new CURRENT_ESNECIL();
                    entity.Esnecil_Id = model.Esnecil.Id;
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
