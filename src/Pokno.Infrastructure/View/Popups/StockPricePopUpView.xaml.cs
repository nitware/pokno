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

using Pokno.Infrastructure.ViewModels;

namespace Pokno.Infrastructure.View.Popups
{
    /// <summary>
    /// Interaction logic for StockPricePopUpView.xaml
    /// </summary>
    public partial class StockPricePopUpView : Window
    {
        public StockPricePopUpView()
        {
            
        }
    }

    public partial class StockPricePopUpView
    {
        public StockPricePopUpView(StockPricePopUpViewModel viewModel)
        {
            InitializeComponent();
            Loaded += (s, e) => DataContext = viewModel;

            viewModel.OnSetPopUpCommand(this);
        }



    }


}
