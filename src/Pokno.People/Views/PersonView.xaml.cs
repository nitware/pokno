﻿using Pokno.People.ViewModel;
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

namespace Pokno.People.Views
{
    public partial class PersonView : UserControl
    {
        public PersonView(PersonViewModel viewModel)
        {
            InitializeComponent();

            this.Loaded += (s, e) =>
            {
                this.DataContext = viewModel;
            };
        }
    }


}
