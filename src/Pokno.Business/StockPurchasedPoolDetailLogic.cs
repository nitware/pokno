using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Model.Model;
using Pokno.Entity;
using Pokno.Model;
using Pokno.Model.Translator;
using System.Linq.Expressions;
using Pokno.Business.Interfaces;

namespace Pokno.Business
{
    public class StockPurchasedPoolDetailLogic : BusinessLogicBase<StockPurchasedPoolDetail, STOCK_PURCHASED_POOL_DETAIL>
    {
        public StockPurchasedPoolDetailLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new StockPurchasedPoolDetailTranslator();
        }

        public bool Add(StockPurchasedPool stockPurchasedPool, List<StockPurchased> stockPurchases)
        {
            try
            {
                int addedRecordCount = 0;
                if (stockPurchasedPool != null && stockPurchases != null)
                {
                    List<StockPurchasedPoolDetail> stockPurchasedPoolDetails = Create(stockPurchasedPool, stockPurchases);
                    addedRecordCount = base.Add(stockPurchasedPoolDetails);
                }

                return addedRecordCount > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StockPurchasedPoolDetail> Create(StockPurchasedPool stockPurchasedPool, List<StockPurchased> StockPurchases)
        {
            try
            {
                List<StockPurchasedPoolDetail> StockPurchasedPoolDetails = new List<StockPurchasedPoolDetail>();
                foreach (StockPurchased stockPurchased in StockPurchases)
                {
                    StockPurchasedPoolDetail StockPurchasedPoolDetail = new StockPurchasedPoolDetail();
                    StockPurchasedPoolDetail.StockPurchased = stockPurchased;
                    StockPurchasedPoolDetail.StockPurchasedPool = stockPurchasedPool;

                    StockPurchasedPoolDetails.Add(StockPurchasedPoolDetail);
                }

                return StockPurchasedPoolDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(StockPurchasedPool stockPurchasedPool)
        {
            try
            {
                bool removed = false;

                if (stockPurchasedPool != null)
                {
                    Expression<Func<STOCK_PURCHASED_POOL_DETAIL, bool>> predicate = sppd => sppd.Stock_Purchased_Pool_Id == stockPurchasedPool.Id;
                    removed = base.Remove(predicate);

                    //repository.Save();
                }

                return removed;
            }
            catch (Exception)
            {
                throw;
            }
        }



        


    }


}
