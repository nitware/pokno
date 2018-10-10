using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Pokno.Report.ViewModels.Miscellaneous;
using Pokno.Infrastructure.Models;
using Pokno.Model;

namespace Pokno.Report.Views.Miscellaneous
{
    /// <summary>
    /// Interaction logic for MiscellaneousReportView.xaml
    /// </summary>
    public partial class MiscellaneousReportView : UserControl
    {
        public MiscellaneousReportView(MiscellaneousReportViewModel viewModel)
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                DataContext = viewModel;

                Person person = Utility.LoggedInUser;
                if (person.Role.PersonRight.CanViewDailyTransactionReport)
                {
                    rbDailyTransactionReport.IsChecked = true;
                    viewModel.OnDailyTransactionReportCommand();
                }
                else if (person.Role.PersonRight.CanViewStockYearlySummaryReport)
                {
                    rbYearlyStockSummaryReport.IsChecked = true;
                    viewModel.OnYearlyStockSummaryReportCommand();
                }
                else if (person.Role.PersonRight.CanViewStockYearlySummaryByStockReport)
                {
                    rbYearlySummaryByStockReport.IsChecked = true;
                    viewModel.OnYearlySummaryByStockReportCommand();
                }
                else if (person.Role.PersonRight.CanViewStockMonthlySummaryReport)
                {
                    rbMonthlyStockBreakDownReport.IsChecked = true;
                    viewModel.OnMonthlyStockBreakDownReportCommand();
                }
                else if (person.Role.PersonRight.CanViewYearlyStockStatisticsReport)
                {
                    rbYearlyStockStatisticsReport.IsChecked = true;
                    viewModel.OnYearlyStockStatisticsReportCommand();
                }
                else if (person.Role.PersonRight.CanViewMonthlyStockStatisticsReport)
                {
                    rbMontlyStockStatisticsReport.IsChecked = true;
                    viewModel.OnMontlyStockStatisticsReportCommand();
                }
                else if (person.Role.PersonRight.CanViewStockStatisticsByDateRangeReport)
                {
                    rbStockStatisticsByDateRangeReport.IsChecked = true;
                    viewModel.OnStockStatisticsByDateRangeReportCommand();
                }
                else if (person.Role.PersonRight.CanViewYearlyCustomerTransactionStatisticsReport)
                {
                    rbYearlyCustomerTransactionStatisticsReport.IsChecked = true;
                    viewModel.OnYearlyCustomerTransactionStatisticsReportCommand();
                }
                else if (person.Role.PersonRight.CanViewCustomerTransactionStatisticsByDateRangeReport)
                {
                    rbCustomerTransactionStatisticsByDateRangeReport.IsChecked = true;
                    viewModel.OnCustomerTransactionStatisticsByDateRangeReportCommand();
                }


            };
        }
    }
}
