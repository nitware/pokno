using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Pokno.Model;
using Pokno.Entity;
using Pokno.Business.Interfaces;
using System.Data.Entity.Core;

namespace Pokno.Business
{
    public class OutgoingStockReturnRefundLogic : BusinessLogicBase<SoldStockReturnRefund, SOLD_STOCK_RETURN_REFUND>
    {
        private PaymentLogic paymentLogic;

        public OutgoingStockReturnRefundLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new OutgoingStockReturnRefundTranslator();
            paymentLogic = new PaymentLogic(repository);
        }
        
        public bool Modify(SoldStockReturnRefund outgoingStockRefund)
        {
            try
            {
                SOLD_STOCK_RETURN_REFUND stockRefundEntity = GetEntityBy(stockRefund => stockRefund.Stock_On_Shelf_Id == outgoingStockRefund.StockOnShelfId);
                stockRefundEntity.Remarks = outgoingStockRefund.Remarks;
                paymentLogic.Modify(outgoingStockRefund.Payment);
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




    }
}
