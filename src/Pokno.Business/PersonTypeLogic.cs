using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Data;

using Pokno.Model;
using Pokno.Entity;
using System.Linq.Expressions;
using Pokno.Business.Interfaces;
using System.Data.Entity.Core;

namespace Pokno.Business
{
    public class PersonTypeLogic : BusinessLogicBase<PersonType, PERSON_TYPE>
    {
        public PersonTypeLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new PersonTypeTranslator();
        }

        public bool Modify(PersonType personType)
        {
            try
            {
                PersonType mypersonType = personType as PersonType;
                Expression<Func<PERSON_TYPE, bool>> predicate = myPERSON_TYPE => myPERSON_TYPE.Person_Type_Id == personType.Id;
                PERSON_TYPE personTypeEntity = GetEntityBy(predicate);
                personTypeEntity.Person_Type_Name = personType.Name;
                personTypeEntity.Person_Type_Description = personType.Description;

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

        public bool Remove(PersonType personType)
        {
            try
            {
                Expression<Func<PERSON_TYPE, bool>> selector = myPERSON_TYPE => myPERSON_TYPE.Person_Type_Id == personType.Id;
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
