using System;
using System.Net;
using System.Windows;
using System.Windows.Input;

using Pokno.Service;
using Pokno.People.Interfaces;
using Pokno.Model.Model;

namespace Pokno.People.Services
{
    public class LoginService : ILoginService
    {
        private IBusinessFacade _service;

        public LoginService(IBusinessFacade service)
        {
            _service = service;
        }

        public LoginDetail ValidateUser(string userName, string password)
        {
            
            return _service.ValidateUser(userName, password);
        }



    }
}
