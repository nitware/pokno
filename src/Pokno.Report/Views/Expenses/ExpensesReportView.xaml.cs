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

using Pokno.Infrastructure.Models;
using Pokno.Report.ViewModels.Expenses;
using Pokno.Model;

namespace Pokno.Report.Views.Expenses
{
    /// <summary>
    /// Interaction logic for ExpensesReportView.xaml
    /// </summary>
    public partial class ExpensesReportView : UserControl
    {
        public ExpensesReportView(ExpensesReportViewModel viewModel)
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                DataContext = viewModel;

                Person person = Utility.LoggedInUser;
                if (person.Role.PersonRight.CanViewDailyExpensesReport)
                {
                    rbDailyExpensesReport.IsChecked = true;
                    viewModel.OnDailyExpensesReportCommand();
                }
                else if (person.Role.PersonRight.CanViewMonthlyExpensesReport)
                {
                    rbMonthlyExpensesReport.IsChecked = true;
                    viewModel.OnMonthlyExpensesReportCommand();
                }
                else if (person.Role.PersonRight.CanViewYearlyExpensesReport)
                {
                    rbYearlyExpensesReport.IsChecked = true;
                    viewModel.OnYearlyExpensesReportCommand();
                }
                else if (person.Role.PersonRight.CanViewExpensesByDateRangeReport)
                {
                    rbExpensesByDateRangeReport.IsChecked = true;
                    viewModel.OnExpensesByDateRangeReportCommand();
                }
            };




        }

    }
}
