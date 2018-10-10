using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Model.Model;
using Pokno.Entity;

namespace Pokno.Model.Translator
{
    public class ExpensesTranslator : TranslatorBase<Expenses, EXPENSES>
    {
        private PersonTranslator personTranslator;

        public ExpensesTranslator()
        {
            personTranslator = new PersonTranslator();
        }

        public override Expenses TranslateToModel(EXPENSES expensesEntity)
        {
            try
            {
                Expenses expenses = null;
                if (expensesEntity != null)
                {
                    expenses = new Expenses();
                    expenses.Id = expensesEntity.Expenses_Id;
                    expenses.OpeningBalace = expensesEntity.Opening_Balance;
                    expenses.AdditionalCash = expensesEntity.Additional_Cash;
                    expenses.CashAtHand = expensesEntity.Cash_At_Hand;
                    expenses.ClosingBalance = expensesEntity.Closing_Balance;
                    expenses.ExpensesDate = expensesEntity.Expenses_Date;
                    expenses.CreatedBy = personTranslator.Translate(expensesEntity.PERSON);
                    expenses.DateCreated = expensesEntity.Date_Created;
                }

                return expenses;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override EXPENSES TranslateToEntity(Expenses expenses)
        {
            try
            {
                EXPENSES expensesEntity = null;
                if (expenses != null)
                {
                    expensesEntity = new EXPENSES();
                    expensesEntity.Expenses_Id = expenses.Id;
                    expensesEntity.Opening_Balance = expenses.OpeningBalace;
                    expensesEntity.Additional_Cash = expenses.AdditionalCash;
                    expensesEntity.Cash_At_Hand = expenses.CashAtHand;
                    expensesEntity.Closing_Balance = expenses.ClosingBalance;
                    expensesEntity.Expenses_Date = expenses.ExpensesDate;
                    expensesEntity.Created_By_Person_Id = expenses.CreatedBy.Id;
                    expensesEntity.Date_Created = expenses.DateCreated;
                }

                return expensesEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }


}
