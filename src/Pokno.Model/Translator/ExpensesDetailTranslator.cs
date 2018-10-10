using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Model.Model;
using Pokno.Entity;

namespace Pokno.Model.Translator
{
    public class ExpensesDetailTranslator : TranslatorBase<ExpensesDetail, EXPENSES_DETAIL>
    {
        private ExpensesTranslator _expensisTranslator;
        private PaymentTypeTranslator _paymentTypeTranslator;
        private ExpensesCategoryTranslator _expensesCategoryTranslator;

        public ExpensesDetailTranslator()
        {
            _expensisTranslator = new ExpensesTranslator();
            _paymentTypeTranslator = new PaymentTypeTranslator();
            _expensesCategoryTranslator = new ExpensesCategoryTranslator();
        }

        public override ExpensesDetail TranslateToModel(EXPENSES_DETAIL entity)
        {
            try
            {
                ExpensesDetail model = null;
                if (entity != null)
                {
                    model = new ExpensesDetail();
                    model.Id = entity.Expenses_Detail_Id;
                    model.Expenses = _expensisTranslator.Translate(entity.EXPENSES);
                    model.Category = _expensesCategoryTranslator.Translate(entity.EXPENSES_CATEGORY);
                    model.CollectedBy = entity.Collected_By;
                    model.Amount = entity.Amount;
                    model.PaymentMode = _paymentTypeTranslator.Translate(entity.PAYMENT_TYPE);
                    model.Purpose = entity.Purpose;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override EXPENSES_DETAIL TranslateToEntity(ExpensesDetail model)
        {
            try
            {
                EXPENSES_DETAIL entity = null;
                if (model != null)
                {
                    entity = new EXPENSES_DETAIL();
                    entity.Expenses_Detail_Id = model.Id;
                    entity.Expenses_Id = model.Expenses.Id;
                    entity.Expenses_Category_Id = model.Category.Id;
                    entity.Collected_By = model.CollectedBy;
                    entity.Amount = model.Amount;
                    entity.Payment_Type_Id = model.PaymentMode.Id;
                    entity.Purpose = model.Purpose;
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
