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
using Microsoft.Practices.Unity;
using Pokno.Infrastructure.Interfaces;
using Pokno.Infrastructure.Models;
using System.Windows.Threading;
using System.ComponentModel;
using System.Windows.Data;
using Pokno.Infrastructure.Events;
using Prism.Commands;
using Prism.Events;
using Pokno.People.Interfaces;
using Pokno.Model.Model;
using System.Collections.Generic;

namespace Pokno.People.ViewModel
{
    public class LoginDetailsViewModel : BaseViewModel
    {
        private Dispatcher _dispatcher;
        
        private ILoginDetailService _service;
        private ListCollectionView _loginDetails;
        private LoginDetail _loginDetail;

        private bool _canSaveItem;
        private bool _canResetItem;
        private bool _canClearView;
        private string _recordCount;

        private BackgroundWorker _worker;

        public LoginDetailsViewModel(ILoginDetailService service, IEventAggregator eventAggregator)
        {
            _service = service;
            _dispatcher = Application.Current.Dispatcher; 

            SaveCommand = new DelegateCommand(OnSaveCommand, CanSave);
            ClearCommand = new DelegateCommand(OnClearCommand, CanClear);
            ResetCommand = new DelegateCommand(OnResetCommand, CanReset);

            eventAggregator.GetEvent<PersonAccessControlEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);
        }
                
        public DelegateCommand SaveCommand { get; private set; }
        public DelegateCommand ClearCommand { get; private set; }
        public DelegateCommand ResetCommand { get; private set; }

        public string TabCaption
        {
            get { return "Login Detail"; }
        }
        public string RecordCount
        {
            get { return _recordCount; }
            set
            {
                _recordCount = value;
                base.OnPropertyChanged("RecordCount");
            }
        }
        public ListCollectionView LoginDetails
        {
            get { return _loginDetails; }
            set
            {
                _loginDetails = value;
                OnPropertyChanged("LoginDetails");
            }
        }
        public LoginDetail LoginDetail
        {
            get { return _loginDetail; }
            set
            {
                _loginDetail = value;
                OnPropertyChanged("LoginDetail");
            }
        }

        public bool CanSaveItem
        {
            get { return _canSaveItem; }
            set
            {
                _canSaveItem = value;
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        public bool CanResetItem
        {
            get { return _canResetItem; }
            set
            {
                _canResetItem = value;
                ResetCommand.RaiseCanExecuteChanged();
            }
        }
        public bool CanClearView
        {
            get { return _canClearView; }
            set
            {
                _canClearView = value;
                ClearCommand.RaiseCanExecuteChanged();
            }
        }

        private bool CanSave()
        {
            return CanSaveItem;
        }
        private bool CanClear()
        {
            return CanClearView;
        }
        private bool CanReset()
        {
            return CanResetItem;
        }

        private bool IsView(UI.PeopleAccessControl ui)
        {
            return ui == UI.PeopleAccessControl.LoginDetail;
        }
        public void OnInitialise(UI.PeopleAccessControl ui)
        {
            try
            {
                LoadAllLoginDetail();
                UpdateViewState(Edit.Mode.Loaded);
                
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void LoadAllLoginDetail()
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnInitialiseCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        e.Result = _service.LoadAll();
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnInitialiseCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                if (e.Result != null)
                {
                    List<LoginDetail> loginDetails = e.Result as List<LoginDetail>;

                    RecordCount = "Record Count: " + loginDetails.Count;
                    LoginDetails = new ListCollectionView(loginDetails);

                    LoginDetails.MoveCurrentTo(null);
                    LoginDetails.CurrentChanged += (sl, el) =>
                    {
                        LoginDetail = LoginDetails.CurrentItem as LoginDetail;
                        if (LoginDetail != null && !string.IsNullOrWhiteSpace(LoginDetail.Username))
                        {
                            UpdateViewState(Edit.Mode.Editing);
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void OnSaveCommand()
        {
            try
            {
                if (LoginDetail == null)
                {
                    Utility.DisplayMessage("No login detail selected from the tray! Please select ");
                    return;
                }

                bool done = _service.Modify(LoginDetail);
                ActionCompleted(done);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        protected void OnClearCommand()
        {
            try
            {
                _dispatcher.Invoke(() =>
                   {
                       LoginDetail = new LoginDetail();
                       if (LoginDetails != null)
                       {
                           LoginDetails.MoveCurrentTo(null);
                           UpdateViewState(Edit.Mode.Loaded);
                       }
                   });
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        protected void OnResetCommand()
        {
            try
            {
                if (LoginDetail == null)
                {
                    Utility.DisplayMessage("No login detail selected from the list! Please select");
                    return;
                }

                bool done = _service.Reset(LoginDetail);
                ActionCompleted(done);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void ActionCompleted(bool done)
        {
            try
            {
                _dispatcher.Invoke(() =>
                {
                    if (done)
                    {
                        OnClearCommand();
                        LoadAllLoginDetail();
                                               
                        UpdateViewState(Edit.Mode.Loaded);
                        Utility.DisplayMessage("Changes made to user account has been successfully saved.");
                    }
                    else
                    {
                        Utility.DisplayMessage("Change operation on user account failed!");
                    }
                });
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void UpdateViewState(Edit.Mode viewState)
        {
            try
            {
                switch (viewState)
                {
                    case Edit.Mode.Adding:
                    case Edit.Mode.Loaded:
                        {
                            CanSaveItem = false;
                            CanResetItem = false;
                            CanClearView = false;

                            break;
                        }
                    case Edit.Mode.Editing:
                        {
                            CanSaveItem = true;
                            CanResetItem = true;
                            CanClearView = true;

                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }






    }


}
