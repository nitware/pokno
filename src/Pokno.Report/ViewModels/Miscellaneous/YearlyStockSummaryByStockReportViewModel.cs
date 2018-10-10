using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Model;
using System.Collections.ObjectModel;
using Pokno.Infrastructure.Models;
using System.ComponentModel;
using Pokno.Common.Interfaces;
using Pokno.Common.Models;
using Pokno.Report.Models.Miscellaneous;

namespace Pokno.Report.ViewModels.Miscellaneous
{
    public class YearlyStockSummaryByStockReportViewModel : BaseReportByYearViewModel
    {
        private Model.Stock _stock;
        private ObservableCollection<Model.Stock> _stocks;
        private BackgroundWorker _worker;

        public YearlyStockSummaryByStockReportViewModel(IBusinessFacade service, IBaseReportFactory reportFactory)
            : base(service, reportFactory)
        {
            LoadAllProduct();
            UpdateDisplayButtonState();
        }
               
        public ObservableCollection<Model.Stock> Stocks
        {
            get { return _stocks; }
            set
            {
                _stocks = value;
                base.OnPropertyChanged("Stocks");
            }
        }
        public Model.Stock Stock
        {
            get { return _stock; }
            set
            {
                _stock = value;
                base.OnPropertyChanged("Stock");
                UpdateDisplayButtonState();
            }
        }

        private void LoadAllProduct()
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadAllProductCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        e.Result = _service.GetAllStocks();
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnLoadAllProductCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                if (e.Result != null)
                {
                    List<Model.Stock> stocks = e.Result as List<Model.Stock>;
                    PopupateProduct(stocks);
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void PopupateProduct(List<Model.Stock> stocks)
        {
            try
            {
                //List<Stock> stocks = _service.GetAllStocks();
                if (stocks != null)
                {
                    if (stocks.Count > 0)
                    {
                        stocks.Insert(0, new Model.Stock() { Id = 0, Name = "<< Select Stock >>" });
                    }

                    _dispatcher.Invoke(() =>
                    {
                        Stocks = new ObservableCollection<Model.Stock>(stocks);
                        Stock = Stocks.FirstOrDefault();
                    });
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected override void OnDisplayCommand()
        {
            try
            {
                ReportEngine.ReportLoadCompleted += ReportEngine_ReportLoadCompleted;
                base.OnInitialise(ReportType.YearlyStockSummaryByStock);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected override void OnInitialiseHelper(ReportType reportType)
        {
            try
            {
                BaseReport report = _reportFactory.Create(reportType);
                YearlyStockSummaryByStockReport yearlyStockSummaryByStockReport = report as YearlyStockSummaryByStockReport;

                yearlyStockSummaryByStockReport.Year = Year.Id;
                yearlyStockSummaryByStockReport.Stock = Stock;
                ReportEngine reportEngine = new ReportEngine(yearlyStockSummaryByStockReport);
                reportEngine.Generate();

                //ReportHost.Child = reportEngine.Generate();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override sealed void UpdateDisplayButtonState()
        {
            try
            {
                if (Year != null && Year.Id > 0 && Stock != null && Stock.Id > 0)
                {
                    IsEnabled = true;
                }
                else
                {
                    IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }



    }



}
