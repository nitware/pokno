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
using Prism.Events;


namespace Pokno.Account.ViewModels
{
    public class ExpensesViewModel : BaseApplicationViewModel
    {
        private int _selectedTabIndex;
        private IEventAggregator _eventAggregator;

        public ExpensesViewModel(IEventAggregator eventAggregator)
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
            }
        }




    }
}
