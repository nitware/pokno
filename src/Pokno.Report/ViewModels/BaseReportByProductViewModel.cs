using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Model;
using Prism.Commands;
using System.Windows;
using System.ComponentModel;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using Pokno.Infrastructure.Models;
using Pokno.Common.Interfaces;

namespace Pokno.Report.ViewModels
{
    public abstract class BaseReportByProductViewModel : BaseReportViewModel
    {
        private Model.Stock _stock;
        private bool _isEnabled;
        private ObservableCollection<Model.Stock> _stocks;

        private readonly Dispatcher _dispatcher;
        private readonly IBusinessFacade _service;
        private BackgroundWorker _worker;

        public BaseReportByProductViewModel(IBusinessFacade service, IBaseReportFactory reportFactory)
            : base(reportFactory)
        {
            _service = service;
            _dispatcher = Application.Current.Dispatcher;

            DisplayCommand = new DelegateCommand(OnDisplayCommand, CanDisplay);

            LoadAllProduct();
            UpdateDisplayButtonState();
        }

        protected abstract void OnDisplayCommand();

        //protected virtual void OnDisplayCommand()
        //{
        //    try
        //    {
        //        Pokno.Common.Models.ReportEngine.ReportLoadCompleted += ReportEngine_ReportLoadCompleted;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
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

        private bool CanDisplay()
        {
            return IsEnabled;
        }

        private void LoadAllProduct()
        {
            using (_worker = new BackgroundWorker())
            {
                _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadAllProductCompleted);
                _worker.DoWork += (o, e) =>
                {
                    e.Result = _service.GetAllStocks();
                };
                _worker.RunWorkerAsync();
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
                    PopulateProduct(stocks);
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void PopulateProduct(List<Model.Stock> stocks)
        {
            try
            {
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

        protected void UpdateDisplayButtonState()
        {
            try
            {
                if (Stock != null && Stock.Id > 0)
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
