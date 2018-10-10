
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Model.Model;

namespace Pokno.Report.Models.Miscellaneous
{
    public class YearlyStockStatisticsReport : BaseStockStatisticsReport
    {
        public YearlyStockStatisticsReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {

        }

        public Year Year { get; set; }
       
        public override void GetData()
        {
            try
            {
                Title = Year.Id.ToString() + ", STOCK STATISTICS";
                ReportName = Year.Id.ToString() + ", Stock Statistics";

                _topSellingStocks = _businessFacade.GetStockSalesFrequencyBy(true, Year.Id);
                _leastSellingStocks = _businessFacade.GetStockSalesFrequencyBy(false, Year.Id);
                _topProfitableStocks = _businessFacade.GetTopProfitableStockBy(true, Year.Id);
                _leastProfitableStocks = _businessFacade.GetTopProfitableStockBy(false, Year.Id);
                _topReturnedStocks = _businessFacade.GetYearlyReturnedStockStatisticsBy(true, Year.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }




    }



}
