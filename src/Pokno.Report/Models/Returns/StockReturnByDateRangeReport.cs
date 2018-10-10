using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;

namespace Pokno.Report.Models.Returns
{
    public class StockReturnByDateRangeReport : BaseStockReturnReport
    {
        public StockReturnByDateRangeReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {

        }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
       
        public override void GetData()
        {
            try
            {
                const string dateFormat = "dd/MM/yyyy";
                ReportName = "Returned Stock By Date Range";
                Title = DateFrom.ToString(dateFormat) + " TO " + DateTo.ToString(dateFormat) + " RETURNED STOCKS";
                
                _returnedStocks = _businessFacade.GetReturnedStockByDateRange(DateFrom, DateTo);
                if (_returnedStocks == null || _returnedStocks.Count <= 0)
                {
                    throw new Exception("No Returned Stock found for the selected date range!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}
