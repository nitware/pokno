using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Linq.Expressions;
using Pokno.Model.Model;
using Pokno.Entity;
using Pokno.Model.Translator;
using Pokno.Model;
using Pokno.Business.Interfaces;

namespace Pokno.Business
{
    public class StockReviewDetailLogic : BusinessLogicBase<StockReviewDetail, STOCK_REVIEW_DETAIL>
    {
        private Func<IQueryable<STOCK_REVIEW_DETAIL>, IOrderedQueryable<STOCK_REVIEW_DETAIL>> _orderByTransactionMonth = s => s.OrderBy(x => x.Transaction_Month);

        public StockReviewDetailLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new StockReviewDetailTranslator();
        }
               
        public List<StockReviewDetail> GetPreviousYear(int year)
        {
            try
            {
                Expression<Func<STOCK_REVIEW_DETAIL, bool>> filter = srd => srd.Transaction_Year == year;
                return base.GetModelsBy(filter, _orderByTransactionMonth);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StockReviewDetail> GetMonthlyStockSummaryBy(int year, int month)
        {
            try
            {
                Expression<Func<STOCK_REVIEW_DETAIL, bool>> filter = srd => srd.Transaction_Year == year && srd.Transaction_Month == month;
                return base.GetModelsBy(filter, _orderByTransactionMonth);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StockReviewDetail> GetYearlyStockSummaryBy(int year, Stock stock)
        {
            try
            {
                Expression<Func<STOCK_REVIEW_DETAIL, bool>> filter = srd => srd.Transaction_Year == year && srd.Stock_Id == stock.Id;
                return base.GetModelsBy(filter, _orderByTransactionMonth);


                //return base.GetModelsBy(filter).OrderBy(s => s.TransactionMonth).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StockReviewDetail> GetMonthStockReview(CalendarMonth month)
        {
            try
            {
                Expression<Func<STOCK_REVIEW_DETAIL, bool>> filter = srd => srd.Transaction_Month == (int)month;
                return base.GetModelsBy(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public long GetMaximumId()
        {
            try
            {
                Func<STOCK_REVIEW_DETAIL, long> selector = srd => srd.Stock_Review_Detail_Id;
                return base.GetMaxValueBy(selector);



                //StockReviewDetail stockReviewDetail = null;
                //Expression<Func<STOCK_REVIEW_DETAIL, bool>> filter = srd => srd.Stock_Review_Detail_Id > 0;
                //Func<IQueryable<STOCK_REVIEW_DETAIL>, IOrderedQueryable<STOCK_REVIEW_DETAIL>> _orderById = s => s.OrderBy(x => x.Stock_Review_Detail_Id);
                
                //List<StockReviewDetail> stockReviewDetails = base.GetModelsBy(filter);
                //if (stockReviewDetails != null && stockReviewDetails.Count > 0)
                //{
                //    stockReviewDetail = stockReviewDetails.OrderBy(srd => srd.Id).LastOrDefault();
                //}

                //return stockReviewDetail == null ? 0 : stockReviewDetail.Id;



                //StockReviewDetail stockReviewDetail = null;
                //List<StockReviewDetail> stockReviewDetails = base.GetAll();
                //if (stockReviewDetails != null && stockReviewDetails.Count > 0)
                //{
                //    stockReviewDetail = stockReviewDetails.OrderBy(srd => srd.Id).LastOrDefault();
                //}

                //return stockReviewDetail == null ? 0 : stockReviewDetail.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(StockReview stockReview)
        {
            try
            {
                Expression<Func<STOCK_REVIEW_DETAIL, bool>> selector = srd => srd.Transaction_Year >= stockReview.ReviewYear;
                return base.Remove(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }




    }



}
