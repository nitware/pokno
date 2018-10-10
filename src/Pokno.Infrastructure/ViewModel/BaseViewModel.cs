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

using System.ComponentModel;
using System.Collections.Specialized;
using System.Windows.Threading;
using Pokno.Infrastructure.Models;
using Pokno.Infratructure.Services;
using Pokno.Service;
using Pokno.Model;
using Pokno.Infrastructure.Interfaces;

namespace Pokno.Infrastructure.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private Person _loggedInUser;
        public event PropertyChangedEventHandler PropertyChanged;
        
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Person LoggedInUser
        {
            get { return _loggedInUser; }
            set
            {
                _loggedInUser = value;
                OnPropertyChanged("LoggedInUser");
            }
        }




    }


}
