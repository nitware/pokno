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

using Pokno.Report.ViewModels;

namespace Pokno.Report.Views
{
    public partial class ReportMenuView : UserControl
    {
        public ReportMenuView(ReportMenuViewModel viewModel)
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                DataContext = viewModel;
            };
        }

       
       



    }


}
