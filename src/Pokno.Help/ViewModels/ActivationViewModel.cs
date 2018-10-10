using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using System.Windows;
using Pokno.Infrastructure.Models;
using Prism.Commands;
using System.Windows.Input;
using Pokno.Infrastructure.ViewModel;
using LogicNP.CryptoLicensing;
using Pokno.Model.Model;
using Prism.Regions;
using Pokno.Infrastructure;
using Prism.Events;
using Pokno.Infrastructure.Events;

namespace Pokno.Help.ViewModels
{
    public class ActivationViewModel : BaseViewModel
    {
        private Window PopUp;
        
        private string _license;
        private string _message;
        private string _key;

        private short _maxUsageDays;
        private short _remainingUsageDays;
        private string _evaluationStatus;
        private bool _canEvaluateStorePro;
        private string _continueEvaluationDescription;
        private string _continueEvaluationDescriptionColour;
        private bool _canActivateStorePro;
        private bool _isEvaluationCopy;
        private System.Windows.Media.Imaging.BitmapImage _copyImage;
        private readonly IBusinessFacade _businessFacade;

        private CryptoLicense _lic;
        private IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;

        public ActivationViewModel(IBusinessFacade businessFacade, IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _businessFacade = businessFacade;
            _eventAggregator = eventAggregator;

            ExitApplicationCommand = new DelegateCommand(OnExitApplicationCommand);
            ContinueEvaluationCommand = new DelegateCommand(OnContinueEvaluationCommand, CanContinueEvaluation);
            SetPopUpCommand = new DelegateCommand<object>(OnSetPopUpCommand);
            PurchaseCommand = new DelegateCommand(OnPurchaseCommand);
            ActivateCommand = new DelegateCommand(OnActivateCommand, CanActivate);
            CopyCommand = new DelegateCommand(OnCopyCommand);

            Initialise();
        }

        public ICommand SetPopUpCommand { get; private set; }
        public DelegateCommand PurchaseCommand { get; private set; }
        public DelegateCommand ExitApplicationCommand { get; private set; }
        public DelegateCommand ContinueEvaluationCommand { get; private set; }
        public DelegateCommand ActivateCommand { get; private set; }
        public DelegateCommand CopyCommand { get; private set; }

        public bool CanActivateStorePro
        {
            get { return _canActivateStorePro; }
            set
            {
                _canActivateStorePro = value;
                base.OnPropertyChanged("CanActivateStorePro");
                ActivateCommand.RaiseCanExecuteChanged();
            }
        }
        public bool CanEvaluateStorePro 
        {
            get { return _canEvaluateStorePro; }
            set
            {
                _canEvaluateStorePro = value;
                base.OnPropertyChanged("CanEvaluateStorePro");
                ContinueEvaluationCommand.RaiseCanExecuteChanged();
            }
        }
        public string ContinueEvaluationDescription 
        {
            get { return _continueEvaluationDescription; }
            set
            {
                _continueEvaluationDescription = value;
                base.OnPropertyChanged("ContinueEvaluationDescription");
            }
        }
        public string ContinueEvaluationDescriptionColour 
        {
            get { return _continueEvaluationDescriptionColour; }
            set
            {
                _continueEvaluationDescriptionColour = value;
                base.OnPropertyChanged("ContinueEvaluationDescriptionColour");
            }
        }

        public System.Windows.Media.Imaging.BitmapImage CopyImage
        {
            get { return _copyImage; }
            set
            {
                _copyImage = value;
                base.OnPropertyChanged("CopyImage");
            }
        }
        public bool IsEvaluationCopy
        {
            get { return _isEvaluationCopy; }
            set
            {
                _isEvaluationCopy = value;
                base.OnPropertyChanged("IsEvaluationCopy");
            }
        }
        public short MaxUsageDays
        {
            get { return _maxUsageDays; }
            set
            {
                _maxUsageDays = value;
                base.OnPropertyChanged("MaxUsageDays");
            }
        }
        public short RemainingUsageDays
        {
            get { return _remainingUsageDays; }
            set
            {
                _remainingUsageDays = value;
                base.OnPropertyChanged("RemainingUsageDays");
            }
        }
        public string EvaluationStatus
        {
            get { return _evaluationStatus; }
            set
            {
                _evaluationStatus = value;
                base.OnPropertyChanged("EvaluationStatus");
            }
        }
        public string Key
        {
            get { return _key; }
            set
            {
                _key = value;
                base.OnPropertyChanged("Key");
            }
        }
        public string License
        {
            get { return _license; }
            set
            {
                _license = value;
                base.OnPropertyChanged("License");
                //CanActivateStorePro = string.IsNullOrWhiteSpace(_license) ? false : true;
            }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                base.OnPropertyChanged("Message");
            }
        }

        private bool CanContinueEvaluation()
        {
            return CanEvaluateStorePro;
        }
        private bool CanActivate()
        {
            return true;
            //return CanActivateStorePro;
        }
             
