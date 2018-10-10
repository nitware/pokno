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

using Pokno.Store.ViewModels;

namespace Pokno.Store.Views
{
    /// <summary>
    /// Interaction logic for StockPriceCheck.xaml
    /// </summary>
    public partial class StockPriceCheckView : UserControl
    {
        public StockPriceCheckView(StockPriceCheckViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }




}
