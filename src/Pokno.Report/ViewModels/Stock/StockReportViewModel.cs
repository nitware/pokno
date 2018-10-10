using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Prism.Events;
using Prism.Commands;
using Pokno.Infrastructure.Models;
using Microsoft.Practices.Unity;
using System.Windows.Threading;
using Prism.Regions;
using Pokno.Infrastructure;
using Pokno.Infrastructure.Events;
using Pokno.Infrastructure.ViewModel;
using Pokno.Report.Views.Stock;

namespace Pokno.Report.ViewModels.Stock
{
    public class StockReportViewModel : BaseViewModel
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public StockReportViewModel(IRegionManager regionManager, IUnityContainer container)
        {
            _container = container;
            _regionManager = regionManager;

            LoggedInUser = Utility.LoggedInUser;
            StockListByTypeReportCommand = new DelegateCommand(OnStockListByTypeReportCommand, CanViewStockListByTypeReport);
            StockPackagesReportCommand = new DelegateCommand(OnStockPackagesReportCommand, CanViewStockPackagesReport);
            PackageQuantityReportCommand = new DelegateCommand(OnPackageQuantityReportCommand, CanViewPackageQuantityReport);
            StockPriceReportCommand = new DelegateCommand(OnStockPriceReportCommand, CanViewStockPriceReport);
            StockPriceHistoryReportCommand = new DelegateCommand(OnStockPriceHistoryReportCommand, CanViewStockPriceHistoryReport);
            StockOnShelfReportCommand = new DelegateCommand(OnStockOnShelfReportCommand, CanViewStockOnShelfReport);
            StockListReportCommand = new DelegateCommand(OnStockListReportCommand, CanViewStockListReport);
            StockPriceHistoryByStockReportCommand = new DelegateCommand(OnStockPriceHistoryByStockReportCommand, CanViewStockPriceHistoryByStockReport);
            StocksInStoreReportCommand = new DelegateCommand(OnStocksInStoreReportCommand, CanViewStocksInStoreReport);

            _regionManager.Regions.Remove(RegionContainer.StockReportRegion);
        }

        public DelegateCommand StockListByTypeReportCommand { get; private set; }
        public DelegateCommand StockAtHandReportCommand { get; private set; }
        public DelegateCommand SoldStocksCommand { get; private set; }
        public DelegateCommand StockPackagesReportCommand { get; private set; }
        public DelegateCommand PackageQuantityReportCommand { get; private set; }
        public DelegateCommand StockPriceReportCommand { get; private set; }
        public DelegateCommand StockPriceHistoryReportCommand { get; private set; }
        public DelegateCommand StockOnShelfReportCommand { get; private set; }
        public DelegateCommand StockListReportCommand { get; private set; }
        public DelegateCommand StockPriceHistoryByStockReportCommand { get; private set; }
        public DelegateCommand StocksInStoreReportCommand { get; private set; }

        private bool CanViewStockListByTypeReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewStockListByTypeReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewStockPackagesReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewStockPackageReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewPackageQuantityReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewPackageRelationshipReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewStockPriceReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewStockPriceReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewStockPriceHistoryReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewStockPriceHistoryReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
       
        private bool CanViewStockOnShelfReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewStockAvailableOnShelfReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewStockListReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewStockListReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewStockPriceHistoryByStockReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewStockPriceHistoryByStockReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
       
        private bool CanViewStocksInStoreReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewStockInStoreReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }

        public void OnStockListByTypeReportCommand()
        {
            try
            {
                StockListByTypeReportView view = _container.Resolve<StockListByTypeReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.StockReportRegion);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnStockListReportCommand()
        {
            try
            {
                StockListReportView view = _container.Resolve<StockListReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.StockReportRegion);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnStockPackagesReportCommand()
        {
            try
            {
                StockPackageReportView view = _container.Resolve<StockPackageReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.StockReportRegion);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnPackageQuantityReportCommand()
        {
            try
            {
                PackageRelationshipReportView view = _container.Resolve<PackageRelationshipReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.StockReportRegion);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnStockOnShelfReportCommand()
        {
            try
            {
                RemainingStockOnShelfReportView view = _container.Resolve<RemainingStockOnShelfReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.StockReportRegion);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnStockPriceReportCommand()
        {
            try
            {
                StockPriceReportView view = _container.Resolve<StockPriceReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.StockReportRegion);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnStockPriceHistoryReportCommand()
        {
            try
            {
                StockPriceHistoryReportView view = _container.Resolve<StockPriceHistoryReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.StockReportRegion);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnStockPriceHistoryByStockReportCommand()
        {
            try
            {
                StockPriceHistoryByStockReportView view = _container.Resolve<StockPriceHistoryByStockReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.StockReportRegion);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnStocksInStoreReportCommand()
        {
            try
            {
                StocksInStoreReportView view = _container.Resolve<StocksInStoreReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.StockReportRegion);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        
        






    }

}
