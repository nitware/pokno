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
using Pokno.Infrastructure.Models;

namespace Pokno.Report.Views.Stock
{
    /// <summary>
    /// Interaction logic for StockPriceReportView.xaml
    /// </summary>
    public partial class StockPriceReportView : UserControl
    {
        public StockPriceReportView(StockPriceReportViewModel viewModel)
        {
            InitializeComponent();
                       
            Loaded += (s, e) =>
                {
                    DataContext = viewModel;
                    
                };

            
        }

      



    }
}
