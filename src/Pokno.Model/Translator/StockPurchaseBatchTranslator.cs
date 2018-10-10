using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Entity;

namespace Pokno.Model
{
    public class StockPurchaseBatchTranslator : TranslatorBase<StockPurchaseBatch, STOCK_PURCHASE_BATCH>
    {
       private PersonTranslator personTranslator;
       private PaymentTranslator paymentTranslator;

       public StockPurchaseBatchTranslator()
       {
           personTranslator = new PersonTranslator();
           paymentTranslator = new PaymentTranslator();
       }

       public override StockPurchaseBatch TranslateToModel(STOCK_PURCHASE_BATCH stockPurchaseBatchEntity)
       {
           try
           {
               StockPurchaseBatch stockPurchaseBatch = null;

               if (stockPurchaseBatchEntity != null)
               {
                   stockPurchaseBatch = new StockPurchaseBatch();
                   stockPurchaseBatch.Id = stockPurchaseBatchEntity.Stock_Purchase_Batch_Id;
                   stockPurchaseBatch.DatePurchased = stockPurchaseBatchEntity.Date_Puchased;
                   stockPurchaseBatch.Buyer = personTranslator.Translate(stockPurchaseBatchEntity.PERSON);
                   stockPurchaseBatch.Supplier = personTranslator.Translate(stockPurchaseBatchEntity.PERSON1);
                   stockPurchaseBatch.Payment = paymentTranslator.Translate(stockPurchaseBatchEntity.PAYMENT);
                   stockPurchaseBatch.SupplierExpenses = stockPurchaseBatchEntity.Supplier_Expenses;
                   stockPurchaseBatch.InvoiceNumber = stockPurchaseBatchEntity.Invoice_Number;
               }

               return stockPurchaseBatch;
           }
           catch (Exception)
           {
               throw;
           }
       }

       public override STOCK_PURCHASE_BATCH TranslateToEntity(StockPurchaseBatch stockPurchaseBatch)
       {
           try
           {
               STOCK_PURCHASE_BATCH stockPurchaseBatchEntity = null;
               if (stockPurchaseBatch != null)
               {
                   stockPurchaseBatchEntity = new STOCK_PURCHASE_BATCH();
                   stockPurchaseBatchEntity.Stock_Purchase_Batch_Type_Id = 1;
                   stockPurchaseBatchEntity.Supplier_Id = stockPurchaseBatch.Supplier.Id;
                   stockPurchaseBatchEntity.Buyer_Id = stockPurchaseBatch.Buyer.Id;
                   stockPurchaseBatchEntity.Payment_Id = stockPurchaseBatch.Payment.Id;
                   stockPurchaseBatchEntity.Date_Puchased = stockPurchaseBatch.DatePurchased;
                   stockPurchaseBatchEntity.Supplier_Expenses = stockPurchaseBatch.SupplierExpenses;
                   stockPurchaseBatchEntity.Invoice_Number = stockPurchaseBatch.InvoiceNumber;
               }

               return stockPurchaseBatchEntity;
           }
           catch (Exception)
           {
               throw;
           }
       }



    }
}
