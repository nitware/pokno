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

using Pokno.Model.Model;
using Pokno.Report.ViewModels;
using Pokno.Infrastructure.Models;

namespace Pokno.Report.Views
{
    public partial class ReportHomeView : UserControl
    {
        public ReportHomeView(ReportHomeViewModel viewModel)
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                DataContext = viewModel;

                Setting setting = Utility.Setting;
                if (setting != null && setting.Id > 0)
                {
                    viewModel.SetApplicationModeImages(setting.ApplicationMode);
                }
            };
        }






    }
}
