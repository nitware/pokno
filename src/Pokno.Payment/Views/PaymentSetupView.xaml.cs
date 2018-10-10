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

using Pokno.Payment.ViewModels;

namespace Pokno.Payment.Views
{
    /// <summary>
    /// Interaction logic for PaymentSetupView.xaml
    /// </summary>
    public partial class PaymentSetupView : UserControl
    {
        public PaymentSetupView(PaymentSetupViewModel viewModel)
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                DataContext = viewModel;

                int count = tcPaymentSetupTab.Items.Count;
                if (count > 0)
                {
                    TabItem paymentTypeTab = (TabItem)tcPaymentSetupTab.ItemContainerGenerator.ContainerFromIndex(0);
                    paymentTypeTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSetupPaymentType;

                    TabItem bankTab = (TabItem)tcPaymentSetupTab.ItemContainerGenerator.ContainerFromIndex(1);
                    bankTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSetupBank;

                    if (paymentTypeTab.IsEnabled)
                    {
                        paymentTypeTab.IsSelected = true;
                    }
                    else if (bankTab.IsEnabled)
                    {
                        bankTab.IsSelected = true;
                    }

                }
            };


        }
    }



}
