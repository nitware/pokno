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

using Pokno.Infrastructure.Events;
using Pokno.Infrastructure.Models;
using Prism.Events;
using Prism.Commands;
using Pokno.Infrastructure.ViewModel;

namespace Pokno.Store.ViewModels
{
    public class StockPurchasedViewModel : BaseApplicationViewModel
    {
        private int _selectedTabIndex;
        private IEventAggregator _eventAggregator;

        public StockPurchasedViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            LoggedInUser = Utility.LoggedInUser;
        }
                
        public int SelectedTabIndex 
        {
            get { return _selectedTabIndex; }
            set 
            { 
                _selectedTabIndex = value;
                base.OnPropertyChanged("SelectedTabIndex");

                OnTabItemSelectedCommand(_selectedTabIndex);
            } 
        }

        public void OnTabItemSelectedCommand(int selectedTabIndex)
        {
            try
            {
                switch (selectedTabIndex)
                {
                    case 0:
                        {
                            _eventAggregator.GetEvent<StockPurchasedInitialiseEvent>().Publish(UI.Store.ExpiredStocks);
                            break;
                        }
                    case 1:
                        {
                            _eventAggregator.GetEvent<StockPurchasedInitialiseEvent>().Publish(UI.Store.RegisterPurchasedStock);
                            break;
                        }
                    case 2:
                        {
                            _eventAggregator.GetEvent<StockPurchasedInitialiseEvent>().Publish(UI.Store.ModifyPurchasedStock);
                            break;
                        }
                    case 3:
                        {
                            _eventAggregator.GetEvent<StockPurchasedInitialiseEvent>().Publish(UI.Store.ArrangeStockOnShelf);
                            break;
                        }
                    case 4:
                        {
                            _eventAggregator.GetEvent<StockPurchasedInitialiseEvent>().Publish(UI.Store.ViewStockOnShelf);
                            break;
                        }
                    case 5:
                        {
                            _eventAggregator.GetEvent<StockPurchasedInitialiseEvent>().Publish(UI.Store.RemoveStockFromShelf);
                            break;
                        }
                    //case 5:
                    //    {
                    //        _eventAggregator.GetEvent<StockPurchasedInitialiseEvent>().Publish(UI.Store.ExpiredStocks);
                    //        break;
                    //    }
                    case 6:
                        {
                            _eventAggregator.GetEvent<StockPurchasedInitialiseEvent>().Publish(UI.Store.YearlyStockSummary);
                            break;
                        }

                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }






    }

}
