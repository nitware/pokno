using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Infratructure.Services;
using Pokno.Service;
using Pokno.Model;
using Pokno.Infrastructure.Models;

namespace Pokno.Infrastructure.ViewModel
{
    public abstract class BaseApplicationViewModel : BaseViewModel, INotifyCollectionChanged
    {
        private bool _isLoggedInUserHasRight;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public BaseApplicationViewModel()
        {
        }

        public void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (CollectionChanged != null)
            {
                CollectionChanged(this, e);
            }
        }
               
        public bool IsLoggedInUserHasRight
        {
            get { return _isLoggedInUserHasRight; }
            set
            {
                _isLoggedInUserHasRight = value;
                OnPropertyChanged("IsLoggedInUserHasRight");
            }
        }

       


        

    }


}
