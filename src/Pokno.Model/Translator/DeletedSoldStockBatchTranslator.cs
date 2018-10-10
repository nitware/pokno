using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;

namespace Pokno.Model.Translator
{
    public class DeletedSoldStockBatchTranslator : TranslatorBase<DeletedSoldStockBatch, DELETED_SOLD_STOCK_BATCH>
    {
        private PersonTranslator personTranslator;
        private PaymentTranslator paymentTranslator;

        public DeletedSoldStockBatchTranslator()
        {
            personTranslator = new PersonTranslator();
            paymentTranslator = new PaymentTranslator();
        }

        public override DeletedSoldStockBatch TranslateToModel(DELETED_SOLD_STOCK_BATCH entity)
        {
            try
            {
                DeletedSoldStockBatch model = null;
                if (entity != null)
                {
                    model = new DeletedSoldStockBatch();
                    model.Id = entity.Sold_Stock_Batch_Id;
                    model.Seller = personTranslator.Translate(entity.PERSON1);
                    model.Payment = paymentTranslator.Translate(entity.PAYMENT);
                    model.DateSold = entity.Date_Sold;
                    model.TotalDiscount = entity.Total_Discount;
                    model.Customer = personTranslator.Translate(entity.PERSON);
                    model.DeletedBy = personTranslator.Translate(entity.PERSON2);
                    model.DeletedReason = entity.Deleted_Reason;
                    model.DateDeleted = entity.Date_Deleted;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override DELETED_SOLD_STOCK_BATCH TranslateToEntity(DeletedSoldStockBatch model)
        {
            try
            {
                DELETED_SOLD_STOCK_BATCH entity = null;
                if (model != null)
                {
                    entity = new DELETED_SOLD_STOCK_BATCH();
                    entity.Sold_Stock_Batch_Id = model.Id;
                    entity.Seller_Id = model.Seller.Id;
                    entity.Payment_Id = model.Payment.Id;
                    entity.Date_Sold = model.DateSold;
                    entity.Total_Discount = model.TotalDiscount;
                    entity.Customer_Id = model.Customer.Id;
                    entity.Deleted_By_Person_Id = model.DeletedBy.Id;
                    entity.Deleted_Reason = model.DeletedReason;
                    entity.Date_Deleted = model.DateDeleted;
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
