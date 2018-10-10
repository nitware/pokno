using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Entity;

namespace Pokno.Model
{
    public class SoldStockBatchTranslator : TranslatorBase<SoldStockBatch, SOLD_STOCK_BATCH>
    {
        private PaymentTranslator paymentTranslator;
        private PersonTranslator personTranslator;

        public SoldStockBatchTranslator()
        {
            paymentTranslator = new PaymentTranslator();
            personTranslator = new PersonTranslator();
        }

        public override SoldStockBatch TranslateToModel(SOLD_STOCK_BATCH soldStockBatchEntity)
        {
            try
            {
                SoldStockBatch soldBatch = null;
                if (soldStockBatchEntity != null)
                {
                    soldBatch = new SoldStockBatch();
                    soldBatch.Id = soldStockBatchEntity.Sold_Stock_Batch_Id;
                    soldBatch.Seller = personTranslator.Translate(soldStockBatchEntity.PERSON1);
                    soldBatch.Payment = paymentTranslator.Translate(soldStockBatchEntity.PAYMENT);
                    soldBatch.DateSold = soldStockBatchEntity.Date_Sold;
                    soldBatch.TotalDiscount = soldStockBatchEntity.Total_Discount;
                    soldBatch.Customer = personTranslator.Translate(soldStockBatchEntity.PERSON);

                }
                return soldBatch;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override SOLD_STOCK_BATCH TranslateToEntity(SoldStockBatch soldBatch)
        {
            try
            {
                SOLD_STOCK_BATCH soldBatchEntity = null;
                if (soldBatch != null)
                {
                    soldBatchEntity = new SOLD_STOCK_BATCH();
                    soldBatchEntity.Date_Sold = soldBatch.DateSold;
                    soldBatchEntity.Total_Discount = soldBatch.TotalDiscount;
                    soldBatchEntity.Seller_Id = soldBatch.Seller.Id;
                    soldBatchEntity.Payment_Id = soldBatch.Payment.Id;

                    if (soldBatch.Customer != null && soldBatch.Customer.Id > 0)
                    {
                        soldBatchEntity.Customer_Id = soldBatch.Customer.Id;
                    }
                }
                return soldBatchEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
    
}
