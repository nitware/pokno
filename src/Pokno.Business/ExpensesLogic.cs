using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Transactions;
using System.Data;
using Pokno.Model.Model;
using Pokno.Entity;
using Pokno.Model;
using System.Linq.Expressions;
using Pokno.Model.Translator;
using System.Data.Entity;
using Pokno.Model.Views;
using Pokno.Business.Interfaces;
using System.Data.Entity.Core;
using Pokno.Business.Helper;

namespace Pokno.Business
{
    public class ExpensesLogic : BusinessLogicBase<Expenses, EXPENSES>
    {
        private SoldStockLogic outgoingStockLogic;
        private ExpensesDetailLogic expensesDetailLogic;
        private SoldStockBatchLogic soldStockBatchLogic;

        public ExpensesLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new ExpensesTranslator();
            expensesDetailLogic = new ExpensesDetailLogic(repository);
            outgoingStockLogic = new SoldStockLogic(repository);
            soldStockBatchLogic = new SoldStockBatchLogic(repository);
        }

        public decimal GetSupplierExpensesBy(DateTime fromDate, DateTime toDate)
        {
            decimal? supplierExpenses = 0;

            try
            {
                DateTime endDate = Range.Get(DateRange.End, toDate);
                DateTime startDate = Range.Get(DateRange.Start, fromDate);

                string query = "SELECT Sum(Amount) FROM VW_EXPENSES where Expenses_Date >= '" + startDate.ToString(BusinessLogicUtility.DateTimeFormat) + "' AND Expenses_Date <= '" + endDate.ToString(BusinessLogicUtility.DateTimeFormat) + "' AND Expenses_Category_Name = 'Stock Purchase'";
                supplierExpenses = (from ex in repository.DbContext.Database.SqlQuery<decimal?>(query) select ex).SingleOrDefault();
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return supplierExpenses.GetValueOrDefault();
        }
        public decimal GetMonthlyTotal(int year, int month)
        {
            decimal? totalExpenses = 0;

            try
            {
                string currentMonth = month.ToString();
                if (currentMonth.Length == 1)
                {
                    currentMonth = "0" + currentMonth;
                }

                string query = "SELECT Sum(Amount) FROM VW_EXPENSES where Expenses_Year = '" + year + "' AND Expenses_Month = '" + currentMonth + "'";
                totalExpenses = (from ex in repository.DbContext.Database.SqlQuery<decimal?>(query) select ex).SingleOrDefault();
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return totalExpenses.GetValueOrDefault();
        }
        public List<StoreExpenses> GetMonthly(int year, int month)
        {
            List<StoreExpenses> expenses = null;

            try
            {
                string currentMonth = month.ToString();
                if (currentMonth.Length == 1)
                {
                    currentMonth = "0" + currentMonth;
                }

                string query = "SELECT * FROM VW_EXPENSES where Expenses_Year = '" + year + "' AND Expenses_Month = '" + currentMonth + "'";

                expenses = GetHelper(query);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return expenses;
        }
        public List<StoreExpenses> GetYearly(int year)
        {
            List<StoreExpenses> expenses = null;

            try
            {
                string query = "SELECT * FROM VW_EXPENSES where Expenses_Year = '" + year + "'";
                expenses = GetHelper(query);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return expenses;
        }
        public List<StoreExpenses> GetByDateRange(DateTime fromDate, DateTime toDate)
        {
            List<StoreExpenses> expenses = null;

            try
            {
                DateTime endDate = Range.Get(DateRange.End, toDate);
                DateTime startDate = Range.Get(DateRange.Start, fromDate);

                string query = "SELECT * FROM VW_EXPENSES where Expenses_Date >= '" + startDate.ToString(BusinessLogicUtility.DateTimeFormat) + "' AND Expenses_Date <= '" + endDate.ToString(BusinessLogicUtility.DateTimeFormat) + "'";
                expenses = GetHelper(query);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return expenses;
        }

        private List<StoreExpenses> GetHelper(string query)
        {
            List<StoreExpenses> expenses = null;

            try
            {
                expenses = (from e in repository.DbContext.Database.SqlQuery<VW_EXPENSES>(query)
                                                select new StoreExpenses
                                                {
                                                    Amount = e.Amount,
                                                    ExpensesCategory = e.Expenses_Category_Name,
                                                    ExpensesMonthString = e.Expenses_Month,
                                                    ExpensesYearString = e.Expenses_Year,
                                                    ExpensesMonth  = e.Expenses_Date.Month,
                                                    ExpensesDate = e.Expenses_Date,
                                                    Purpose = e.Purpose,
                                                    Initiator = e.Initiator,
                                                    CollectedBy = e.Collected_By,
                                                }).ToList();
            }
            catch(Exception ex)
            {
                base.SuppressError(ex);
            }

            return expenses;
        }
        public decimal GetYearlyTotal(int year)
        {
            decimal? totalExpenses = 0;

            try
            {
                string query = "SELECT Sum(Amount) FROM VW_EXPENSES where Expenses_Year = '" + year + "'";
                totalExpenses = (from ex in repository.DbContext.Database.SqlQuery<decimal?>(query) select ex).SingleOrDefault();
            }
            catch(Exception ex)
            {
                base.SuppressError(ex);
            }

            return totalExpenses.GetValueOrDefault();
        }

        public override Expenses Add(Expenses expenses)
        {
            try
            {
                if (expenses == null)
                {
                    throw new ArgumentNullException("expenses");
                }
                
                Expenses newExpenses = null;
                if (AlreadyExist(expenses))
                {
                    return Update(expenses);
                }
                else
                {
                    base.OpenDatabaseConnectionIfClosed();
                    using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                    {
                        newExpenses = base.Add(expenses);

                        if (newExpenses != null)
                        {
                            expensesDetailLogic.repository = repository;
                            newExpenses.Details = expenses.Details;
                            
                            int affectedRecords = expensesDetailLogic.Add(newExpenses);
                            if (affectedRecords <= 0 || affectedRecords != expenses.Details.Count)
                            {
                                throw new Exception("Expeses Details save operation failed! " + TryAgain);
                            }
                        }

                        base.CommitTransaction(transaction);
                    }
                }

                return newExpenses;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Expenses Update(Expenses expenses)
        {
            try
            {
                if (expenses == null || expenses.Id <= 0)
                {
                    throw new ArgumentNullException("expenses");
                }

                bool done = false;
                base.OpenDatabaseConnectionIfClosed();
                using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    if (Modify(expenses))
                    {
                        expensesDetailLogic.repository = repository;
                        if (expenses.Details != null && expenses.Details.Count > 0)
                        {
                            foreach (ExpensesDetail expensisDetails in expenses.Details)
                            {
                                expensisDetails.Expenses = expenses;
                            }

                            done = expensesDetailLogic.Modify(expenses.Details);
                        }
                        else
                        {
                            done = expensesDetailLogic.Remove(expenses);
                        }
                    }

                    base.CommitTransaction(transaction);
                }

                return done ? expenses : null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Modify(Expenses expenses)
        {
            try
            {
                Expression<Func<EXPENSES, bool>> predicate = e => e.Expenses_Id == expenses.Id;
                EXPENSES expensesEntity = GetEntityBy(predicate);

                expensesEntity.Opening_Balance = expenses.OpeningBalace;
                expensesEntity.Additional_Cash = expenses.AdditionalCash;
                expensesEntity.Cash_At_Hand = expenses.CashAtHand;
                expensesEntity.Closing_Balance = expenses.ClosingBalance;
                expensesEntity.Expenses_Date = expenses.ExpensesDate;
                expensesEntity.Created_By_Person_Id = expenses.CreatedBy.Id;
                expensesEntity.Date_Created = expenses.DateCreated;

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
        
        private bool AlreadyExist(Expenses expenses)
        {
            try
            {
                if (expenses != null && expenses.Id > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Expenses Get(DateTime selectedExpensesDate)
        {
            Expenses expenses = null;

            try
            {
                expenses = new Expenses();
                decimal transactionDiscount = 0;
                string selectorQuery = "SELECT * FROM EXPENSES where Date(Expenses_Date) = '" + selectedExpensesDate.ToString(BusinessLogicUtility.DateFormat) + "'";
                string predicateQuery = "SELECT Sum(Selling_Price) AS Selling_Price FROM VW_SOLD_STOCK where Date(Date_Sold) = '" + selectedExpensesDate.ToString(BusinessLogicUtility.DateFormat) + "'";
                string batchPredicateQuery = "SELECT * FROM SOLD_STOCK_BATCH where Date(Date_Sold) = '" + selectedExpensesDate.ToString(BusinessLogicUtility.DateFormat) + "'";
                                
                EXPENSES expensesEntity = repository.DbContext.Database.SqlQuery<EXPENSES>(selectorQuery).SingleOrDefault();
                if (expensesEntity != null && expensesEntity.Expenses_Id > 0)
                {
                    
                    expenses = base.GetModelBy(e => e.Expenses_Id == expensesEntity.Expenses_Id);
                    if (expenses != null && expenses.Id > 0)
                    {
                        expenses.Details = expensesDetailLogic.Get(expenses);
                    }
                }
                               
                List<SoldStockBatch> soldStockBatches = soldStockBatchLogic.GetModelsBy(batchPredicateQuery);
                if (soldStockBatches != null && soldStockBatches.Count > 0)
                {
                    transactionDiscount = soldStockBatches.Sum(ssb => ssb.TotalDiscount);
                }

                //decimal salesAmount = GetTotalSalesBy(predicateQuery);
                //expenses.TotalSalesAmount = salesAmount - transactionDiscount;
                //expenses.OpeningBalace = GetOpeningBalance(selectedExpensesDate);
                //expenses.AdditionalCash = expenses.AdditionalCash.HasValue ? expenses.AdditionalCash.Value : 0;
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return expenses;
        }

        private decimal GetTotalSalesBy(string query)
        {
            decimal? totalSales = 0;

            try
            {
                totalSales = (from s in repository.DbContext.Database.SqlQuery<decimal?>(query) select s).SingleOrDefault();
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return totalSales.HasValue ? totalSales.Value : 0;
        }

        public List<StoreExpenses> GetBy(DateTime date)
        {
            List<StoreExpenses> expenses = null;

            try
            {
                DateTime endDate = Range.Get(DateRange.End, date);
                DateTime startDate = Range.Get(DateRange.Start, date);

                string query = "SELECT * FROM VW_EXPENSES where Expenses_Date >= '" + startDate.ToString(BusinessLogicUtility.DateTimeFormat) + "' AND Expenses_Date <= '" + endDate.ToString(BusinessLogicUtility.DateTimeFormat) + "'";
                expenses = (from e in base.repository.DbContext.Database.SqlQuery<VW_EXPENSES>(query)
                                                    select new StoreExpenses
                                                     {
                                                         Initiator = e.Initiator,
                                                         CollectedBy = e.Collected_By,
                                                         ExpensesCategory = e.Expenses_Category_Name,
                                                         Purpose = e.Purpose,
                                                         Amount = e.Amount,
                                                         ExpensesDate = e.Expenses_Date,
                                                     }).ToList();
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return expenses;
        }
        
        //public Expenses Get(DateTime selectedExpensesDate)
        //{
        //    try
        //    {
        //        decimal salesAmount = 0;
        //        decimal totalSalesAmount = 0;
        //        decimal totalSalesDiscount = 0;
        //        decimal transactionDiscount = 0;
        //        Expression<Func<EXPENSES, bool>> selector = null;
        //        List<SoldStock> soldstocks = new List<SoldStock>();
        //        List<SoldStockBatch> soldStockBatches = new List<SoldStockBatch>();

        //         string predicateQuery = null;
        //         string batchPredicateQuery = null;
        //         string selectorQuery = null;

        //        DateTime maximumExpensisDate = GetMaximumDate();
        //        DateTime nextMinimumExpensisDate = GetNextMinimumDate(selectedExpensesDate);

        //        Expenses expensis = new Expenses();
        //        if (nextMinimumExpensisDate == DateTime.MinValue)
        //        {
        //            //predicateQuery = "SELECT Actual_Selling_Price, Discount FROM VW_SOLD_STOCK where Date(Date_Sold) <= '" + selectedExpensisDate.ToString(UtilityLogic.DateFormat) + "'";
        //            //batchPredicateQuery = "SELECT * FROM SOLD_STOCK_BATCH where Date(Date_Sold) <= '" + selectedExpensisDate.ToString(UtilityLogic.DateFormat) + "'";

        //            predicateQuery = "SELECT Selling_Price, Discount FROM VW_SOLD_STOCK where Date(Date_Sold) = '" + selectedExpensesDate.ToString(UtilityLogic.DateFormat) + "'";
        //            batchPredicateQuery = "SELECT * FROM SOLD_STOCK_BATCH where Date(Date_Sold) = '" + selectedExpensesDate.ToString(UtilityLogic.DateFormat) + "'";


        //            soldstocks = GetSoldStocks(predicateQuery);

        //            //List<SOLD_STOCK> soldStockEntities = repository.DbContext.Database.SqlQuery<SOLD_STOCK>(predicateQuery).ToList();
        //            //soldstocks = outgoingStockLogic.translator.Translate(soldStockEntities);

        //            //soldstocks = outgoingStockLogic.GetModelsBy(predicateQuery);
        //            if (soldstocks == null || soldstocks.Count <= 0)
        //            {
        //                soldstocks = new List<SoldStock>();
        //            }

        //            //if (soldstocks != null && soldstocks.Count > 0)
        //            //{
        //            //    soldstocks = outgoingStockLogic.GetModelsBy(predicate);
        //            //}
        //            //else
        //            //{
        //            //    soldstocks = new List<OutgoingStock>();
        //            //}
        //        }
        //        else
        //        {
        //            TimeSpan dateDifference = selectedExpensesDate - maximumExpensisDate;
        //            if (dateDifference.Days > 0)
        //            {
        //                DateTime maximumExpensisNextDate = maximumExpensisDate.Date.AddDays(1);

        //                //selector = e => DbFunctions.TruncateTime(e.Expensis_Date) == selectedExpensisDate.Date;
        //                //predicate = ss => DbFunctions.TruncateTime(ss.SOLD_STOCK_BATCH.Date_Sold) >= maximumExpensisNextDate && DbFunctions.TruncateTime(ss.SOLD_STOCK_BATCH.Date_Sold) <= selectedExpensisDate.Date;
        //                //batchPredicate = ssb => DbFunctions.TruncateTime(ssb.Date_Sold) >= maximumExpensisNextDate && DbFunctions.TruncateTime(ssb.Date_Sold) <= selectedExpensisDate.Date;

        //                selectorQuery = "SELECT * FROM EXPENSIS where Date(Expensis_Date) = '" + selectedExpensesDate.ToString(UtilityLogic.DateFormat) + "'";
        //                predicateQuery = "SELECT Actual_Selling_Price, Discount FROM  VW_SOLD_STOCK where Date(Date_Sold) >= '" + maximumExpensisNextDate.ToString(UtilityLogic.DateFormat) + "' AND Date(Date_Sold) <= '" + selectedExpensesDate.ToString(UtilityLogic.DateFormat) + "'";
        //                batchPredicateQuery = "SELECT * FROM SOLD_STOCK_BATCH where Date(Date_Sold) >= '" + maximumExpensisNextDate.ToString(UtilityLogic.DateFormat) + "' AND Date(Date_Sold) <= '" + selectedExpensesDate.ToString(UtilityLogic.DateFormat) + "'";

        //                //List<SOLD_STOCK> soldStockEntities = repository.DbContext.Database.SqlQuery<SOLD_STOCK>(predicateQuery).ToList();
        //                soldstocks = GetSoldStocks(predicateQuery);
        //                //soldstocks = outgoingStockLogic.translator.Translate(soldStockEntities);


        //                //soldstocks = outgoingStockLogic.GetModelsBy(predicateQuery);
        //                if (soldstocks != null && soldstocks.Count == 0)
        //                {
        //                    //predicate = ss => DbFunctions.TruncateTime(ss.SOLD_STOCK_BATCH.Date_Sold) == maximumExpensisDate.Date;

        //                    predicateQuery = "SELECT Actual_Selling_Price, Discount FROM VW_SOLD_STOCK where Date(Date_Sold) = '" + maximumExpensisNextDate.ToString(UtilityLogic.DateFormat) + "'";
        //                    soldstocks = GetSoldStocks(predicateQuery);
                            
        //                    //List<SOLD_STOCK> entities = repository.DbContext.Database.SqlQuery<SOLD_STOCK>(predicateQuery).ToList();
        //                    //soldstocks = outgoingStockLogic.translator.Translate(soldStockEntities);

        //                    //soldstocks = outgoingStockLogic.GetModelsBy(predicateQuery);
        //                }
        //            }
        //            else if (dateDifference.Days < 0)
        //            {
        //                DateTime nextMinimumExpensisNextDate = nextMinimumExpensisDate.Date.AddDays(1);
        //                //selector = e => DbFunctions.TruncateTime(e.Expensis_Date) == nextMinimumExpensisDate.Date;
        //                //predicate = ss => DbFunctions.TruncateTime(ss.SOLD_STOCK_BATCH.Date_Sold) >= nextMinimumExpensisNextDate && DbFunctions.TruncateTime(ss.SOLD_STOCK_BATCH.Date_Sold) <= selectedExpensisDate.Date;
        //                //batchPredicate = ssb => DbFunctions.TruncateTime(ssb.Date_Sold) >= nextMinimumExpensisNextDate && DbFunctions.TruncateTime(ssb.Date_Sold) <= selectedExpensisDate.Date;

        //                selectorQuery = "SELECT * FROM EXPENSIS where Date(Expensis_Date) = '" + nextMinimumExpensisNextDate.ToString(UtilityLogic.DateFormat) + "'";
        //                predicateQuery = "SELECT Actual_Selling_Price, Discount FROM VW_SOLD_STOCK where Date(Date_Sold) >= '" + nextMinimumExpensisNextDate.ToString(UtilityLogic.DateFormat) + "' AND Date(Date_Sold) <= '" + selectedExpensesDate.ToString(UtilityLogic.DateFormat) + "'";
        //                batchPredicateQuery = "SELECT * FROM SOLD_STOCK_BATCH where Date(Date_Sold) >= '" + nextMinimumExpensisNextDate.ToString(UtilityLogic.DateFormat) + "' AND Date(Date_Sold) <= '" + selectedExpensesDate.ToString(UtilityLogic.DateFormat) + "'";

        //                soldstocks = GetSoldStocks(predicateQuery);

        //                //soldstocks = outgoingStockLogic.translator.Translate(repository.DbContext.Database.SqlQuery<SOLD_STOCK>(predicateQuery).ToList());

        //                //soldstocks = outgoingStockLogic.GetModelsBy(predicateQuery);
        //            }
        //            else
        //            {
        //                //selector = e => DbFunctions.TruncateTime(e.Expensis_Date) == selectedExpensisDate.Date;
        //                //predicate = ss => DbFunctions.TruncateTime(ss.SOLD_STOCK_BATCH.Date_Sold) == selectedExpensisDate.Date;
        //                //batchPredicate = ssb => DbFunctions.TruncateTime(ssb.Date_Sold) == selectedExpensisDate.Date;

        //                selectorQuery = "SELECT * FROM EXPENSIS where Date(Expensis_Date) = '" + selectedExpensesDate.ToString(UtilityLogic.DateFormat) + "'";
        //                predicateQuery = "SELECT Actual_Selling_Price, Discount FROM VW_SOLD_STOCK where Date(Date_Sold) = '" + selectedExpensesDate.ToString(UtilityLogic.DateFormat) + "'";
        //                batchPredicateQuery = "SELECT * FROM SOLD_STOCK_BATCH where Date(Date_Sold) = '" + selectedExpensesDate.ToString(UtilityLogic.DateFormat) + "'";

        //                soldstocks = GetSoldStocks(predicateQuery);

        //                //soldstocks = outgoingStockLogic.translator.Translate(repository.DbContext.Database.SqlQuery<SOLD_STOCK>(predicateQuery).ToList());


        //                //soldstocks = outgoingStockLogic.GetModelsBy(predicateQuery);
        //            }

        //            EXPENSES expensisEntity = repository.DbContext.Database.SqlQuery<EXPENSES>(selectorQuery).SingleOrDefault();
        //            if (expensisEntity != null && expensisEntity.Expenses_Id > 0)
        //            {
        //                selector = e => e.Expenses_Id == expensisEntity.Expenses_Id;
                        
        //                expensis = base.GetModelBy(selector);
        //                if (expensis != null)
        //                {
        //                    expensis.ExpensesDetails = expensisDetailLogic.Get(selectedExpensesDate);
        //                }
        //                else
        //                {
        //                    expensis = new Expenses();
        //                }
        //            }
        //            else
        //            {
        //                expensis = new Expenses();
        //            }
        //        }

               
        //        if (soldstocks != null && soldstocks.Count > 0)
        //        {
        //            //salesAmount = soldstocks.Sum(ss => ss.ActualSellingPrice);
        //            totalSalesDiscount = (decimal)soldstocks.Sum(ss => ss.Discount);
        //        }

        //        soldStockBatches = soldStockBatchLogic.GetModelsBy(batchPredicateQuery);
        //        if (soldStockBatches != null && soldStockBatches.Count > 0)
        //        {
        //            transactionDiscount = soldStockBatches.Sum(ssb => ssb.TotalDiscount);
        //        }

        //        totalSalesAmount = salesAmount - (totalSalesDiscount + transactionDiscount);
                
        //        expensis.TotalSalesAmount = totalSalesAmount;
        //        expensis.OpeningBalace = GetOpeningBalance(selectedExpensesDate);
        //        return expensis;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //private List<SoldStock> GetSoldStocks(string query)
        //{
        //    try
        //    {

        //        List<SoldStock> soldStocks = (from s in repository.DbContext.Database.SqlQuery<VW_SOLD_STOCK>(query)
        //                                      select new SoldStock
        //                                            {
        //                                                SellingPrice = (decimal)s.Selling_Price,
        //                                                Discount = s.Discount.HasValue ? (decimal)s.Discount.Value : (decimal)0
        //                                            }).ToList();

        //        return soldStocks;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public DateTime GetMaximumDate()
        //{
        //    try
        //    {
        //        List<Expenses> expenses = base.GetAll();
        //        if (expenses != null && expenses.Count > 0)
        //        {
        //            return expenses.Max(e => e.ExpensesDate);
        //        }

        //        return DateTime.MinValue;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public DateTime GetNextMinimumDate(DateTime referenceDate)
        {
            DateTime nextMinimumDate = DateTime.MinValue;

            try
            {
                string query = "SELECT * FROM EXPENSES where Date(Expenses_Date) < '" + referenceDate.ToString("yyyy-MM-dd") + "'";

                List<EXPENSES> expensesEntities = repository.DbContext.Database.SqlQuery<EXPENSES>(query).ToList();
                if (expensesEntities != null && expensesEntities.Count > 0)
                {
                    List<Expenses> expenses = translator.Translate(expensesEntities);
                    if (expenses != null && expenses.Count > 0)
                    {
                        expenses = expenses.OrderByDescending(e => e.ExpensesDate).ToList();
                        Expenses expensis = expenses.FirstOrDefault();
                        nextMinimumDate = expensis.ExpensesDate;
                    }
                }
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return nextMinimumDate;
        }

        public Expenses GetBy(long id)
        {
            try
            {
                Expression<Func<EXPENSES, bool>> selector = e => e.Expenses_Id == id;
                return base.GetModelBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private decimal GetOpeningBalance(DateTime selectedDate)
        {
            decimal openingBalance = 0;

            try
            {
                
                DateTime nextMinimumExpensesDate = GetNextMinimumDate(selectedDate);
                string date = nextMinimumExpensesDate.ToString("yyyy-MM-dd");

                string query = "SELECT * FROM EXPENSES where Date(Expenses_Date) = '" + nextMinimumExpensesDate.ToString("yyyy-MM-dd") + "'";
                EXPENSES expensesEntity = repository.DbContext.Database.SqlQuery<EXPENSES>(query).SingleOrDefault();

                //EXPENSES expensesEntity = repository.DbContext.Database.SqlQuery<EXPENSES>(query).FirstOrDefault();

                if (expensesEntity != null && expensesEntity.Expenses_Id > 0)
                {
                    Expenses expenses = base.GetModelBy(e => e.Expenses_Id == expensesEntity.Expenses_Id);
                    if (expenses != null)
                    {
                        openingBalance = expenses.ClosingBalance;
                    }
                }
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return openingBalance;
        }

        

        
    }



}
