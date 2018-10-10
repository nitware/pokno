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

using Pokno.Report.ViewModels.Purchase;
using Pokno.Infrastructure.Models;
using Pokno.Model;

namespace Pokno.Report.Views.Purchase
{
    /// <summary>
    /// Interaction logic for StockPurchaseView.xaml
    /// </summary>
    public partial class StockPurchaseReportView : UserControl
    {
        public StockPurchaseReportView(StockPurchaseReportViewModel viewModel)
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                DataContext = viewModel;
                Person person = Utility.LoggedInUser;

                if (person.Role.PersonRight.CanViewStockPurchaseDetailReport)
                {
                    rbPurchasedStockReport.IsChecked = true;
                    viewModel.OnPurchasedStockReportCommand();
                }
                else if (person.Role.PersonRight.CanViewStockPurchaseDetailByStockReport)
                {
                    rbPurchasedStockDetailByStockReport.IsChecked = true;
                    viewModel.OnPurchasedStockDetailByStockReportCommand();
                }
                else if (person.Role.PersonRight.CanViewStockPurchaseSummaryReport)
                {
                    rbPurchasedStockSummaryReport.IsChecked = true;
                    viewModel.OnPurchasedStockSummaryReportCommand();
                }


            };



        }
    }
}
