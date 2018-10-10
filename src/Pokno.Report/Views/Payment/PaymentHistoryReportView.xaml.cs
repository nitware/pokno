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

using Pokno.Report.ViewModels.Payment;

namespace Pokno.Report.Views.Payment
{
    /// <summary>
    /// Interaction logic for PaymentHistoryReportView.xaml
    /// </summary>
    public partial class PaymentHistoryReportView : UserControl
    {
        public PaymentHistoryReportView(PaymentHistoryReportViewModel viewModel)
        {
            InitializeComponent();
            Loaded += (s, e) => DataContext = viewModel;
        }
    }



}
