using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Model.Model;
using Pokno.Entity;

namespace Pokno.Model.Translator
{
    public class CompanyTranslator : TranslatorBase<Company, COMPANY>
    {
        public override Company TranslateToModel(COMPANY companyEntity)
        {
            try
            {
                Company company = null;
                if (companyEntity != null)
                {
                    company = new Company();
                    company.Id = (int)companyEntity.Company_Id;
                    company.Name = companyEntity.Company_Name;
                    company.Address = companyEntity.Address;
                    company.Description = companyEntity.Description;
                    company.Website = companyEntity.Website;
                    company.Email = companyEntity.Email;
                    company.Phone = companyEntity.Phone;
                    company.Disclaimer = companyEntity.Disclaimer;
                }

                return company;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override COMPANY TranslateToEntity(Company company)
        {
            try
            {
                COMPANY companyEntity = null;
                if (company != null)
                {
                    companyEntity = new COMPANY();
                    companyEntity.Company_Id = company.Id;
                    companyEntity.Company_Name = company.Name;
                    companyEntity.Address = company.Address;
                    companyEntity.Description = company.Description;
                    companyEntity.Website = company.Website;
                    companyEntity.Email = company.Email;
                    companyEntity.Phone = company.Phone;
                    companyEntity.Disclaimer = company.Disclaimer;
                }

                return companyEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
