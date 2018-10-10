using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure.Models;
using Prism.Commands;
using Pokno.Service;
using Pokno.Infrastructure.Events;
using Prism.Events;
using Pokno.Business.Interfaces;
using System.Windows.Media.Imaging;
using Pokno.Model.Model;

namespace Pokno.Settings.ViewModels
{
    public class StoreLogoViewModel : ImageViewModel
    {
        private string _logoFilePath;
        private string _logoFileName;
        private bool _logoIsUploadable;
        private bool _logoIsDeletetable;
        private Store _store;
        private BitmapImage _logo;

        private readonly IBusinessFacade _service;
        private readonly IEventAggregator _eventAggregator;
        private readonly IFileManager _fileManager;

        public StoreLogoViewModel(IBusinessFacade service, IFileManager fileManager, IEventAggregator eventAggregator)
        {
            if (service == null)
            {
                Utility.DisplayMessage("Argument 'service' cannot be null!", Utility.MessageIcon.Error);
            }
            if (fileManager == null)
            {
                Utility.DisplayMessage("Argument 'fileManager' cannot be null!", Utility.MessageIcon.Error);
            }
            if (eventAggregator == null)
            {
                Utility.DisplayMessage("Argument 'eventAggregator' cannot be null!", Utility.MessageIcon.Error);
            }

            _service = service;
            _fileManager = fileManager;
            _eventAggregator = eventAggregator;

            SelectLogoCommand = new DelegateCommand(OnSelectLogoCommand);
            UploadLogoCommand = new DelegateCommand(OnUploadLogoCommand, CanUploadLogo);
            DeleteLogoCommand = new DelegateCommand(OnDeleteLogoCommand, CanDeleteLogo);

            LoadLogo();
        }
               
        public DelegateCommand UploadLogoCommand { get; private set; }
        public DelegateCommand SelectLogoCommand { get; private set; }
        public DelegateCommand DeleteLogoCommand { get; private set; }
               
        public bool LogoIsUploadable
        {
            get { return _logoIsUploadable; }
            set
            {
                _logoIsUploadable = value;
                base.OnPropertyChanged("LogoIsUploadable");
                UploadLogoCommand.RaiseCanExecuteChanged();
            }
        }
        public bool LogoIsDeletetable
        {
            get { return _logoIsDeletetable; }
            set
            {
                _logoIsDeletetable = value;
                base.OnPropertyChanged("LogoIsDeletetable");
                DeleteLogoCommand.RaiseCanExecuteChanged();
            }
        }
        public BitmapImage Logo
        {
            get { return _logo; }
            set
            {
                _logo = value;
                base.OnPropertyChanged("Logo");
            }
        }
        public Store Store
        {
            get { return _store; }
            set
            {
                _store = value;
                base.OnPropertyChanged("Store");
            }
        }
        public string LogoFilePath
        {
            get { return _logoFilePath; }
            set
            {
                _logoFilePath = value;
                base.OnPropertyChanged("LogoFilePath");
            }
        }
        public string LogoFileName
        {
            get { return _logoFileName; }
            set
            {
                _logoFileName = value;
                base.OnPropertyChanged("LogoFileName");
            }
        }

        private bool CanDeleteLogo()
        {
            return LogoIsDeletetable;
        }
        private bool CanUploadLogo()
        {
            return LogoIsUploadable;
        }

        private void LoadLogo()
        {
            try
            {
                Store = _service.GetStore();
                if (Store == null)
                {
                    Store = new Model.Model.Store();
                }

                UpdateUI(Edit.Mode.Loaded);
                LogoFilePath = Store.LogoFileName;

                if (string.IsNullOrWhiteSpace(LogoFilePath))
                {
                    Logo = null;
                }
                else
                {
                    Logo = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\Logo\" + LogoFilePath);
                }
            }
            catch (Exception)
            {

            }
        }

        private void OnSelectLogoCommand()
        {
            try
            {
                string defaultExtension = ".jpeg";
                string fileFilter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

                string logoPath = Utility.ChooseFile(defaultExtension, fileFilter);
                if (string.IsNullOrWhiteSpace(logoPath))
                {
                    return;
                }


                LogoFilePath = logoPath;
                Logo = Utility.SetImageSource(LogoFilePath);
                UpdateUI(Edit.Mode.Selected);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        private void OnUploadLogoCommand()
        {
            try
            {
                if (!_fileManager.FileExist(LogoFilePath))
                {
                    Utility.DisplayMessage("File path '" + LogoFilePath + "' does not exist", Utility.MessageIcon.Exclamation);
                    return;
                }

                string destinationFolder = Utility.ApplicationRoot + @"Images\Logo";
                bool uploaded = _service.UploadStoreLogo(Store, destinationFolder, LogoFilePath, _fileManager);
                if (uploaded)
                {
                    UpdateUI(Edit.Mode.Loaded);
                    string logoFilePath = Utility.ApplicationRoot + @"Images\Logo\" + _fileManager.GetFileName(LogoFilePath);

                    _eventAggregator.GetEvent<StoreLogoEvent>().Publish(logoFilePath);
                    Utility.DisplayMessage("Store Logo Upload Operation was successful.", Utility.MessageIcon.Information);
                }
                else
                {
                    Utility.DisplayMessage("Store Logo Upload Operation failed! Please try again", Utility.MessageIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        private void OnDeleteLogoCommand()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Store.LogoFileName))
                {
                    Utility.DisplayMessage("Store Logo does not exist!", Utility.MessageIcon.Exclamation);
                    return;
                }

                string destinationFolder = Utility.ApplicationRoot + @"Images\Logo";
                bool deleted = _service.DeleteStoreLogo(Store, destinationFolder, _fileManager);
                if (deleted)
                {
                    LoadLogo();
                    _eventAggregator.GetEvent<StoreLogoEvent>().Publish(null);
                    Utility.DisplayMessage("Store Logo Delete Operation was successful.", Utility.MessageIcon.Information);
                }
                else
                {
                    Utility.DisplayMessage("Store Logo Delete Operation failed! Please try again", Utility.MessageIcon.Exclamation);
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        private void UpdateUI(Edit.Mode uiState)
        {
            try
            {
                switch(uiState)
                {
                    case Edit.Mode.Loaded:
                        {
                            LogoIsUploadable = false;
                            break;
                        }
                    case Edit.Mode.Selected:
                        {
                            LogoIsUploadable = true;
                            break;
                        }
                }

                if (Store != null && Store.Id > 0 && !string.IsNullOrWhiteSpace(Store.LogoFileName) )
                {
                    LogoIsDeletetable = true;
                }
                else
                {
                    LogoIsDeletetable = false;
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }






    }


}
