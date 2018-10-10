using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure.Models;
using System.Windows;
using Prism.Regions;
using Microsoft.Practices.Unity;
using System.Windows.Controls;
using System.Windows.Threading;
using Pokno.Infrastructure;
using Prism.Commands;
using Pokno.Report.Views.Miscellaneous;

namespace Pokno.Report.ViewModels.Miscellaneous
{
    public class MiscellaneousReportViewModel : BaseViewModel
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public MiscellaneousReportViewModel(IRegionManager regionManager, IUnityContainer container)
        {
            _container = container;
            _regionManager = regionManager;

            LoggedInUser = Utility.LoggedInUser;
            DailyTransactionReportCommand = new DelegateCommand(OnDailyTransactionReportCommand, CanDailyTransactionReport);
            YearlyStockSummaryReportCommand = new DelegateCommand(OnYearlyStockSummaryReportCommand, CanViewYearlyStockSummaryReport);
            MonthlyStockBreakDownReportCommand = new DelegateCommand(OnMonthlyStockBreakDownReportCommand, CanViewMonthlyStockBreakDownReport);
            YearlySummaryByStockReportCommand = new DelegateCommand(OnYearlySummaryByStockReportCommand, CanViewYearlySummaryByStockReport);
            YearlyCustomerTransactionStatisticsReportCommand = new DelegateCommand(OnYearlyCustomerTransactionStatisticsReportCommand, CanViewYearlyCustomerTransactionStatisticsReport);
            CustomerTransactionStatisticsByDateRangeReportCommand = new DelegateCommand(OnCustomerTransactionStatisticsByDateRangeReportCommand, CanViewCustomerTransactionStatisticsByDateRangeReport);
            YearlyStockStatisticsReportCommand = new DelegateCommand(OnYearlyStockStatisticsReportCommand, CanViewYearlyStockStatisticsReport);
            MontlyStockStatisticsReportCommand = new DelegateCommand(OnMontlyStockStatisticsReportCommand, CanViewMontlyStockStatisticsReport);
            StockStatisticsByDateRangeReportCommand = new DelegateCommand(OnStockStatisticsByDateRangeReportCommand, CanViewStockStatisticsByDateRangeReport);
            
            _regionManager.Regions.Remove(RegionContainer.MiscReportRegion);
        }
                       
        public DelegateCommand DailyTransactionReportCommand { get; private set; }
        public DelegateCommand YearlyStockSummaryReportCommand { get; private set; }
        public DelegateCommand MonthlyStockBreakDownReportCommand { get; private set; }
        public DelegateCommand YearlySummaryByStockReportCommand { get; private set; }
        public DelegateCommand YearlyCustomerTransactionStatisticsReportCommand { get; private set; }
        public DelegateCommand CustomerTransactionStatisticsByDateRangeReportCommand { get; private set; }
        public DelegateCommand YearlyStockStatisticsReportCommand { get; private set; }
        public DelegateCommand MontlyStockStatisticsReportCommand { get; private set; }
        public DelegateCommand StockStatisticsByDateRangeReportCommand { get; private set; }
        
        private bool CanDailyTransactionReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewDailyTransactionReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewYearlyStockSummaryReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewStockYearlySummaryReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewMonthlyStockBreakDownReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewStockMonthlySummaryReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewYearlySummaryByStockReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewStockYearlySummaryByStockReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewYearlyCustomerTransactionStatisticsReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewYearlyCustomerTransactionStatisticsReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewCustomerTransactionStatisticsByDateRangeReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewCustomerTransactionStatisticsByDateRangeReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewMontlyStockStatisticsReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewMonthlyStockStatisticsReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewStockStatisticsByDateRangeReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewStockStatisticsByDateRangeReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewYearlyStockStatisticsReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewYearlyStockStatisticsReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }

        
        public void OnDailyTransactionReportCommand()
        {
            try
            {
                DailyTransactionReportView view = _container.Resolve<DailyTransactionReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.MiscReportRegion);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnYearlyStockSummaryReportCommand()
        {
            try
            {
                YearlyStockSummaryReportView view = _container.Resolve<YearlyStockSummaryReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.MiscReportRegion);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnMonthlyStockBreakDownReportCommand()
        {
            try
            {
                MonthlyStockSummaryReportView view = _container.Resolve<MonthlyStockSummaryReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.MiscReportRegion);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnYearlySummaryByStockReportCommand()
        {
            try
            {
                YearlyStockSummaryByStockReportView view = _container.Resolve<YearlyStockSummaryByStockReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.MiscReportRegion);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        public void OnYearlyCustomerTransactionStatisticsReportCommand()
        {
            try
            {
                YearlyCustomerTransactionStatisticsReportView view = _container.Resolve<YearlyCustomerTransactionStatisticsReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.MiscReportRegion);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnCustomerTransactionStatisticsByDateRangeReportCommand()
        {
            try
            {
                CustomerTransactionStatisticsByDateRangeReportView view = _container.Resolve<CustomerTransactionStatisticsByDateRangeReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.MiscReportRegion);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        public void OnMontlyStockStatisticsReportCommand()
        {
            try
            {
                MonthlyStockStatisticsReportView view = _container.Resolve<MonthlyStockStatisticsReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.MiscReportRegion);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        public void OnYearlyStockStatisticsReportCommand()
        {
            try
            {
                YearlyStockStatisticsReportView view = _container.Resolve<YearlyStockStatisticsReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.MiscReportRegion);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnStockStatisticsByDateRangeReportCommand()
        {
            try
            {
                StockStatisticsByDateRangeReportView view = _container.Resolve<StockStatisticsByDateRangeReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.MiscReportRegion);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }







    }



}