        private void OnSetPopUpCommand(object param)
        {
            PopUp = (Window)param;
        }
        private void OnContinueEvaluationCommand()
        {
            try
            {
                //PopUp.DialogResult = true;

                Uri loginViewUri = new Uri("LoginView", UriKind.Relative);
                Uri menuViewUri = new Uri("HomeMenuView", UriKind.Relative);

                _regionManager.RequestNavigate(RegionContainer.Content, loginViewUri);
                _regionManager.RequestNavigate(RegionContainer.SubMenu, menuViewUri);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
       
        private void OnCopyCommand()
        {
            Clipboard.SetText(Key);
        }
        private void OnExitApplicationCommand()
        {
            Application.Current.Shutdown();
        }

        private void OnPurchaseCommand()
        {
            System.Diagnostics.Process.Start("http://www.nitware.com.ng/Product.aspx");
        }

        private void SetEsnecilStatus(EsnecilStatus status)
        {
            try
            {
                if (status == null)
                {
                    return;
                }

                const string TEMPLATE = "{0} of {1} day{2} remaining";
                if (status.IsEvaluation)
                {
                    MaxUsageDays = status.MaxUsageDays;
                    RemainingUsageDays = status.RemainingUsageDays;
                    IsEvaluationCopy = status.IsEvaluation;

                    //if (status.IsEvaluationExpired)
                    //{

                    //}
                                        
                    if (status.MaxUsageDays > 1)
                    {
                        EvaluationStatus = string.Format(TEMPLATE, RemainingUsageDays, MaxUsageDays, "s");
                    }
                    else
                    {
                        EvaluationStatus = string.Format(TEMPLATE, RemainingUsageDays, MaxUsageDays, "");
                    }

                    UpdateUIState(status);
                }
                else
                {
                    UpdateUIState(status);
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void UpdateUIState(EsnecilStatus status)
        {
            const string CONTINUE_USING_SOFTWARE = "To continue using this software, please purchase using the 'Purchase' button below. If you have your product key, enter it on the Product Key field in the 'Enter License' section and click the 'Activate' button to activate your software. Thank you for choosing storepro.";
            
            try
            {
                if (status.IsConsistent == false)
                {
                    CanActivateStorePro = true;
                    CanEvaluateStorePro = false;
                    ContinueEvaluationDescriptionColour = "Red";
                    ContinueEvaluationDescription = "Unauthorised license tampering detected! " + CONTINUE_USING_SOFTWARE;
                    //EvaluationStatus = "Inconsistency Detected";

                    return;
                }

                if (status.IsEvaluation)
                {
                    CanActivateStorePro = true;

                    if (status.IsEvaluationExpired)
                    {
                        CanEvaluateStorePro = false;
                        ContinueEvaluationDescriptionColour = "Red";
                        ContinueEvaluationDescription = "Your evaluation period has expired. " + CONTINUE_USING_SOFTWARE;
                        //EvaluationStatus = "Evaluation Period Expired";

                        return;
                    }

                    switch (status.State)
                    {
                        case LicenseStatus.Valid:
                            {
                                CanEvaluateStorePro = true;
                                ContinueEvaluationDescriptionColour = "Black";
                                ContinueEvaluationDescription = "To continue your evaluation of storepro, click the 'Continue Evaluation' button below";

                                break;
                            }
                        case LicenseStatus.EvaluationExpired:
                        case LicenseStatus.DateRollbackDetected:
                            {
                                CanEvaluateStorePro = false;
                                ContinueEvaluationDescriptionColour = "Red";
                                ContinueEvaluationDescription = "Unauthorised date interrupt was detected! " + CONTINUE_USING_SOFTWARE;
                                EvaluationStatus = "Date Interrupt Detected";

                                break;
                            }
                        default:
                            {
                                CanEvaluateStorePro = false;
                                ContinueEvaluationDescriptionColour = "Red";
                                ContinueEvaluationDescription = "Your product key is invalid. " + CONTINUE_USING_SOFTWARE;
                                EvaluationStatus = "Invalid License";

                                break;
                            }
                    }
                }
                else
                {
                    CanEvaluateStorePro = false;

                    switch (status.State)
                    {
                        case LicenseStatus.Valid:
                            {
                                CanActivateStorePro = false;
                                ContinueEvaluationDescriptionColour = "Green";
                                ContinueEvaluationDescription = "Your software has been successfully activated";

                                break;
                            }
                        default:
                            {
                                CanActivateStorePro = true;
                                ContinueEvaluationDescriptionColour = "Red";
                                ContinueEvaluationDescription = "Your product key is invalid. " + CONTINUE_USING_SOFTWARE;
                                EvaluationStatus = "Invalid License";

                                break;
                            }
                    }
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        //license.LicenseCode = @"VgAEgeJuNO4JC9IBJAA4MEEyRDdDMy0xNTkxLURGMTEtOTA5Ny05MEVEN0U5MjFBMzMQNjkBYeKjqSzPIyz9+hfe3zsTDxvXVt9NMHVxG50x3MWlzsKaXTCW709pv/TK01Ub";
        private void OnActivateCommand()
        {
            try
            {
                if (NoKeyProvided())
                {
                    return;
                }

                _lic = new CryptoLicense();
                _lic.StorageMode = LicenseStorageMode.ToRegistry;
                _lic.RegistryStoragePath = _lic.RegistryStoragePath + "__splic";
                _lic.OnIsMachineCodeValid += new IsMachineCodeValidEventHandler(MachineCodeValidationCompleted);

                Esnecil esnecil = _businessFacade.GetEsnecil();
                if (esnecil == null)
                {
                    throw new Exception("Esnecil load operation failed!");
                }

                _lic.LicenseCode = License;
                _lic.ValidationKey = esnecil.ValidationKey;

                LicenseStatus status = _lic.Status;
                if (status == LicenseStatus.Valid)
                {
                    esnecil.ActivationDate = Utility.GetDate();
                    esnecil.IsEvaluation = _lic.IsEvaluationLicense();
                    esnecil.EsnecilCode = License;
                    esnecil.MachineCode = Key;

                    //_lic.Remove();
                    EsnecilStatus esnecilStatus = new EsnecilStatus();
                    bool saved = _businessFacade.SaveEsnecil(esnecil);
                    if (saved)
                    {
                        esnecilStatus.IsConsistent = true;
                        esnecilStatus.IsEvaluation = _lic.IsEvaluationLicense();
                        esnecilStatus.RemainingUsageDays = _lic.RemainingUsageDays;
                        esnecilStatus.MaxUsageDays = _lic.MaxUsageDays;
                        esnecilStatus.State = status;
                        Utility.EsnecilStatus = esnecilStatus;
                                                
                        _lic.Save();
                        CanActivateStorePro = false;
                        SetEsnecilStatus(esnecilStatus);
                        IsEvaluationCopy = esnecilStatus.IsEvaluation;
                        _eventAggregator.GetEvent<LicenseEvent>().Publish(esnecilStatus);
                        
                        const string THANK_YOU = "\nThank you for choosing storepro.";
                        const string EVALUATION_EXTENSION = "Your have successfully extended your evaluation period to {0} day{1}." + THANK_YOU;
                        if (esnecilStatus.IsEvaluation)
                        {
                            if (esnecilStatus.MaxUsageDays > 1)
                            {
                                Utility.DisplayMessage(string.Format(EVALUATION_EXTENSION, esnecilStatus.MaxUsageDays, "s"));
                            }
                            else
                            {
                                Utility.DisplayMessage(string.Format(EVALUATION_EXTENSION, esnecilStatus.MaxUsageDays, ""));
                            }
                        }
                        else
                        {
                            Utility.DisplayMessage("Your have successfully activated your software." + THANK_YOU);
                        }
                    }
                    else
                    {
                        CanActivateStorePro = true;
                        Utility.DisplayMessage("Lic Sav Op failed! Please try again.");
                    }
                }
                else
                {
                    IsEvaluationCopy = true;
                    CanActivateStorePro = true;
                    Utility.DisplayMessage(status.ToString() + ": Activation failed!");
                }
            }
            catch(Exception ex)
            {
                Message = ex.Message;
            }
            finally
            {
                if (_lic != null)
                {
                    _lic.Dispose();
                }
            }
        }

        private bool NoKeyProvided()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(License))
                {
                    Utility.DisplayMessage("Please enter your product key!");
                    return true;
                }

                return false;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private void MachineCodeValidationCompleted(object sender, IsMachineCodeValidEventArgs e)
        {
            try
            {
                if (_lic.IsEvaluationLicense())
                {
                    e.Handled = true;
                    return;
                }


                byte[] licenseMachineCode = e.LicenseMachineCode;

                string storedMachineCodeString = GetBase64StringMachineCode();
                string licensemachineCodeString = Convert.ToBase64String(licenseMachineCode);

                e.IsValid = licensemachineCodeString == storedMachineCodeString ? true : false;
                e.Handled = true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Initialise()
        {
            try
            {
                SetCopyButtonImage();
                Key = GetBase64StringMachineCode();

                SetEsnecilStatus(Utility.EsnecilStatus);

                //_cryptoLicense = new CryptoLicense();
                //_cryptoLicense.ShowEvaluationInfoDialog("storepro 1.0", "http://www.ssware.com");
            }
            catch(Exception ex)
            {
                Message = ex.Message;
            }
        }

        private void SetCopyButtonImage()
        {
            try
            {
                CopyImage = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\copy.png");
            }
            catch(Exception)
            {
                throw;
            }
        }

        private string GetBase64StringMachineCode()
        {
            try
            {
                string uuid = string.Empty;

                System.Management.ManagementClass mc = new System.Management.ManagementClass("Win32_ComputerSystemProduct");
                System.Management.ManagementObjectCollection moc = mc.GetInstances();

                foreach (System.Management.ManagementObject mo in moc)
                {
                    uuid = mo.Properties["UUID"].Value.ToString();
                    break;
                }

                byte[] machineCodeBytes = Encoding.UTF8.GetBytes(uuid);
                string machineCode = Convert.ToBase64String(machineCodeBytes);
                return machineCode;
            }
            catch(Exception)
            {
                throw;
            }
        }

        


    }




}
