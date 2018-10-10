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

using Pokno.Report.ViewModels.Returns;
using Pokno.Model;
using Pokno.Infrastructure.Models;

namespace Pokno.Report.Views.Returns
{
    /// <summary>
    /// Interaction logic for ReturnedStockView.xaml
    /// </summary>
    public partial class ReturnedStockReportView : UserControl
    {
        public ReturnedStockReportView(ReturnedStockReportViewModel viewModel)
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                DataContext = viewModel;
               
                Person person = Utility.LoggedInUser;
                if (person.Role.PersonRight.CanViewYearlyStockReturnReport)
                {
                    rbYearlyStockReturnReport.IsChecked = true;
                    viewModel.OnYearlyStockReturnReportCommand();
                }
                else if (person.Role.PersonRight.CanViewStockReturnByDateRangeReport)
                {
                    rbStockReturnByDateRangeReport.IsChecked = true;
                    viewModel.OnStockReturnByDateRangeReportCommand();
                }
               

            };
        }


    }



}
