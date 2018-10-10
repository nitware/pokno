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
using System.Data;

namespace Pokno.Business
{
    public class ReturnedStockReplacementLogic : BusinessLogicBase<ReturnedStockReplacement, RETURNED_STOCK_REPLACEMENT>
    {
        private ShelfLogic _shelfLogic;

        public ReturnedStockReplacementLogic(IRepository repository) : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            translator = new ReturnedStockReplacementTranslator();
            _shelfLogic = new ShelfLogic(repository);
        }

        public List<ReturnedStockReplacement> GetAllUntreated()
        {
            try
            {
                Expression<Func<RETURNED_STOCK_REPLACEMENT, bool>> selector = rsr => rsr.Replaced_Stock_Action_Id == null;
                return base.GetModelsBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Treat(List<ReturnedStockReplacement> replacedStocks)
        {
            try
            {
                bool treated = false;
                if (replacedStocks == null || replacedStocks.Count <= 0)
                {
                    throw new ArgumentNullException("replacedStocks");
                }

                base.OpenDatabaseConnectionIfClosed();
                using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    _shelfLogic.repository = repository;
                    foreach (ReturnedStockReplacement replacedStock in replacedStocks)
                    {
                        Expression<Func<RETURNED_STOCK_REPLACEMENT, bool>> selector = rsr => rsr.Returned_Stock_Replacement_Id == replacedStock.Id;
                        RETURNED_STOCK_REPLACEMENT entity = GetEntityBy(selector);
                        entity.Replaced_Stock_Action_Id = replacedStock.Action.Id;
                        entity.Action_Executor_Id = replacedStock.ActionExecutor.Id;
                        entity.Action_Reason = replacedStock.ActionReason;
                        entity.Action_Date = replacedStock.ActionDate;

                        int rowsAffected = base.Save();
                        if (rowsAffected <= 0)
                        {
                            throw new Exception("Save operation failed! Please try again.");
                        }

                        if (replacedStock.Action.Id == (int)ReturnedStockReplacement.ActionType.ReturnToShelf)
                        {
                            if (!_shelfLogic.ReturnStock(replacedStock.ReturnedDetail.SoldStock.ShelfStock))
                            {
                                throw new Exception("Returning stock back to shelf operation failed! Please try again");
                            }
                        }
                    }

                    treated = true;
                    base.CommitTransaction(transaction);
                }

                return treated;
            }
            catch (Exception)
            {
                throw;
            }
        }








    }

}
