using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Pokno.Model.Model;
using Pokno.Entity;
using Pokno.Model.Translator;
using System.Linq.Expressions;
using Pokno.Business.Interfaces;
using System.Data.Entity.Core;

namespace Pokno.Business
{
    public class PersonCompanyLogic : BusinessLogicBase<PersonCompany, PERSON_COMPANY>
    {
        public PersonCompanyLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new PersonCompanyTranslator();
        }

        public PersonCompany Get(int id)
        {
            try
            {
                Expression<Func<PERSON_COMPANY, bool>> predicate = pc => pc.Person_Id == id;
                return GetModelBy(predicate);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public bool Modify(PersonCompany personCompany)
        {
            try
            {
                Expression<Func<PERSON_COMPANY, bool>> predicate = pc => pc.Person_Company_Id == personCompany.Id;
                PERSON_COMPANY personCompanyEntity = GetEntityBy(predicate);
                
                personCompanyEntity.Person_Id = personCompany.Person.Id;
                personCompanyEntity.Company_Id = personCompany.Company.Id;
                personCompanyEntity.Remarks = personCompany.Remarks;

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

        public bool Remove(PersonCompany personCompany)
        {
            try
            {
                Expression<Func<PERSON_COMPANY, bool>> selector = pc => pc.Person_Company_Id == personCompany.Id;
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
