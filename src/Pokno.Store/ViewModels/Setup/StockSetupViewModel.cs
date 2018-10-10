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

using Pokno.Infrastructure.Interfaces;
using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure.Events;
using Pokno.Infrastructure.Models;
using Pokno.Model;
using Prism.Events;
using Prism.Commands;

namespace Pokno.Store.ViewModels
{
    public class StockSetupViewModel : BaseApplicationViewModel 
    {
        private int _selectedTabIndex;
        private IEventAggregator _eventAggregator;

        public StockSetupViewModel(IEventAggregator eventAggregator)
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
                            _eventAggregator.GetEvent<StockSetupEvent>().Publish(UI.StockSetup.Category);
                            break;
                        }
                    case 1:
                        {
                            _eventAggregator.GetEvent<StockSetupEvent>().Publish(UI.StockSetup.Type);
                            break;
                        }
                    case 2:
                        {
                            _eventAggregator.GetEvent<StockSetupEvent>().Publish(UI.StockSetup.Product);
                            break;
                        }
                    case 3:
                        {
                            _eventAggregator.GetEvent<StockSetupEvent>().Publish(UI.StockSetup.Package);
                            break;
                        }
                    case 4:
                        {
                            _eventAggregator.GetEvent<StockSetupEvent>().Publish(UI.StockSetup.PackageReOrderLevel);
                            break;
                        }
                    case 5:
                        {
                            _eventAggregator.GetEvent<StockSetupEvent>().Publish(UI.StockSetup.PackageQuantity);
                            break;
                        }
                    case 6:
                        {
                            _eventAggregator.GetEvent<StockSetupEvent>().Publish(UI.StockSetup.Price);
                            break;
                        }
                    case 7:
                        {
                            _eventAggregator.GetEvent<StockSetupEvent>().Publish(UI.StockSetup.ExpensesCategory);
                            break;
                        }
                    case 8:
                        {
                            _eventAggregator.GetEvent<StockSetupEvent>().Publish(UI.StockSetup.State);
                            break;
                        }
                    case 9:
                        {
                            _eventAggregator.GetEvent<StockSetupEvent>().Publish(UI.StockSetup.ReturnAction);
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