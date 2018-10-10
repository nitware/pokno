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

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Pokno.Infrastructure.Interfaces;
using Pokno.Model;
using Pokno.Service;

namespace Pokno.Infratructure.Services
{
    public class BankService : ISetupService<Bank>
    {
        private IBusinessFacade _service;

        public BankService(IBusinessFacade service)
        {
            _service = service;
        }
        
        public List<Bank> LoadAll()
        {
            try
            {
                return _service.GetAllBanks();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Save(Bank bank)
        {
            try
            {
                return _service.AddBank(bank);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Modify(Bank bank)
        {
            try
            {
                return _service.ModifyBank(bank);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Remove(Bank bank)
        {
            try
            {
                return _service.RemoveBank(bank);
            }
            catch (Exception)
            {
                throw;
            }
        }



       


    }
}
