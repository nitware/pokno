using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;
using Pokno.Model.Translator;
using Pokno.Business.Interfaces;
using System.Linq.Expressions;
using System.Data.Entity.Core;

namespace Pokno.Business
{
    public class ExpensesCategoryLogic : BusinessLogicBase<ExpensesCategory, EXPENSES_CATEGORY>
    {
        public ExpensesCategoryLogic(IRepository repository) : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            translator = new ExpensesCategoryTranslator();
        }

        public bool Modify(ExpensesCategory expensesCategory)
        {
            try
            {
                Expression<Func<EXPENSES_CATEGORY, bool>> predicate = e => e.Expenses_Category_Id == expensesCategory.Id;
                EXPENSES_CATEGORY entity = GetEntityBy(predicate);
                entity.Expenses_Category_Name = expensesCategory.Name;
                entity.Expenses_Category_Description = expensesCategory.Description;

                repository.Save();

                return true;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(ArgumentNullException);
            }
            catch (UpdateException)
            {
                throw new UpdateException(UpdateException);
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
                Expression<Func<EXPENSES_CATEGORY, bool>> selector = e => e.Expenses_Category_Id == expensesCategory.Id;
                return base.Remove(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        



    }



}
