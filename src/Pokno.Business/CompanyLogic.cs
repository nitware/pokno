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
    public class CompanyLogic : BusinessLogicBase<Company, COMPANY>
    {
        public CompanyLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new CompanyTranslator();
        }

        public bool Modify(Company company)
        {
            try
            {
                Expression<Func<COMPANY, bool>> predicate = c => c.Company_Id == company.Id;
                COMPANY companyEntity = GetEntityBy(predicate);
               
                companyEntity.Company_Name = company.Name;
                companyEntity.Address = company.Address;
                companyEntity.Description = company.Description;
                companyEntity.Website = company.Website;
                companyEntity.Email = company.Email;
                companyEntity.Phone = company.Phone;
                companyEntity.Disclaimer = company.Disclaimer;

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

        public bool Remove(Company company)
        {
            try
            {
                Expression<Func<COMPANY, bool>> selector = c => c.Company_Id == company.Id;
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
