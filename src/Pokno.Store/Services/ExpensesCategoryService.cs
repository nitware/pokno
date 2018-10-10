using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Model.Model;
using Pokno.Infrastructure.Interfaces;

namespace Pokno.Store.Services
{
    public class ExpensesCategoryService : ISetupService<ExpensesCategory>
    {
        private IBusinessFacade _service;

        public ExpensesCategoryService(IBusinessFacade service)
        {
            _service = service;
        }

        public List<ExpensesCategory> LoadAll()
        {
            try
            {
                return _service.GetAllExpensesCategories();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Save(ExpensesCategory expensesCategory)
        {
            try
            {
                return _service.AddExpensesCategory(expensesCategory);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Modify(ExpensesCategory expensesCategory)
        {
            try
            {
                return _service.ModifyExpensesCategory(expensesCategory);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Remove(ExpensesCategory expensesCategory)
        {
            try
            {
                return _service.RemoveExpensesCategory(expensesCategory);
            }
            catch (Exception)
            {
                throw;
            }
        }





    }

}
