using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;

namespace Pokno.Report.Models.Miscellaneous
{
    public class StockStatisticsByDateRangeReport : BaseStockStatisticsReport
    {
        public StockStatisticsByDateRangeReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {

        }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
       
        public override void GetData()
        {
            const string dateFormat = "dd/MM/yyyy";

            try
            {
                //Title = "STOCK STATISTICS BETWEEN " + DateFrom.ToString(dateFormat) + " AND " + DateTo.ToString(dateFormat);
                ReportName = "Stock Statistics By Date Range";
                Title = DateFrom.ToString(dateFormat) + " TO " + DateTo.ToString(dateFormat) + " STOCK STATISTICS";

                _topSellingStocks = _businessFacade.GetStockSalesFrequencyByDateRange(true, DateFrom, DateTo);
                _leastSellingStocks = _businessFacade.GetStockSalesFrequencyByDateRange(false, DateFrom, DateTo);
                _topProfitableStocks = _businessFacade.GetTopProfitableStockByDateRange(true, DateFrom, DateTo);
                _leastProfitableStocks = _businessFacade.GetTopProfitableStockByDateRange(false, DateFrom, DateTo);
                _topReturnedStocks = _businessFacade.GetReturnedStockStatisticsByDateRange(true, DateFrom, DateTo);

                base.UpdateStatistics();

            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
