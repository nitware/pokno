using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using System.Windows;
using Pokno.Infrastructure.Model;
using Prism.Commands;
using System.Windows.Input;
using Pokno.Infrastructure.ViewModel;
using LogicNP.CryptoLicensing;
using Pokno.Model.Model;

namespace Pokno.Help.ViewModels
{
    public class ActivationViewModel2 : BaseViewModel
    {
        private Window PopUp;
        private IBusinessFacade _businessFacade;
        private string _license;
        private string _message;
        private string _key;

        public ActivationViewModel2()
        {
            ExitApplicationCommand = new DelegateCommand(OnExitApplicationCommand);
            ContinueEvaluationCommand = new DelegateCommand(OnContinueEvaluationCommand);
            SetPopUpCommand = new DelegateCommand<object>(OnSetPopUpCommand);
            PurchaseCommand = new DelegateCommand(OnPurchaseCommand);
            ActivateCommand = new DelegateCommand(OnActivateCommand);

            _businessFacade = new BusinessFacade(Utility.DbPath);

            Initialise();
        }

        public ActivationViewModel2(IBusinessFacade businessFacade)
        {
            _businessFacade = businessFacade;
        }
                
        public ICommand SetPopUpCommand { get; private set; }
        public DelegateCommand PurchaseCommand { get; private set; }
        public DelegateCommand ExitApplicationCommand { get; private set; }
        public DelegateCommand ContinueEvaluationCommand { get; private set; }
        public DelegateCommand ActivateCommand { get; private set; }

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
        //public IBusinessFacade BusinessFacade
        //{
        //    set { _businessFacade = value; }
        //}

        private void OnSetPopUpCommand(object param)
        {
            PopUp = (Window)param;
        }
        private void OnContinueEvaluationCommand()
        {
            PopUp.DialogResult = true;
        }
       
        private void OnExitApplicationCommand()
        {
            Application.Current.Shutdown();
        }

        private void OnPurchaseCommand()
        {
            System.Diagnostics.Process.Start("http://www.nitware.com.ng/Product.aspx");
        }

        //license.LicenseCode = @"VgAEgeJuNO4JC9IBJAA4MEEyRDdDMy0xNTkxLURGMTEtOTA5Ny05MEVEN0U5MjFBMzMQNjkBYeKjqSzPIyz9+hfe3zsTDxvXVt9NMHVxG50x3MWlzsKaXTCW709pv/TK01Ub";
        private void OnActivateCommand()
        {
            try
            {
                CryptoLicense license = new CryptoLicense();
                //license.OnIsMachineCodeValid += new IsMachineCodeValidEventHandler(MachineCodeValidationCompleted);

                //FgIFgfA2JoqyENIBAgABABAx4jZO16ds1spmUjf6zp45CXLnSbFlnNmLXVR9Flpu45128MlyhvCocCvJ3ehdqc8=

                //license.LicenseCode = License;
                license.LicenseCode = "FgIFgRKCdLqzENIBAgABABBILtIeNZzCB+xNYbkQVduap/7Fd0PlNy1zNFxSfXbcpOlbQNfxS2wEyC8lYGwxyfo=";
                license.ValidationKey = "AMAAMACMZ+k9NYCAAx31+QobyDI/Wb0mY5yvGsrfN+QTexwJCbcBEjtk7T21sv6T2l6wlp8DAAEAAQ==";
                LicenseStatus status = license.Status;
                

                //bool hasMachineCode = license.HasMachineCode;
                //bool HasMaxActivations = license.HasMaxActivations;
                //bool HasNumberOfUsers = license.HasNumberOfUsers;
                //bool HasProfileName = license.HasProfileName;
                //bool HasUserData = license.HasUserData;
                
                
                if (status == LicenseStatus.Valid)
                {
                    Esnecil esnecil = new Esnecil();
                    esnecil.MachineCode = Key;
                    esnecil.EsnecilCode = License;
                    esnecil.ActivationDate = Utility.GetDate();
                    
                    bool saved =_businessFacade.SaveEsnecil(esnecil);
                    if (saved)
                    {
                        PopUp.DialogResult = true;
                    }
                    else
                    {
                        Message = "Lic Sav Op failed! Please try again.";
                    }
                }
                else
                {
                    Message = "Activation failed!";
                }
            }
            catch(Exception ex)
            {
                Message = ex.Message;
            }
        }

        private void MachineCodeValidationCompleted(object sender, IsMachineCodeValidEventArgs e)
        {
            try
            {
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
                Key = GetBase64StringMachineCode();
            }
            catch(Exception ex)
            {
                Message = ex.Message;
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
