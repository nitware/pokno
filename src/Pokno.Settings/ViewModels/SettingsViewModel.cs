using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Events;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure.Events;
using Pokno.Settings.Views;
using System.Windows;
using Pokno.Service;
using Prism.Commands;
using System.Windows.Input;

namespace Pokno.Settings.ViewModels
{
    public class SettingsViewModel : BaseApplicationViewModel
    {
        protected Window PopUp;
        private int _selectedTabIndex;
        
        public SettingsViewModel()
        {
            LoggedInUser = Utility.LoggedInUser;
        }
      
        public int SelectedTabIndex
        {
            get { return _selectedTabIndex; }
            set
            {
                _selectedTabIndex = value;
                base.OnPropertyChanged("SelectedTabIndex");
                //OnTabItemSelectedCommand(_selectedTabIndex);
            }
        }






    }






}
