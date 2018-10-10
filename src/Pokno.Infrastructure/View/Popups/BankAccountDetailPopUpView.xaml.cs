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

using Pokno.Infrastructure.ViewModel.Popups;
using Pokno.Service;

namespace Pokno.Infrastructure.View.Popups
{
    /// <summary>
    /// Interaction logic for BankAccountDetailView.xaml
    /// </summary>
    public partial class BankAccountDetailPopUpView : Window
    {
        private BankAccountDetailPopUpViewModel _viewModel;

        public BankAccountDetailPopUpView()
        {
            
        }
    }

    public partial class BankAccountDetailPopUpView
    {
        public BankAccountDetailPopUpView(IBusinessFacade service)
        {
            InitializeComponent();

            _viewModel = (BankAccountDetailPopUpViewModel)DataContext;
            _viewModel.BusinessFacade = service;
           
            _viewModel.PopulateBankDropDown();
        }
    }





}
