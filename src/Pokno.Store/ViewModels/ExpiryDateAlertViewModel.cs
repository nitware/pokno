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

using System.Windows.Threading;
using System.Collections.ObjectModel;
using Pokno.Infrastructure.ViewModel;
using Pokno.Store.Interfaces;
using Pokno.Model.Model;
using System.Collections.Generic;
using Pokno.Infrastructure.Models;
using Prism.Events;
using Pokno.Infrastructure.Events;
using System.ComponentModel;

namespace Pokno.Store.ViewModels
{
    public class ExpiryDateAlertViewModel : BaseViewModel
    {
        private int _itemCount;
        private Dispatcher _dispatcher;
        private BackgroundWorker _worker;

        private readonly IExpiryDateAlertService _service;
        private ObservableCollection<ExpiryDateAlert> _aboutToExpiredStocks;

        public ExpiryDateAlertViewModel(IExpiryDateAlertService service, IEventAggregator eventAggregator)
        {
            _service = service;
            _dispatcher = Application.Current.Dispatcher;

            eventAggregator.GetEvent<StockPurchasedInitialiseEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);

            OnInitialise(UI.Store.ExpiredStocks);
        }
               
        public string TabCaption
        {
            //get { return "Stock Expiry Date Alert"; }
            get { return "Stocks About to Expire"; }
        }
        private bool IsView(UI.Store payload)
        {
            return payload == UI.Store.ExpiredStocks;
        }
        public int ItemCount 
        {
            get { return _itemCount; }
            set
            {
                _itemCount = value;
                base.OnPropertyChanged("ItemCount");
            }
        }
        public ObservableCollection<ExpiryDateAlert> AboutToExpiredStocks
        {
            get { return _aboutToExpiredStocks; }
            set
            {
                _aboutToExpiredStocks = value;
                base.OnPropertyChanged("AboutToExpiredStocks");
            }
        }
        private void OnInitialise(UI.Store payload)
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnInitialiseCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        e.Result = _service.GetAboutToExpiredStock();
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnInitialiseCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                    List<ExpiryDateAlert> aboutToExpireStocks = e.Result as List<ExpiryDateAlert>;
                    _dispatcher.Invoke(() =>
                    {
                        ItemCount = aboutToExpireStocks.Count;
                        AboutToExpiredStocks = new ObservableCollection<ExpiryDateAlert>(aboutToExpireStocks);
                    });
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }


      

        

        


    }

}
