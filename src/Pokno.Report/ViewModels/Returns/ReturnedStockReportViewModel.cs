using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Regions;
using Microsoft.Practices.Unity;
using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure.Models;
using Prism.Commands;
using Pokno.Infrastructure;
using Pokno.Report.Views.Returns;

namespace Pokno.Report.ViewModels.Returns
{
    public class ReturnedStockReportViewModel : BaseViewModel
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public ReturnedStockReportViewModel(IRegionManager regionManager, IUnityContainer container)
        {
            _container = container;
            _regionManager = regionManager;
            
            LoggedInUser = Utility.LoggedInUser;
            YearlyStockReturnReportCommand = new DelegateCommand(OnYearlyStockReturnReportCommand, CanViewYearlyStockReturnReport);
            StockReturnByDateRangeReportCommand = new DelegateCommand(OnStockReturnByDateRangeReportCommand, CanViewStockReturnByDateRangeReport);

            _regionManager.Regions.Remove(RegionContainer.ReturnedStockReportRegion);
        }

        public DelegateCommand YearlyStockReturnReportCommand { get; private set; }
        public DelegateCommand StockReturnByDateRangeReportCommand { get; private set; }

        private bool CanViewYearlyStockReturnReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewYearlyStockReturnReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewStockReturnByDateRangeReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewStockReturnByDateRangeReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }

        public void OnYearlyStockReturnReportCommand()
        {
            try
            {
                YearlyStockReturnReportView view = _container.Resolve<YearlyStockReturnReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.ReturnedStockReportRegion);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnStockReturnByDateRangeReportCommand()
        {
            try
            {
                StockReturnByDateRangeReportView view = _container.Resolve<StockReturnByDateRangeReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.ReturnedStockReportRegion);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
       

    }
}
