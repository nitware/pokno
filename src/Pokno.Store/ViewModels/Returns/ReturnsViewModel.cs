using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.Events;
using System.Windows.Threading;
using System.Windows;
using Prism.Events;

namespace Pokno.Store.ViewModels
{
    public class ReturnsViewModel : BaseApplicationViewModel
    {
        private int _selectedTabIndex;
        private IEventAggregator _eventAggregator;
        private readonly Dispatcher _dispatcher;

        public ReturnsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _dispatcher = Application.Current.Dispatcher;
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
                            _eventAggregator.GetEvent<ReturnEvent>().Publish(UI.Returns.Return);
                            break;
                        }
                    case 1:
                        {
                            _eventAggregator.GetEvent<ReturnEvent>().Publish(UI.Returns.ManageReplacedItems);
                            break;
                        }
                    case 2:
                        {
                            _eventAggregator.GetEvent<ReturnEvent>().Publish(UI.Returns.PurchaseReturn);
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
