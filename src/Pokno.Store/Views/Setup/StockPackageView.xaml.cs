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

using Pokno.Store.ViewModels;

namespace Pokno.Store.Views
{
    public partial class StockPackageView : UserControl
    {
        public StockPackageView(StockPackageViewModel viewModel)
        {
            InitializeComponent();
            Loaded += (s, e) => DataContext = viewModel;

            //DataContext = viewModel;
        }



    }
}
