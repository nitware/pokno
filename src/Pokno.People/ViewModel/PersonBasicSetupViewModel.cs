using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.Events;
using Prism.Commands;
using Prism.Events;

namespace Pokno.People.ViewModel
{
    public class PersonBasicSetupViewModel : BaseApplicationViewModel
    {
        private int _selectedTabIndex;
        private IEventAggregator _eventAggregator;

        public PersonBasicSetupViewModel(IEventAggregator eventAggregator)
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
                        _eventAggregator.GetEvent<PersonBasicSetupEvent>().Publish(UI.PeopleSetup.Location);
                        break;
                    }
                case 1:
                    {
                        _eventAggregator.GetEvent<PersonBasicSetupEvent>().Publish(UI.PeopleSetup.PersonType);
                        break;
                    }
               
            }

        }




    }



}
