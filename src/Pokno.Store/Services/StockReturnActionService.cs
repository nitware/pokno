using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Infrastructure.Interfaces;
using Pokno.Model.Model;
using Pokno.Service;

namespace Pokno.Store.Services
{
    public class StockReturnActionService : ISetupService<StockReturnAction>
    {
        private IBusinessFacade _service;

        public StockReturnActionService(IBusinessFacade service)
        {
            _service = service;
        }

        public List<StockReturnAction> LoadAll()
        {
            try
            {
                return _service.GetAllStockReturnActions();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Save(StockReturnAction stockReturnAction)
        {
            try
            {
                return _service.AddStockReturnAction(stockReturnAction);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Modify(StockReturnAction stockReturnAction)
        {
            try
            {
                return _service.ModifyStockReturnAction(stockReturnAction);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Remove(StockReturnAction stockReturnAction)
        {
            try
            {
                return _service.RemoveStockReturnAction(stockReturnAction);
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
