using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Pokno.Model;
using Pokno.Entity;
using Pokno.Model.Translator;
using System.Linq.Expressions;
using Pokno.Business.Interfaces;
using System.Data.Entity.Core;

namespace Pokno.Business
{
    public class RightLogic : BusinessLogicBase<Right, RIGHT>
    {
        public RightLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new RightTranslator();
        }

        public bool Modify(Right right)
        {
            try
            {
                Expression<Func<RIGHT, bool>> selector = r => r.Right_Id == right.Id;
                RIGHT rightEntity = GetEntityBy(selector);
                rightEntity.Right_Name = right.Name;
                rightEntity.Right_Description = right.Description;

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

        public bool Remove(Right right)
        {
            try
            {
                Expression<Func<RIGHT, bool>> selector = r => r.Right_Id == right.Id;
                bool suceeded = base.Remove(selector);
                
                //repository.Save();
                return suceeded;
            }
            catch (Exception)
            {
                throw;
            }
        }




    }


}
