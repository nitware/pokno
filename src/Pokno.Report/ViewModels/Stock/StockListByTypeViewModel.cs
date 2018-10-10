using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Common.Interfaces;
using Pokno.Model;
using Pokno.Infrastructure.Models;
using Pokno.Common.Models;
using Pokno.Report.Models.Stock;
using Prism.Commands;
using System.ComponentModel;
using Pokno.Service;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.Windows;

namespace Pokno.Report.ViewModels.Stock
{
    public class StockListByTypeViewModel : BaseReportViewModel
    {
        private Dispatcher _dispatcher;

        private bool _isEnabled;
        private StockType _stockType;
        private BackgroundWorker _worker;
        private ObservableCollection<StockType> _stockTypes;
        private readonly IBusinessFacade _businessFacade;

        public StockListByTypeViewModel(IBusinessFacade businessFacade, IBaseReportFactory reportFactory)
            : base(reportFactory)
        {
            _businessFacade = businessFacade;
            _dispatcher = Application.Current.Dispatcher;

            DisplayCommand = new DelegateCommand(OnDisplayCommand, CanDisplay);

            LoadAllStockType();
        }

        public DelegateCommand DisplayCommand { get; private set; }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                base.OnPropertyChanged("IsEnabled");
                DisplayCommand.RaiseCanExecuteChanged();
            }
        }
        public ObservableCollection<StockType> StockTypes
        {
            get { return _stockTypes; }
            set
            {
               _stockTypes = value;
                base.OnPropertyChanged("StockTypes");
            }
        }
        public StockType StockType
        {
            get { return _stockType; }
            set
            {
                _stockType = value;
                base.OnPropertyChanged("StockType");
                UpdateDisplayButtonState();
            }
        }

        private bool CanDisplay()
        {
            return IsEnabled;
        }
        protected virtual void UpdateDisplayButtonState()
        {
            try
            {
                if (StockType != null && StockType.Id > 0)
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
       
        private void OnDisplayCommand()
        {
            try
            {
                ReportEngine.ReportLoadCompleted += ReportEngine_ReportLoadCompleted;
                base.OnInitialise(ReportType.StockListByType);
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
                StockListByTypeReport stockListByTypeReport = report as StockListByTypeReport;

                stockListByTypeReport.Type = StockType;
                ReportEngine reportEngine = new ReportEngine(stockListByTypeReport);
                reportEngine.Generate();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadAllStockType()
        {
            using (_worker = new BackgroundWorker())
            {
                _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadAllStockTypeCompleted);
                _worker.DoWork += (s, e) =>
                {
                    e.Result = _businessFacade.GetAllStockTypes();
                };
                _worker.RunWorkerAsync();
            }
        }

        private void OnLoadAllStockTypeCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                List<StockType> stockTypes = null;
                if (e.Result != null)
                {
                    stockTypes = e.Result as List<StockType>;
                }
               
                PopulateStockType(stockTypes);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void PopulateStockType(List<StockType> stockTypes)
        {
            try
            {
                if (stockTypes == null)
                {
                    stockTypes = new List<StockType>();
                }

                if (stockTypes.Count > 0)
                {
                    stockTypes.Insert(0, new StockType() { Id = 0, Name = "<< Select Type >>" });
                }

                _dispatcher.Invoke(() =>
                {
                    StockTypes = new ObservableCollection<StockType>(stockTypes);
                    StockType = StockTypes.FirstOrDefault();
                });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }








    }
}
