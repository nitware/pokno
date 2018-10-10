using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Data;

using Pokno.Model;
using Pokno.Entity;
using System.Linq.Expressions;
using Pokno.Business.Interfaces;
using System.Data.Entity.Core;

namespace Pokno.Business
{
    public class StockStateLogic : BusinessLogicBase<StockState, STOCK_STATE>
    {
        public StockStateLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new StockStateTranslator();
        }

        public bool Modify(StockState stockState)
        {
            try
            {
                Expression<Func<STOCK_STATE, bool>> predicate = stokState => stokState.Stock_State_Id == stockState.Id;
                STOCK_STATE stockStateEntity = stockStateEntity = GetEntityBy(predicate);
                stockStateEntity.Stock_State_Name = stockState.Name;
                stockStateEntity.Stock_State_Description = stockState.Description;
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

        public bool Remove(StockState stockState)
        {
            try
            {

                Expression<Func<STOCK_STATE, bool>> selector = stokState => stokState.Stock_State_Id == stockState.Id;
                bool suceeded = base.Remove(selector);
                
                //repository.Save();
                return suceeded;
            }
            catch (Exception)
            {
                throw;
            }
        }





    }
}
