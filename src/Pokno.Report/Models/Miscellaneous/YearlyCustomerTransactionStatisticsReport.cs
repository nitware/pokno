using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Model.Model;

namespace Pokno.Report.Models.Miscellaneous
{
    public class YearlyCustomerTransactionStatisticsReport : BaseCustomerStatisticsReport
    {
        public YearlyCustomerTransactionStatisticsReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {

        }

        public Year Year { get; set; }
       
        public override void GetData()
        {
            try
            {
                Title = Year.Id.ToString() + ", CUSTOMER STATISTICS";
                ReportName = Year.Id.ToString() + ", Customer Statistics";

                _topCustomerTransactionsCount = _businessFacade.GetYearlyTopCustomerTransactionFrequency(true, Year.Id);
                _leastCustomerTransactionsCount = _businessFacade.GetYearlyTopCustomerTransactionFrequency(false, Year.Id);
                _topCustomerTransactionsVolume = _businessFacade.GetTopYearlyCustomerTransactionVolumeBy(true, Year.Id);
                _leastCustomerTransactionsVolume = _businessFacade.GetTopYearlyCustomerTransactionVolumeBy(false, Year.Id);
                _topProfitableCustomerTransactions = _businessFacade.GetYearlyCustomerTransactionProfitBy(true, Year.Id);
                _leastProfitableCustomerTransactions = _businessFacade.GetYearlyCustomerTransactionProfitBy(false, Year.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }



    }




}
