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
using Pokno.Infrastructure.Events;
using Pokno.Infrastructure.Models;
using Prism.Regions;
using Microsoft.Practices.Unity;
using System.Windows.Threading;
using Pokno.Infrastructure;
using Pokno.Infrastructure.ViewModel;
using Pokno.Report.Views.Sales;

namespace Pokno.Report.ViewModels.Sales
{
    public class SalesReportViewModel : BaseViewModel
    {        
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public SalesReportViewModel(IRegionManager regionManager, IUnityContainer container)
        {
            _container = container;
            _regionManager = regionManager;

            LoggedInUser = Utility.LoggedInUser;
            StockSalesAnalysisReportCommand = new DelegateCommand(OnStockSalesAnalysisReportCommand, CanViewStockSalesAnalysisReport);
            StockSalesDetailAnalysisReportCommand = new DelegateCommand(OnStockSalesDetailAnalysisReportCommand, CanViewStockSalesDetailAnalysisReport);
            StockSalesDetailAnalysisByStockReportCommand = new DelegateCommand(OnStockSalesDetailAnalysisByStockReportCommand, CanViewStockSalesDetailAnalysisByStockReport);

            _regionManager.Regions.Remove(RegionContainer.SalesReportRegion);
        }

        public DelegateCommand StockSalesAnalysisReportCommand { get; private set; }
        public DelegateCommand StockSalesDetailAnalysisReportCommand { get; private set; }
        public DelegateCommand StockSalesDetailAnalysisByStockReportCommand { get; private set; }

        private bool CanViewStockSalesAnalysisReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewStockSalesAnalysisReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewStockSalesDetailAnalysisReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewStockSalesDetailsAnalysisReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewStockSalesDetailAnalysisByStockReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewStockSalesDetailAnalysisByStockReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        
        public void OnStockSalesAnalysisReportCommand()
        {
            try
            {
                SoldStockAnalysisReportView view = _container.Resolve<SoldStockAnalysisReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.SalesReportRegion);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnStockSalesDetailAnalysisReportCommand()
        {
            try
            {
                SoldStockDetailAnalysisReportView view = _container.Resolve<SoldStockDetailAnalysisReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.SalesReportRegion);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        public void OnStockSalesDetailAnalysisByStockReportCommand()
        {
            try
            {
                SoldStockDetailAnalysisByStockReportView view = _container.Resolve<SoldStockDetailAnalysisByStockReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.SalesReportRegion);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }


       

    }


}
