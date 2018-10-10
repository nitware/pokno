using System;
using System.Net;
using System.Windows;
using System.Windows.Input;

using Pokno.Service;
using Pokno.Infrastructure.Interfaces;
using Pokno.Model.Model;
using System.Collections.Generic;

namespace Pokno.People.Services
{
    public class CompanyRepService : ISetupService<PersonCompany>
    {
        private IBusinessFacade _service;

        public CompanyRepService(IBusinessFacade service)
        {
            _service = service;
        }

        public List<PersonCompany> LoadAll()
        {
            try
            {
                return _service.GetAllPersonCompany();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Save(PersonCompany personCompany)
        {
            try
            {
                return _service.AddPersonCompany(personCompany);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Modify(PersonCompany personCompany)
        {
            try
            {
                return _service.ModifyPersonCompany(personCompany);
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
                return _service.RemovePersonCompany(personCompany);
            }
            catch (Exception)
            {
                throw;
            }
        }

        


    }


}
