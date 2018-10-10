using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;
using Pokno.Model.Translator;
using Pokno.Business.Interfaces;
using System.Linq.Expressions;
using System.Data.Entity.Core;

namespace Pokno.Business
{
    public class ApplicationModeLogic : BusinessLogicBase<ApplicationMode, APPLICATION_MODE>
    {
        public ApplicationModeLogic(IRepository repository) : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            translator = new ApplicationModeTranslator();
        }

        public bool Modify(ApplicationMode applicationMode)
        {
            try
            {
                Expression<Func<APPLICATION_MODE, bool>> predicate = a => a.Application_Mode_Id == applicationMode.Id;
                APPLICATION_MODE entity = GetEntityBy(predicate);
                entity.Application_Mode_Name = applicationMode.Name;
                entity.Application_Mode_Description = applicationMode.Description;

                int rowsAffected = repository.Save();
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    throw new Exception(NoItemModified);
                }
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(ArgumentNullException);
            }
            catch (UpdateException)
            {
                throw new UpdateException(UpdateException);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(ApplicationMode applicationMode)
        {
            try
            {
                Expression<Func<APPLICATION_MODE, bool>> selector = b => b.Application_Mode_Id == applicationMode.Id;
                return base.Remove(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        





    }



}
