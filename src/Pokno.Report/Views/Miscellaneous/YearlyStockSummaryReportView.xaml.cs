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

namespace Pokno.Report.Views.Miscellaneous
{
    /// <summary>
    /// Interaction logic for YearlyStockBreakDownReportView.xaml
    /// </summary>
    public partial class YearlyStockSummaryReportView : UserControl
    {
        public YearlyStockSummaryReportView(YearlyStockSummaryReportViewModel viewModel)
        {
            InitializeComponent();

            Loaded += (s, e) =>
                {
                    DataContext = viewModel;
                };

        }



    }
}
