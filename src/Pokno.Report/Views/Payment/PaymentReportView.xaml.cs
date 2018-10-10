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

using Pokno.Model;
using Pokno.Report.ViewModels.Payment;
using Pokno.Infrastructure.Models;

namespace Pokno.Report.Views.Payment
{
    public partial class PaymentReportView : UserControl
    {
        public PaymentReportView(PaymentReportViewModel viewModel)
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                DataContext = viewModel;
               
                Person person = Utility.LoggedInUser;
                if (person.Role.PersonRight.CanViewPaymentHistoryReport)
                {
                    rbPaymentHistoryReport.IsChecked = true;
                    viewModel.OnPaymentHistoryReportCommand();
                }
                else if (person.Role.PersonRight.CanViewCompanyCreditorsList)
                {
                    rbCompanyCreditorsListReport.IsChecked = true;
                    viewModel.OnCompanyCreditorsListReportCommand();
                }
                else if (person.Role.PersonRight.CanViewCompanyDebtorsList)
                {
                    rbCompanyDebtorsListReport.IsChecked = true;
                    viewModel.OnCompanyDebtorsListReportCommand();
                }
                else if (person.Role.PersonRight.CanViewSupplierCreditorsList)
                {
                    rbSupplierCreditorsListReport.IsChecked = true;
                    viewModel.OnSupplierCreditorsListReportCommand();
                }
                else if (person.Role.PersonRight.CanViewSupplierDebtorsList)
                {
                    rbSupplierDebtorsListReport.IsChecked = true;
                    viewModel.OnSupplierDebtorsListReportCommand();
                }
                else if (person.Role.PersonRight.CanViewPaymentHistoryByPersonReport)
                {
                    rbPaymentHistoryByPersonReport.IsChecked = true;
                    viewModel.OnPaymentHistoryByPersonReportCommand();
                }


            };
        }


    }



}
