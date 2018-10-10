﻿using System;
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

using Pokno.Payment.ViewModels;

namespace Pokno.Payment.Views
{
    public partial class BankView : UserControl
    {
        public BankView(BankViewModel viewModel)
        {
            InitializeComponent();

            this.Loaded += (s, e) =>
                {
                    this.DataContext = viewModel;
                };
        }
    }
}