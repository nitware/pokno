using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Model.Model;
using Pokno.Entity;

namespace Pokno.Model.Translator
{
    public class StockPurchasedPoolDetailTranslator : TranslatorBase<StockPurchasedPoolDetail, STOCK_PURCHASED_POOL_DETAIL>
    {
        private StockPurchasedTranslator stockPurchasedTranslator;
        private StockPurchasedPoolTranslator stockPurchasedPoolTranslator;
        
        public StockPurchasedPoolDetailTranslator()
        {
            stockPurchasedPoolTranslator = new StockPurchasedPoolTranslator();
            stockPurchasedTranslator = new StockPurchasedTranslator();
        }

        public override StockPurchasedPoolDetail TranslateToModel(STOCK_PURCHASED_POOL_DETAIL stockPurchasedPoolDetailEntity)
        {
            try
            {
                StockPurchasedPoolDetail stockPurchasedPoolDetail = null;
                if (stockPurchasedPoolDetailEntity != null)
                {
                    stockPurchasedPoolDetail = new StockPurchasedPoolDetail();
                    stockPurchasedPoolDetail.StockPurchasedPool = stockPurchasedPoolTranslator.Translate(stockPurchasedPoolDetailEntity.STOCK_PURCHASED_POOL);
                    stockPurchasedPoolDetail.StockPurchased = stockPurchasedTranslator.Translate(stockPurchasedPoolDetailEntity.STOCK_PURCHASED);
                    stockPurchasedPoolDetail.Remarks = stockPurchasedPoolDetailEntity.Remarks;
                }

                return stockPurchasedPoolDetail;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override STOCK_PURCHASED_POOL_DETAIL TranslateToEntity(StockPurchasedPoolDetail stockPurchasedPoolDetail)
        {
            try
            {
                STOCK_PURCHASED_POOL_DETAIL stockPurchasedPoolDetailEntity = null;
                if (stockPurchasedPoolDetail != null)
                {
                    stockPurchasedPoolDetailEntity = new STOCK_PURCHASED_POOL_DETAIL();
                    stockPurchasedPoolDetailEntity.Stock_Purchased_Pool_Id = stockPurchasedPoolDetail.StockPurchasedPool.Id;
                    stockPurchasedPoolDetailEntity.Stock_Purchased_Id = stockPurchasedPoolDetail.StockPurchased.Id;
                    stockPurchasedPoolDetailEntity.Remarks = stockPurchasedPoolDetail.Remarks;
                }

                return stockPurchasedPoolDetailEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }



    }




}
