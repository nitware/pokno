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

    public class StockReturnTypeLogic : BusinessLogicBase<StockReturnType, STOCK_RETURN_TYPE>
    {
        public StockReturnTypeLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new StockReturnTypeTranslator();
        }

        public bool Modify(StockReturnType stockReturnType)
        {
            try
            {
                Expression<Func<STOCK_RETURN_TYPE, bool>> predicate = ReturnType => ReturnType.Stock_Return_Type_Id == stockReturnType.Id;
                STOCK_RETURN_TYPE stockReturnTypeEntity = GetEntityBy(predicate);
                stockReturnTypeEntity.Stock_Return_Type_Name = stockReturnType.Name;
                int rowAffected = repository.Save();
               
                if (rowAffected > 0)
                {
                    return true;
                }
                else
                {
                    throw new Exception(NoItemModified);
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

        public bool Remove(StockReturnType stockReturnType)
        {
            try
            {
                Expression<Func<STOCK_RETURN_TYPE, bool>> selector = ReturnType => ReturnType.Stock_Return_Type_Id == stockReturnType.Id;
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
