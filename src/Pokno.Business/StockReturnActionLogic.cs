using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;
using Pokno.Model.Translator;
using System.Linq.Expressions;
using Pokno.Business.Interfaces;
using System.Data.Entity.Core;

namespace Pokno.Business
{
    public class StockReturnActionLogic : BusinessLogicBase<StockReturnAction, STOCK_RETURN_ACTION>
    {
        public StockReturnActionLogic(IRepository repository) : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new StockReturnActionTranslator();
        }

        public bool Modify(StockReturnAction stockReturnAction)
        {
            try
            {
                Expression<Func<STOCK_RETURN_ACTION, bool>> predicate = sr => sr.Stock_Return_Action_Id == stockReturnAction.Id;
                STOCK_RETURN_ACTION stockReturnActionEntity = GetEntityBy(predicate);
                stockReturnActionEntity.Stock_Return_Action_Name = stockReturnAction.Name;
                stockReturnActionEntity.Stock_Return_Action_Description = stockReturnAction.Description;

                int rowsAffected = repository.Save();
                if (rowsAffected > 0)
                {
                    return true;
                }
                else if (rowsAffected == 0)
                {
                    throw new Exception(NoItemModified);
                }
                else
                {
                    throw new Exception(ErrowDuringProccesing);
                }
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

        public bool Remove(StockReturnAction stockReturnAction)
        {
            try
            {
                Expression<Func<STOCK_RETURN_ACTION, bool>> selector = sr => sr.Stock_Return_Action_Id == stockReturnAction.Id;
                bool suceeded = base.Remove(selector);

                return suceeded;
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
