using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Prism.Regions;
using Microsoft.Practices.Unity;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure;
using Prism.Commands;
using Pokno.Report.Views.Expenses;

namespace Pokno.Report.ViewModels.Expenses
{
    public class ExpensesReportViewModel : BaseViewModel
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public ExpensesReportViewModel(IRegionManager regionManager, IUnityContainer container)
        {
            _container = container;
            _regionManager = regionManager;

            LoggedInUser = Utility.LoggedInUser;
            DailyExpensesReportCommand = new DelegateCommand(OnDailyExpensesReportCommand, CanViewDailyExpensesReport);
            MonthlyExpensesReportCommand = new DelegateCommand(OnMonthlyExpensesReportCommand, CanViewMonthlyExpensesReport);
            YearlyExpensesReportCommand = new DelegateCommand(OnYearlyExpensesReportCommand, CanViewYearlyExpensesReport);
            ExpensesByDateRangeReportCommand = new DelegateCommand(OnExpensesByDateRangeReportCommand, CanViewExpensesByDateRangeReport);

            _regionManager.Regions.Remove(RegionContainer.ExpensesReportRegion);
        }
        
        public DelegateCommand DailyExpensesReportCommand { get; private set; }
        public DelegateCommand MonthlyExpensesReportCommand { get; private set; }
        public DelegateCommand YearlyExpensesReportCommand { get; private set; }
        public DelegateCommand ExpensesByDateRangeReportCommand { get; private set; }

        private bool CanViewDailyExpensesReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewDailyExpensesReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
       
        private bool CanViewMonthlyExpensesReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewMonthlyExpensesReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewYearlyExpensesReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewYearlyExpensesReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewExpensesByDateRangeReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewExpensesByDateRangeReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }



        public void OnDailyExpensesReportCommand()
        {
            try
            {
                DailyExpensesReportView view = _container.Resolve<DailyExpensesReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.ExpensesReportRegion);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnMonthlyExpensesReportCommand()
        {
            try
            {
                MonthlyExpensesReportView view = _container.Resolve<MonthlyExpensesReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.ExpensesReportRegion);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnYearlyExpensesReportCommand()
        {
            try
            {
                YearlyExpensesReportView view = _container.Resolve<YearlyExpensesReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.ExpensesReportRegion);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnExpensesByDateRangeReportCommand()
        {
            try
            {
                ExpensesByDateRangeReportView view = _container.Resolve<ExpensesByDateRangeReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.ExpensesReportRegion);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }






    }



}
