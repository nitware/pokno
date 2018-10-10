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

namespace Pokno.Store.Views.Setup
{
    /// <summary>
    /// Interaction logic for ExpensesCategoryView.xaml
    /// </summary>
    public partial class ExpensesCategoryView : UserControl
    {
        public ExpensesCategoryView(ExpensesCategoryViewModel viewModel)
        {
            InitializeComponent();
            Loaded += (s, e) => DataContext = viewModel;
        }
    }



}
