using Pokno.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pokno.Model
{
    public class OutgoingStockReturnRefundTranslator : TranslatorBase<SoldStockReturnRefund, SOLD_STOCK_RETURN_REFUND>
    {
        private PaymentTranslator paymentTranslator;

        public OutgoingStockReturnRefundTranslator()
        {
            paymentTranslator = new PaymentTranslator();
        }

        public override SoldStockReturnRefund TranslateToModel(SOLD_STOCK_RETURN_REFUND soldStockRefundEntity)
        {
            try
            {
                SoldStockReturnRefund soldStockRefund = null;
                if (soldStockRefundEntity != null)
                {
                    soldStockRefund = new SoldStockReturnRefund();
                    soldStockRefund.StockOnShelfId = soldStockRefundEntity.Stock_On_Shelf_Id;
                    soldStockRefund.Payment = paymentTranslator.Translate(soldStockRefundEntity.PAYMENT);
                    soldStockRefund.Remarks = soldStockRefundEntity.Remarks;
                }

                return soldStockRefund;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override SOLD_STOCK_RETURN_REFUND TranslateToEntity(SoldStockReturnRefund soldStockRefund)
        {
            try
            {
                SOLD_STOCK_RETURN_REFUND soldStockRefundEntity = null;
                if (soldStockRefund != null)
                {
                    soldStockRefundEntity = new SOLD_STOCK_RETURN_REFUND();
                    soldStockRefundEntity.Stock_On_Shelf_Id = soldStockRefund.StockOnShelfId;
                    soldStockRefundEntity.Payment_Id = soldStockRefund.Payment.Id;
                    soldStockRefundEntity.Remarks = soldStockRefund.Remarks;
                }

                return soldStockRefundEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }




        
    }

}
