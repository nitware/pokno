using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Events;
using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.Events;

namespace Pokno.Payment.ViewModels
{
    public class PaymentSetupViewModel : BaseApplicationViewModel
    {
        private int _selectedTabIndex;
        private IEventAggregator _eventAggregator;

        public PaymentSetupViewModel(IEventAggregator eventAggregator)
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

        public void OnTabItemSelectedCommand(int selectedTabIndex)
        {
            switch (selectedTabIndex)
            {
                case 0:
                    {
                        _eventAggregator.GetEvent<PaymentSetupEvent>().Publish(UI.PaymentSetup.PaymentType);
                        break;
                    }
                case 1:
                    {
                        _eventAggregator.GetEvent<PaymentSetupEvent>().Publish(UI.PaymentSetup.Bank);
                        break;
                    }
              


            }

        }






    }





}
