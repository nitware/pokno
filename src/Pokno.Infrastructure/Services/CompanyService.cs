using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Pokno.Infrastructure.Interfaces;
using System.Collections.ObjectModel;
using Pokno.Service;
using Pokno.Model.Model;
using System.Collections.Generic;

namespace Pokno.Infratructure.Services
{
    public class CompanyService : ISetupService<Company>
    {
        private IBusinessFacade _service;

        public CompanyService(IBusinessFacade service)
        {
            _service = service;
        }

        public List<Company> LoadAll()
        {
            try
            {
                return _service.GetAllCompany();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Save(Company company)
        {
            try
            {
                return _service.AddCompany(company);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Modify(Company company)
        {
            try
            {
                return _service.ModifyCompany(company);
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
                return _service.RemoveCompany(company);
            }
            catch (Exception)
            {
                throw;
            }
        }



      
    }
}
