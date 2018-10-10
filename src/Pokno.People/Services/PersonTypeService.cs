using System;
using System.Net;
using System.Windows;
using System.Windows.Input;

using Pokno.Model;
using Pokno.Service;
using Pokno.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace Pokno.People.Services
{
    public class PersonTypeService : ISetupService<PersonType>
    {
        private IBusinessFacade _service;

        public PersonTypeService(IBusinessFacade service)
        {
            _service = service;
        }

        public List<PersonType> LoadAll()
        {
            try
            {
                return _service.GetAllPersonTypes();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Save(PersonType personType)
        {
            try
            {
                return _service.AddPersonType(personType);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Modify(PersonType personType)
        {
            try
            {
                return _service.ModifyPersonType(personType);
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
                return _service.RemovePersonType(personType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        
       
        
        

    }

}
