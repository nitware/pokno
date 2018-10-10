using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Pokno.Payment.ViewModels;

namespace Pokno.Payment.Views
{
    public partial class UpdatePaymentView : UserControl
    {
        public UpdatePaymentView(UpdatePaymentViewModel viewModel)
        {
            InitializeComponent();
            //DataContext = viewModel;
            this.Loaded += (s, e) =>
            {
                this.DataContext = viewModel;
            };
        }


    }


}
