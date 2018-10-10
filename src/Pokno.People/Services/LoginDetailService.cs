using System;
using System.Net;
using System.Windows;
using System.Windows.Input;

using Pokno.Service;
using Pokno.People.Interfaces;
using Pokno.Model.Model;
using System.Collections.Generic;
using Pokno.Model;

namespace Pokno.People.Services
{
    public class LoginDetailService : ILoginDetailService
    {
        private IBusinessFacade _service;

        public LoginDetailService(IBusinessFacade service)
        {
            _service = service;
        }

        public List<LoginDetail> LoadAll()
        {
            try
            {
               return _service.GetAllLoginDetails();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Reset(LoginDetail loginDetail)
        {
            try
            {
                return _service.ResetLoginDetailPassword(loginDetail);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Modify(LoginDetail loginDetail)
        {
            try
            {
                return _service.ModifyLoginDetail(loginDetail);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public LoginDetail ChangePassword(Person person, string password)
        {
            try
            {
                return _service.ChangePassword(person, password);
            }
            catch (Exception)
            {
                throw;
            }
        }





    }
}
