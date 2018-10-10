using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Prism.Events;
using Prism.Commands;
using Pokno.Infrastructure.Events;
using Pokno.Infrastructure.Models;
using System.Text.RegularExpressions;
using Pokno.Infrastructure.ViewModel;
using Pokno.Model.Model;
using System.ComponentModel;

namespace Pokno.Settings.ViewModels
{
    public class StoreDetailViewModel : BaseApplicationViewModel
    {
        private bool _storeCanBeSaved;
        private readonly IBusinessFacade _service;
        private readonly IEventAggregator _eventAggregator;
        private BackgroundWorker _worker;
        private Store _store;
       
        public StoreDetailViewModel(IBusinessFacade service, IEventAggregator eventAggregator)
        {
            _service = service;
            _eventAggregator = eventAggregator;

            SaveCommand = new DelegateCommand(OnSaveCommand, CanSave);

            LoadStoreDetail();
        }

        public DelegateCommand SaveCommand { get; protected set; }

        public Store Store
        {
            get { return _store; }
            set 
            { 
                _store = value;
                base.OnPropertyChanged("Store");
            }
        }
        public bool StoreCanBeSaved
        {
            get { return _storeCanBeSaved; }
            set
            {
                _storeCanBeSaved = value;
                base.OnPropertyChanged("StoreCanBeSaved");
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
      
        private bool CanSave()
        {
            return StoreCanBeSaved;
        }
        private bool CanBeCleared()
        {
            return !string.IsNullOrWhiteSpace(Store.Name) || !string.IsNullOrWhiteSpace(Store.Address) || !string.IsNullOrWhiteSpace(Store.Description) || !string.IsNullOrWhiteSpace(Store.Email) || !string.IsNullOrWhiteSpace(Store.Phone) || !string.IsNullOrWhiteSpace(Store.Website) || !string.IsNullOrWhiteSpace(Store.Disclaimer);
        }
        private bool CanBeSaved()
        {
            return !string.IsNullOrWhiteSpace(Store.Name) && !string.IsNullOrWhiteSpace(Store.Address);
        }

        public void LoadStoreDetail()
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadStoreDetailCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        e.Result = _service.GetStore();
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        private void OnLoadStoreDetailCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message, Utility.MessageIcon.Error);
                    return;
                }

                Store = null;
                if (e.Result != null)
                {
                    Store = e.Result as Store;
                }

                if (Store == null)
                {
                    Store = new Store();
                }

                Store.PropertyChanged += Store_PropertyChanged;
                StoreCanBeSaved = CanBeSaved();
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }
               
        private void Store_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            StoreCanBeSaved = CanBeSaved();
        }
       
        private void OnSaveCommand()
        {
            try
            {
                if (InvalidDataEntered())
                {
                    return;
                }

                bool added = _service.AddStore(Store);
                if (added)
                {
                    _eventAggregator.GetEvent<StoreNameEvent>().Publish(Store.Name);
                    Utility.DisplayMessage("Store Detail Save Operation was successful.", Utility.MessageIcon.Information);
                }
                else
                {
                    Utility.DisplayMessage("Store Detail Save Operation failed! Please try again", Utility.MessageIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        private bool InvalidDataEntered()
        {
            try
            {
                long mobileNumber = 0;
                const string EMAIL_PATTERN = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                const string WEBSITE = @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
                const int ELEVEN = 11;

                Regex emailPattern = new Regex(EMAIL_PATTERN);
                Regex websitePattern = new Regex(WEBSITE);

                if (string.IsNullOrWhiteSpace(Store.Name))
                {
                    Utility.DisplayMessage("Please enter name!", Utility.MessageIcon.Exclamation);
                    return true;
                }
                else if (string.IsNullOrWhiteSpace(Store.Address))
                {
                    Utility.DisplayMessage("Please enter address!", Utility.MessageIcon.Exclamation);
                    return true;
                }
                else if (!string.IsNullOrWhiteSpace(Store.Website))
                {
                    if (!websitePattern.IsMatch(Store.Website))
                    {
                        Utility.DisplayMessage("Please enter a valid site URL!", Utility.MessageIcon.Exclamation);
                        return true;
                    }
                }
                else if (string.IsNullOrWhiteSpace(Store.Phone))
                {
                    Utility.DisplayMessage("Please enter mobile phone number!", Utility.MessageIcon.Exclamation);
                    return true;
                }

                if (!string.IsNullOrWhiteSpace(Store.Email))
                {
                    if (!emailPattern.IsMatch(Store.Email))
                    {
                        Utility.DisplayMessage("Please enter a valid email address!", Utility.MessageIcon.Exclamation);
                        return true;
                    }
                }

                if (Store.Phone.Trim().Length > 0)
                {
                    if (Store.Phone.Trim().Length == ELEVEN)
                    {
                        if (!long.TryParse(Store.Phone, out mobileNumber))
                        {
                            Utility.DisplayMessage("Please enter a valid mobile phone number (should not contain an alphabet)!", Utility.MessageIcon.Exclamation);
                            return true;
                        }
                    }
                    else if (Store.Phone.Trim().Length != ELEVEN)
                    {
                        Utility.DisplayMessage("Please enter a valid mobile phone number (must be equal to " + ELEVEN + " numbers)!", Utility.MessageIcon.Exclamation);
                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

       

       



    }


}
