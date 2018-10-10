using System;
using System.Net;
using System.Windows;
using System.Windows.Input;

using Pokno.Service;
using Pokno.People.Interfaces;
using Pokno.Model;

namespace Pokno.People.Services
{
    public class AssignRightToRoleService : IAssignRightToRoleService
    {
        private IBusinessFacade _service;

        public AssignRightToRoleService(IBusinessFacade service)
        {
            _service = service;
        }
               
        public bool AssignRightToRole(Role role)
        {
            try
            {
                return _service.AssignRightToRole(role);
            }
            catch (Exception)
            {
                throw;
            }
        }

       
        



    }


}
