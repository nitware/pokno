using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;

namespace Pokno.Model.Translator
{
    public class ExpensesCategoryTranslator : TranslatorBase<ExpensesCategory, EXPENSES_CATEGORY>
    {
        public override ExpensesCategory TranslateToModel(EXPENSES_CATEGORY entity)
        {
            try
            {
                ExpensesCategory model = null;
                if (entity != null)
                {
                    model = new ExpensesCategory();
                    model.Id = (int)entity.Expenses_Category_Id;
                    model.Name = entity.Expenses_Category_Name;
                    model.Description = entity.Expenses_Category_Description;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override EXPENSES_CATEGORY TranslateToEntity(ExpensesCategory model)
        {
            try
            {
                EXPENSES_CATEGORY entity = null;
                if (model != null)
                {
                    entity = new EXPENSES_CATEGORY();
                    entity.Expenses_Category_Id = model.Id;
                    entity.Expenses_Category_Name = model.Name;
                    entity.Expenses_Category_Description = model.Description;
                }

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }



    }



}
