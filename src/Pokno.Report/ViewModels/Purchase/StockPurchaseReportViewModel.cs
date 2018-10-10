using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Regions;
using Prism.Commands;
using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure.Models;
using Microsoft.Practices.Unity;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows;
using Pokno.Infrastructure;
using Pokno.Report.Views.Purchase;

namespace Pokno.Report.ViewModels.Purchase
{
    public class StockPurchaseReportViewModel : BaseViewModel
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public StockPurchaseReportViewModel(IRegionManager regionManager, IUnityContainer container)
        {
            _container = container;
            _regionManager = regionManager;
            
            LoggedInUser = Utility.LoggedInUser;
            PurchasedStockReportCommand = new DelegateCommand(OnPurchasedStockReportCommand, CanViewPurchasedStockReport);
            PurchasedStockDetailByStockReportCommand = new DelegateCommand(OnPurchasedStockDetailByStockReportCommand, CanViewPurchasedStockDetailByStockReport);
            PurchasedStockSummaryReportCommand = new DelegateCommand(OnPurchasedStockSummaryReportCommand, CanViewPurchasedStockSummaryReport);

            _regionManager.Regions.Remove(RegionContainer.PurchaseReportRegion);
        }

        public DelegateCommand PurchasedStockReportCommand { get; private set; }
        public DelegateCommand PurchasedStockDetailByStockReportCommand { get; private set; }
        public DelegateCommand PurchasedStockSummaryReportCommand { get; private set; }

        private bool CanViewPurchasedStockReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewStockPurchaseDetailReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewPurchasedStockDetailByStockReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewStockPurchaseDetailByStockReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewPurchasedStockSummaryReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewStockPurchaseSummaryReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }

        public void OnPurchasedStockReportCommand()
        {
            try
            {
                StockPurchasedDetailReportView view = _container.Resolve<StockPurchasedDetailReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.PurchaseReportRegion);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnPurchasedStockDetailByStockReportCommand()
        {
            try
            {
                StockPurchaseDetailByStockReportView view = _container.Resolve<StockPurchaseDetailByStockReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.PurchaseReportRegion);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnPurchasedStockSummaryReportCommand()
        {
            try
            {
                StockPurchaseSummaryReportView view = _container.Resolve<StockPurchaseSummaryReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.PurchaseReportRegion);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }





    }
}
