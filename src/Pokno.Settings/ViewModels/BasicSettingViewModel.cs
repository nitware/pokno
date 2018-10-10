using System;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Service;
using Prism.Events;
using Prism.Commands;
using Pokno.Model.Model;
using Pokno.Infrastructure.Events;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace Pokno.Settings.ViewModels
{
    public class BasicSettingViewModel : BaseApplicationViewModel
    {
       
        private bool _clearDate;
        private Setting _setting;
        private Setting _oldSetting;
        private bool _settingCanBeSaved;
        private IBusinessFacade _service;
        private ApplicationMode _applicationMode;
        private ObservableCollection<ApplicationMode> _applicationModes;
        private bool _canSetApplicationDate;
       
        private IEventAggregator _eventAggregator;
        private BackgroundWorker _worker;

        public BasicSettingViewModel(IBusinessFacade service, IEventAggregator eventAggregator)
        {
            _service = service;
            _eventAggregator = eventAggregator;

            CanSetApplicationDate = Utility.LoggedInUser.Role.PersonRight.CanSetApplicationDate;
            SaveCommand = new DelegateCommand(OnSaveCommand, CanSave);
            ClearDateCommand = new DelegateCommand(OnClearDateCommand);
           
            OnInitialise();
        }

        public DelegateCommand SaveCommand { get; protected set; }
        public DelegateCommand ClearDateCommand { get; protected set; }

        public bool CanSetApplicationDate
        {
            get { return _canSetApplicationDate; }
            set
            {
                _canSetApplicationDate = value;
                base.OnPropertyChanged("CanSetApplicationDate");
            }
        }
       
        public string TabCaption
        {
            get { return "Basic Setting"; }
        }
       
        public Setting Setting
        {
            get { return _setting; }
            set
            {
                _setting = value;
                base.OnPropertyChanged("Setting");
            }
        }
        public Setting OldSetting
        {
            get { return _oldSetting; }
            set
            {
                _oldSetting = value;
                base.OnPropertyChanged("OldSetting");
            }
        }
        public bool ClearDate
        {
            get { return _clearDate; }
            set
            {
                _clearDate = value;
                base.OnPropertyChanged("ClearDate");
            }
        }
        public ApplicationMode ApplicationMode
        {
            get { return _applicationMode; }
            set
            {
                _applicationMode = value;
                base.OnPropertyChanged("ApplicationMode");
                SettingCanBeSaved = CanBeSaved();
            }
        }
        public ObservableCollection<ApplicationMode> ApplicationModes
        {
            get { return _applicationModes; }
            set
            {
                _applicationModes = value;
                base.OnPropertyChanged("ApplicationModes");
            }
        }
        public bool SettingCanBeSaved
        {
            get { return _settingCanBeSaved; }
            set
            {
                _settingCanBeSaved = value;
                base.OnPropertyChanged("SettingCanBeSaved");
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        private bool CanSave()
        {
            return SettingCanBeSaved;
        }
        public void OnInitialise()
        {
            try
            {
                IsLoggedInUserHasRight = true;

                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnInitialiseCompleted);
                    _worker.DoWork += (s, e) =>
                        {
                            e.Result = _service.GetSetting();
                        };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        private void OnInitialiseCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message, Utility.MessageIcon.Error);
                    return;
                }

                Setting = null;
                if (e.Result != null)
                {
                    Setting = e.Result as Setting;
                }

                if (Setting == null)
                {
                    Setting = new Setting();
                    Setting.ApplicationMode = new ApplicationMode();
                }

                StoreOldSetting();
                List<ApplicationMode> applicationModes = PopulateApplicationMode();
                ApplicationModes = new ObservableCollection<ApplicationMode>(applicationModes);
                if (ApplicationModes != null && ApplicationModes.Count > 0)
                {
                    if (Setting.ApplicationMode != null && Setting.ApplicationMode.Id > 0)
                    {
                        ApplicationMode = ApplicationModes.Where(a => a.Id == Setting.ApplicationMode.Id).SingleOrDefault();
                    }
                    else
                    {
                        ApplicationMode = ApplicationModes.FirstOrDefault();
                    }
                }

                

                Setting.PropertyChanged += Setting_PropertyChanged;
                SettingCanBeSaved = CanBeSaved();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }
        private void Setting_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SettingCanBeSaved = CanBeSaved();
        }

        private void OnClearDateCommand()
        {
            try
            {
                if (Setting != null)
                {
                    if (Setting.ApplicationDate != null)
                    {
                        Setting.ApplicationDate = null;
                    }
                    else
                    {
                        Setting.ApplicationDate = OldSetting.ApplicationDate != null ? OldSetting.ApplicationDate : Utility.GetDate();
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        private void StoreOldSetting()
        {
            try
            {
                OldSetting = new Setting();
                OldSetting.ApplicationMode = new ApplicationMode();
                OldSetting.ApplicationDate = Setting.ApplicationDate;
                OldSetting.ApplicationMode.Id = Setting.ApplicationMode.Id;
                OldSetting.IsCustomerLoyaltyEnabled = Setting.IsCustomerLoyaltyEnabled;
                OldSetting.ShowPackageRelationshipInStockSummaryReviewReport = Setting.ShowPackageRelationshipInStockSummaryReviewReport;
                OldSetting.IsActivated = Setting.IsActivated;
                OldSetting.IsDefaultDb = Setting.IsDefaultDb;
                OldSetting.DbPath = Setting.DbPath;
                OldSetting.Id = Setting.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<ApplicationMode> PopulateApplicationMode()
        {
            try
            {
                List<ApplicationMode> applicationModes = _service.GetAllApplicationModes();
                if (applicationModes != null && applicationModes.Count > 0)
                {
                    applicationModes.Insert(0, new ApplicationMode() { Id = 0, Name = "<< Select >>" });
                }

                return applicationModes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void OnSaveCommand()
        {
            try
            {
                //Setting.DbPath = DbPath;
                //Setting.IsDefaultDb = IsDefaultDb;
                Setting.ApplicationMode = ApplicationMode;

                bool added = _service.AddSetting(Setting);
                if (added)
                {
                    if (!string.IsNullOrWhiteSpace(Setting.DbPath))
                    {
                        _service.RefreshDatabase(Setting.DbPath);
                    }


                    StoreOldSetting();
                    Utility.Setting = Setting;
                    //Utility.SetDbPath();

                    SettingCanBeSaved = CanBeSaved();
                    Utility.DisplayMessage("Setting Save Operation was successful.", Utility.MessageIcon.Information);
                }
                else
                {
                    Utility.DisplayMessage("Setting Save Operation failed! Please try again", Utility.MessageIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        private bool CanBeSaved()
        {
            if (Setting == null || ApplicationMode == null || ApplicationMode.Id <= 0)
            {
                return false;
            }

            bool changesMade = OldSetting.ApplicationDate != Setting.ApplicationDate || OldSetting.ApplicationMode.Id != ApplicationMode.Id || OldSetting.IsActivated != Setting.IsActivated || OldSetting.IsCustomerLoyaltyEnabled != Setting.IsCustomerLoyaltyEnabled || OldSetting.IsDefaultDb != Setting.IsDefaultDb || OldSetting.DbPath != Setting.DbPath || OldSetting.ShowPackageRelationshipInStockSummaryReviewReport != Setting.ShowPackageRelationshipInStockSummaryReviewReport;

            return ApplicationMode != null && ApplicationMode.Id > 0 && changesMade == true;
        }



        





    }

}
