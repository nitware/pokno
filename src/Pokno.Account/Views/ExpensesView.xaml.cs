using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Pokno.Account.ViewModels;

namespace Pokno.Account.Views
{
    public partial class ExpensesView : UserControl
    {
        public ExpensesView(ExpensesViewModel viewModel)
        {
            InitializeComponent();
            

            this.Loaded += (s, e) =>
            {
                this.DataContext = viewModel;

                if (tcExpensesTab.Items.Count > 0)
                {
                    TabItem dailyExpensisTab = (TabItem)tcExpensesTab.ItemContainerGenerator.ContainerFromIndex(0);
                    dailyExpensisTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSetupDailyExpenses;
                }


            };
        }


    }


}
