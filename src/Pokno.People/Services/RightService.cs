using System;
using System.Net;
using System.Windows;
using System.Windows.Input;

using Pokno.Service;
using Pokno.Model;
using Pokno.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace Pokno.People.Services
{
    public class RightService : ISetupService<Right>
    {
        private IBusinessFacade _service;

        public RightService(IBusinessFacade service)
        {
            _service = service;
        }

        public List<Right> LoadAll()
        {
            try
            {
                return _service.GetAllRights();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Save(Right right)
        {
            try
            {
                return _service.AddRight(right);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Modify(Right right)
        {
            try
            {
                return _service.ModifyRight(right);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Remove(Right right)
        {
            try
            {
                return _service.RemoveRight(right);
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}
