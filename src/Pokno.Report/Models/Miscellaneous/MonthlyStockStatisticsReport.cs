
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Model.Model;
using Pokno.Model;

namespace Pokno.Report.Models.Miscellaneous
{
    public class MonthlyStockStatisticsReport : BaseStockStatisticsReport
    {
        public MonthlyStockStatisticsReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {

        }

        public Year Year { get; set; }
        public Value Month { get; set; }
       
        public override void GetData()
        {
            try
            {
                Title = Month.Name.ToUpper() + " " + Year.Id.ToString() + ", STOCK STATISTICS";
                ReportName = Month.Name.ToUpper() + ", " + Year.Id.ToString() + ", Stock Statistics";

                _topSellingStocks = _businessFacade.GetMonthlyStockSalesFrequencyBy(true, Year.Id, Month.Id);
                _leastSellingStocks = _businessFacade.GetMonthlyStockSalesFrequencyBy(false, Year.Id, Month.Id);
                _topProfitableStocks = _businessFacade.GetMonthlyTopProfitableStockBy(true, Year.Id, Month.Id);
                _leastProfitableStocks = _businessFacade.GetMonthlyTopProfitableStockBy(false, Year.Id, Month.Id);
                _topReturnedStocks = _businessFacade.GetMonthlyReturnedStockStatisticsBy(true, Year.Id, Month.Id);

                base.UpdateStatistics();

            }
            catch (Exception)
            {
                throw;
            }
        }

        

    }



}
