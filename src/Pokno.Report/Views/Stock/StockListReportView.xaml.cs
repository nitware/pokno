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

using Pokno.Report.ViewModels.Stock;

namespace Pokno.Report.Views.Stock
{
    /// <summary>
    /// Interaction logic for StockListView.xaml
    /// </summary>
    public partial class StockListReportView : UserControl
    {
        public StockListReportView(StockListViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }




    }



}
