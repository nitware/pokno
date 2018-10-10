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
    public class CustomerTransactionStatisticsByDateRangeReport : BaseCustomerStatisticsReport
    {
        public CustomerTransactionStatisticsByDateRangeReport(IBusinessFacade businessFacade)
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
                ReportName = "Customer Statistics By Date Range";
                Title = DateFrom.ToString(dateFormat) + " TO " + DateTo.ToString(dateFormat) + " CUSTOMER STATISTICS";

                _topCustomerTransactionsCount = _businessFacade.GetCustomerTransactionFrequencyByDateRange(true, DateFrom, DateTo);
                _leastCustomerTransactionsCount = _businessFacade.GetCustomerTransactionFrequencyByDateRange(false, DateFrom, DateTo);
                _topCustomerTransactionsVolume = _businessFacade.GetCustomerTransactionVolumeByDateRange(true, DateFrom, DateTo);
                _leastCustomerTransactionsVolume = _businessFacade.GetCustomerTransactionVolumeByDateRange(false, DateFrom, DateTo);
                _topProfitableCustomerTransactions = _businessFacade.GetCustomerTransactionProfitByDateRange(true, DateFrom, DateTo);
                _leastProfitableCustomerTransactions = _businessFacade.GetCustomerTransactionProfitByDateRange(false, DateFrom, DateTo);

                base.UpdateStatistics();
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}
