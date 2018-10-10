using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Model.Model;

namespace Pokno.Report.Models.Returns
{
    public class YearlyStockReturnReport : BaseStockReturnReport
    {
        public YearlyStockReturnReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {

        }

        public Year Year { get; set; }
       
        public override void GetData()
        {
            try
            {
                Title = Year.Id.ToString() + ", RETURNED STOCK(S)";
                ReportName = Year.Id.ToString() + ", Returned Stocks";

                _returnedStocks = _businessFacade.GetReturnedStockByYear(Year.Id);
                if (_returnedStocks == null || _returnedStocks.Count <= 0)
                {
                    throw new Exception("No Returned Stock found for the selected year!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }




    }



}
