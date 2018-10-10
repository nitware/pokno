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

using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure.Models;
using Prism.Commands;
using Prism.Events;
using Pokno.Infrastructure.Events;

namespace Pokno.Store.ViewModels
{
    public class SalesViewModel : BaseApplicationViewModel
    {
        private int _selectedTabIndex;
        private IEventAggregator _eventAggregator;

        public SalesViewModel(IEventAggregator eventAggregator)
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
                            _eventAggregator.GetEvent<SalesEvent>().Publish(UI.Sales.SellStock);
                            break;
                        }
                    case 1:
                        {
                            _eventAggregator.GetEvent<SalesEvent>().Publish(UI.Sales.EditSoldItems);
                            break;
                        }
                    //case 2:
                    //    {
                    //        _eventAggregator.GetEvent<SalesEvent>().Publish(UI.Sales.DeleteSalesTransaction);
                    //        break;
                    //    }
                    case 2:
                        {
                            _eventAggregator.GetEvent<SalesEvent>().Publish(UI.Sales.StockPriceCheck);
                            break;
                        }
                    case 3:
                        {
                            _eventAggregator.GetEvent<SalesEvent>().Publish(UI.Sales.DailySales);
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
