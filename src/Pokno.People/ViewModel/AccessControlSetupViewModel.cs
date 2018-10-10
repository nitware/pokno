using System;
using System.Net;
using System.Windows;
using System.Windows.Input;

using Pokno.Infrastructure.ViewModel;
using Microsoft.Practices.Unity;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.Events;
using Prism.Events;
using Prism.Commands;

namespace Pokno.People.ViewModel
{
    public class AccessControlSetupViewModel : BaseApplicationViewModel
    {
        private int _selectedTabIndex;
        private IEventAggregator _eventAggregator;
        
        public AccessControlSetupViewModel(IEventAggregator eventAggregator)
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
                        _eventAggregator.GetEvent<PersonAccessControlEvent>().Publish(UI.PeopleAccessControl.Person);
                        break;
                    }
                case 1:
                    {
                        _eventAggregator.GetEvent<PersonAccessControlEvent>().Publish(UI.PeopleAccessControl.LoginDetail);
                        break;
                    }
                case 2:
                    {
                        _eventAggregator.GetEvent<PersonAccessControlEvent>().Publish(UI.PeopleAccessControl.Role);
                        break;
                    }
                case 3:
                    {
                        _eventAggregator.GetEvent<PersonAccessControlEvent>().Publish(UI.PeopleAccessControl.Right);
                        break;
                    }
                case 4:
                    {
                        _eventAggregator.GetEvent<PersonAccessControlEvent>().Publish(UI.PeopleAccessControl.AssignRightToRole);
                        break;
                    }
                case 5:
                    {
                        _eventAggregator.GetEvent<PersonAccessControlEvent>().Publish(UI.PeopleAccessControl.AssignRoleToPerson);
                        break;
                    }
            }

        }




    }


}
