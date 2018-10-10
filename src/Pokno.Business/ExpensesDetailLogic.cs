using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Pokno.Model.Model;
using Pokno.Entity;
using Pokno.Model.Translator;
using System.Linq.Expressions;
using System.Data.Entity;
using Pokno.Business.Interfaces;
using System.Data.Entity.Core;

namespace Pokno.Business
{
    public class ExpensesDetailLogic : BusinessLogicBase<ExpensesDetail, EXPENSES_DETAIL>
    {
        public ExpensesDetailLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new ExpensesDetailTranslator();
        }

        public int Add(Expenses expenses)
        {
            try
            {
                foreach (ExpensesDetail expensesDetail in expenses.Details)
                {
                    expensesDetail.Expenses = expenses;
                }

                return base.Add(expenses.Details);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ExpensesDetail> Get(Expenses expenses)
        {
            try
            {
                Expression<Func<EXPENSES_DETAIL, bool>> selector = ed => ed.Expenses_Id == expenses.Id;
                return base.GetModelsBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ExpensesDetail> Get(DateTime expensisDate)
        {
            List<ExpensesDetail> expenses = null;

            try
            {
                //Expression<Func<EXPENSIS_DETAIL, bool>> selector = ed => DbFunctions.TruncateTime(ed.EXPENSIS.Expensis_Date) == expensisDate.Date;
                //string selector = "SELECT  EXPENSIS_DETAIL.* FROM  EXPENSIS INNER JOIN EXPENSIS_DETAIL ON EXPENSIS.Expensis_Id = EXPENSIS_DETAIL.Expensis_Id WHERE (Date(EXPENSIS.Expensis_Date) = '" + expensisDate.ToString(UtilityLogic.DateFormat) + "'";

                string selector = "SELECT EXPENSES_DETAIL.* FROM EXPENSES INNER JOIN EXPENSES_DETAIL ON EXPENSES.Expenses_Id = EXPENSES_DETAIL.Expenses_Id WHERE (Date(EXPENSES.Expenses_Date) = '" + expensisDate.ToString(BusinessLogicUtility.DateFormat) + "')";

                expenses = base.GetModelsBy(selector);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return expenses;
        }

        public bool Modify(List<ExpensesDetail> newExpensisDetails)
        {
            try
            {
                int rowsAdded = -1;
                bool modified = false;

                if (newExpensisDetails != null && newExpensisDetails.Count > 0)
                {
                    int difference = 0;
                    List<ExpensesDetail> oldExpensisDetails = Get(newExpensisDetails[0].Expenses);

                    int oldRecordCount = oldExpensisDetails.Count;
                    int newRecordCount = newExpensisDetails.Count;
                    if (oldRecordCount == newRecordCount)
                    {
                        modified = Modify(oldExpensisDetails, newExpensisDetails);
                        repository.Save();
                    }
                    else if (oldRecordCount > newRecordCount)
                    {
                        difference = oldRecordCount - newRecordCount;
                        List<ExpensesDetail> expensisDetailsToDiscard = oldExpensisDetails.Skip(newRecordCount).Take(difference).ToList();
                        List<ExpensesDetail> oldExpensisDetailsToModify = oldExpensisDetails.Take(newRecordCount).ToList();

                        if (Modify(oldExpensisDetailsToModify, newExpensisDetails))
                        {
                            repository.Save();
                            modified = Remove(expensisDetailsToDiscard);
                        }
                    }
                    else if (oldRecordCount < newRecordCount)
                    {
                        difference = newRecordCount - oldRecordCount;
                        List<ExpensesDetail> expensisDetailsToAdd = newExpensisDetails.Skip(oldRecordCount).Take(difference).ToList();

                        if (Modify(oldExpensisDetails, newExpensisDetails))
                        {
                            repository.Save();
                            
                            rowsAdded = Add(expensisDetailsToAdd);
                            modified = rowsAdded > -1 ? true : false;
                        }
                    }
                }
              
                return modified;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool Modify(List<ExpensesDetail> oldExpensisDetails, List<ExpensesDetail> newExpensisDetails)
        {
            try
            {
                for (int i = 0; i < oldExpensisDetails.Count; i++)
                {
                    oldExpensisDetails[i].Expenses = newExpensisDetails[i].Expenses;
                    oldExpensisDetails[i].CollectedBy = newExpensisDetails[i].CollectedBy;
                    oldExpensisDetails[i].Amount = newExpensisDetails[i].Amount;
                    oldExpensisDetails[i].Purpose = newExpensisDetails[i].Purpose;

                    if (!Modify(oldExpensisDetails[i]))
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Modify(ExpensesDetail expensisDetail)
        {
            try
            {
                int rowsAffected = 0;
                Expression<Func<EXPENSES_DETAIL, bool>> predicate = ed => ed.Expenses_Detail_Id == expensisDetail.Id;
                EXPENSES_DETAIL expensisDetailEntity = GetEntityBy(predicate);

                expensisDetailEntity.Expenses_Id = expensisDetail.Expenses.Id;
                expensisDetailEntity.Collected_By = expensisDetail.CollectedBy;
                expensisDetailEntity.Amount = expensisDetail.Amount;
                expensisDetailEntity.Purpose = expensisDetail.Purpose;
                rowsAffected = repository.Save();

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

        public bool Remove(List<ExpensesDetail> expensesDetails)
        {
            try
            {
                bool suceeded = false;
                if (expensesDetails != null && expensesDetails.Count > 0)
                {
                    foreach (ExpensesDetail expensesDetail in expensesDetails)
                    {
                        Expression<Func<EXPENSES_DETAIL, bool>> selector = ed => ed.Expenses_Detail_Id == expensesDetail.Id;
                        suceeded = base.Remove(selector);
                    }

                    //repository.Save();
                    //return true;
                }

                return suceeded;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(Expenses expenses)
        {
            try
            {
                if (expenses == null || expenses.Id <= 0)
                {
                    throw new Exception("Expenses cannot be empty! Please contact your system administrator");
                }

                Expression<Func<EXPENSES_DETAIL, bool>> selector = ed => ed.Expenses_Id == expenses.Id;
                List<ExpensesDetail> expensisDetails = base.GetModelsBy(selector);

                return Remove(expensisDetails);
            }
            catch (Exception)
            {
                throw;
            }
        }





    }

}
