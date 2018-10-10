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
using Pokno.Infrastructure.Events;
using Prism.Commands;
using Prism.Events;

namespace Pokno.People.ViewModel
{
    public class CompanySetupViewModel : BaseApplicationViewModel
    {
        private int _selectedTabIndex;
        private IEventAggregator _eventAggregator;

        public CompanySetupViewModel(IEventAggregator eventAggregator)
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
            switch (selectedTabIndex)
            {
                case 0:
                    {
                        _eventAggregator.GetEvent<CompanySetupEvent>().Publish(UI.PeopleCompany.Company);
                        break;
                    }
                case 1:
                    {
                        _eventAggregator.GetEvent<CompanySetupEvent>().Publish(UI.PeopleCompany.CompanyRepresentative);
                        break;
                    }
            }

        }






    }
}
