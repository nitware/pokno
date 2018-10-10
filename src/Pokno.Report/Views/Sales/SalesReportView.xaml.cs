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

using Pokno.Report.ViewModels.Sales;
using Pokno.Infrastructure.Models;

namespace Pokno.Report.Views.Sales
{
    public partial class SalesReportView : UserControl
    {
        public SalesReportView(SalesReportViewModel viewModel)
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                DataContext = viewModel;

                Pokno.Model.Person person = Utility.LoggedInUser;
                if (person.Role.PersonRight.CanViewStockSalesAnalysisReport)
                {
                    rbStockSalesAnalysisReport.IsChecked = true;
                    viewModel.OnStockSalesAnalysisReportCommand();
                }
                else if (person.Role.PersonRight.CanViewStockSalesDetailsAnalysisReport)
                {
                    rbStockSalesDetailAnalysisReport.IsChecked = true;
                     viewModel.OnStockSalesDetailAnalysisReportCommand();
                }
                else if (person.Role.PersonRight.CanViewStockSalesDetailAnalysisByStockReport)
                {
                    rbStockSalesDetailAnalysisByStockReport.IsChecked = true;
                    viewModel.OnStockSalesDetailAnalysisByStockReportCommand();
                }
               
                

            };
        }


    }




}
