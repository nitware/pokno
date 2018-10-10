using System;
using System.Net;
using System.Windows;
using System.Windows.Input;

using Pokno.Service;
using Pokno.Infrastructure.Interfaces;
using Pokno.Model;
using System.Collections.Generic;

namespace Pokno.People.Services
{
    public class RoleService : ISetupService<Role>
    {
        private IBusinessFacade _service;

        public RoleService(IBusinessFacade service)
        {
            _service = service;
        }

        public List<Role> LoadAll(Person person)
        {
            try
            {
                return _service.GetRoles(person);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Role> LoadAll()
        {
            try
            {
                return _service.GetAllRoles();
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        public bool Save(Role role)
        {
            try
            {
                return _service.AddRole(role);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Modify(Role role)
        {
            try
            {
                return _service.ModifyRole(role);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Remove(Role role)
        {
            try
            {
                return _service.RemoveRole(role);
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}
