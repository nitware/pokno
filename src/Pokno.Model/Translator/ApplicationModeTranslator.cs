using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;

namespace Pokno.Model.Translator
{
    public class ApplicationModeTranslator : TranslatorBase<ApplicationMode, APPLICATION_MODE>
    {
        public override ApplicationMode TranslateToModel(APPLICATION_MODE entity)
        {
            try
            {
                ApplicationMode model = null;
                if (entity != null)
                {
                    model = new ApplicationMode();
                    model.Id = (int)entity.Application_Mode_Id;
                    model.Name = entity.Application_Mode_Name;
                    model.Description = entity.Application_Mode_Description;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override APPLICATION_MODE TranslateToEntity(ApplicationMode model)
        {
            try
            {
                APPLICATION_MODE entity = null;
                if (model != null)
                {
                    entity = new APPLICATION_MODE();
                    entity.Application_Mode_Id = model.Id;
                    entity.Application_Mode_Name = model.Name;
                    entity.Application_Mode_Description = model.Description;
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
