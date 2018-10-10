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
    public partial class DailyExpensesView : UserControl
    {
        public DailyExpensesView(DailyExpensesViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }


    }



}
