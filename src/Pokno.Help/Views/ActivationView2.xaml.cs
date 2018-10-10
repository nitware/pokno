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

using Pokno.Help.ViewModels;
using Pokno.Service;

namespace Pokno.Help.Views
{
    /// <summary>
    /// Interaction logic for ActivationView.xaml
    /// </summary>
    public partial class ActivationView2 : Window
    {
        private ActivationViewModel2 _viewModel;

        public ActivationView2()
        {
            
        }
    }

    public partial class ActivationView2
    {
        public ActivationView2(IBusinessFacade service)
        {
            InitializeComponent();

            _viewModel = (ActivationViewModel2)DataContext;
            //_viewModel.BusinessFacade = service;


        }
    }




}
