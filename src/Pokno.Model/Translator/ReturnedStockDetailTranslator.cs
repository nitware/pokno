using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;

namespace Pokno.Model.Translator
{
    public class ReturnedStockDetailTranslator : TranslatorBase<ReturnedStockDetail, RETURNED_STOCK_DETAIL>
    {
        private StockStateTranslator _stockStateTranslator;
        private SoldStockTranslator _soldStockTranslator;
        private StockReturnActionTranslator _stockReturnActionTranslator;
        private ReturnedStockTranslator _returnedStockTranslator;
        private PaymentTranslator _paymentTranslator;

        public ReturnedStockDetailTranslator()
        {
            _stockStateTranslator = new StockStateTranslator();
            _soldStockTranslator = new SoldStockTranslator();
            _stockReturnActionTranslator = new StockReturnActionTranslator();
            _returnedStockTranslator = new ReturnedStockTranslator();
            _paymentTranslator = new PaymentTranslator();
        }

        public override ReturnedStockDetail TranslateToModel(RETURNED_STOCK_DETAIL entity)
        {
            try
            {
                ReturnedStockDetail model = null;
                if (entity != null)
                {
                    model = new ReturnedStockDetail();
                    model.Id = entity.Returned_Stock_Detail_Id;
                    model.SoldStock = _soldStockTranslator.Translate(entity.SOLD_STOCK);
                    model.ReturnedStock = _returnedStockTranslator.Translate(entity.RETURNED_STOCK);
                    model.ReturnQuantity = (int)entity.Returned_Quantity;
                    model.StockState = _stockStateTranslator.Translate(entity.STOCK_STATE);
                    model.Action = _stockReturnActionTranslator.Translate(entity.STOCK_RETURN_ACTION);
                    model.Refunded = entity.Refunded;
                    model.Payment = _paymentTranslator.Translate(entity.PAYMENT);
                    model.ReturnedToShelf = entity.Returned_To_Shelf;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override RETURNED_STOCK_DETAIL TranslateToEntity(ReturnedStockDetail model)
        {
            try
            {
                RETURNED_STOCK_DETAIL entity = null;
                if (model != null)
                {
                    entity = new RETURNED_STOCK_DETAIL();
                    entity.Returned_Stock_Detail_Id = model.Id;
                    entity.Sold_Stock_Id = model.SoldStock.Id;
                    entity.Returned_Stock_Id = model.ReturnedStock.Id;
                    entity.Returned_Quantity = model.ReturnQuantity;
                    entity.Stock_State_Id = model.StockState.Id;
                    entity.Stock_Return_Action_Id = model.Action.Id;
                    entity.Refunded = model.Refunded;
                    entity.Returned_To_Shelf = model.ReturnedToShelf;

                    if (model.Payment != null && model.Payment.Id > 0)
                    {
                        entity.Payment_Id = model.Payment.Id;
                    }
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
