using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Model.Model;
using Pokno.Entity;

namespace Pokno.Model.Translator
{
    public class PersonCompanyTranslator : TranslatorBase<PersonCompany, PERSON_COMPANY>
    {
        private PersonTranslator personTranslator;
        private CompanyTranslator companyTranslator;

        public PersonCompanyTranslator()
        {
            personTranslator = new PersonTranslator();
            companyTranslator = new CompanyTranslator();
        }

        public override PersonCompany TranslateToModel(PERSON_COMPANY personCompanyEntity)
        {
            try
            {
                PersonCompany personCompany = null;
                if (personCompanyEntity != null)
                {
                    personCompany = new PersonCompany();
                    personCompany.Id = personCompanyEntity.Person_Company_Id;
                    personCompany.Person = personTranslator.Translate(personCompanyEntity.PERSON);
                    personCompany.Company = companyTranslator.Translate(personCompanyEntity.COMPANY);
                    personCompany.Remarks = personCompanyEntity.Remarks;
                }

                return personCompany;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override PERSON_COMPANY TranslateToEntity(PersonCompany personCompany)
        {
            try
            {
                PERSON_COMPANY personCompanyEntity = null;
                if (personCompany != null)
                {
                    personCompanyEntity = new PERSON_COMPANY();
                    personCompanyEntity.Person_Company_Id = personCompany.Id;
                    personCompanyEntity.Person_Id = personCompany.Person.Id;
                    personCompanyEntity.Company_Id = personCompany.Company.Id;
                    personCompanyEntity.Remarks = personCompany.Remarks;
                }

                return personCompanyEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }


}
