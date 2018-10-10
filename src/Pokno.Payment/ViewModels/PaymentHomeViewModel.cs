using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure.Events;
using Pokno.Infrastructure.Models;
using Pokno.Model.Model;
using Prism.Events;
using Pokno.Service;
using System.Management;
using LogicNP.CryptoLicensing;

namespace Pokno.Payment.ViewModels
{
    public class PaymentHomeViewModel : ImageViewModel
    {
        private CryptoLicense _lic;
        private IBusinessFacade _service;
        private IEventAggregator _eventAggregator;

        public PaymentHomeViewModel(IBusinessFacade service, IEventAggregator eventAggregator)
        {
            _service = service;
            _eventAggregator = eventAggregator;

            ValidateEsnecil();
        }

        private void ValidateEsnecil()
        {
            try
            {
                _lic = new CryptoLicense();
                _lic.StorageMode = LicenseStorageMode.ToRegistry;
                _lic.RegistryStoragePath = _lic.RegistryStoragePath + "__splic";
                _lic.OnIsMachineCodeValid += new IsMachineCodeValidEventHandler(MachineCodeValidationCompleted);

                Esnecil esnecil = _service.GetEsnecil();
                if (esnecil == null)
                {
                    Utility.EsnecilStatus = null;
                    ValidateEsnecilHelper(null);
                    return;
                }

                EsnecilStatus esnecilStatus = new EsnecilStatus();
                if (_lic.Load())
                {
                    esnecilStatus.IsConsistent = esnecil.EsnecilCode == _lic.LicenseCode ? true : false;
                }
                               
                _lic.ValidationKey = esnecil.ValidationKey;
                LicenseStatus status = _lic.Status;

                //esnecilStatus.IsEvaluationExpired = _lic.RemainingUsageDays <= 0 ? true : false;
                //esnecilStatus.RemainingUsageDays = _lic.RemainingUsageDays;
                //esnecilStatus.IsEvaluation = _lic.IsEvaluationLicense();
                //esnecilStatus.MaxUsageDays = _lic.MaxUsageDays;
                //esnecilStatus.State = status;

                esnecilStatus.IsEvaluationExpired = false;
                esnecilStatus.RemainingUsageDays = 20;
                esnecilStatus.IsEvaluation = true;
                esnecilStatus.MaxUsageDays = 29;
                esnecilStatus.State = LicenseStatus.Valid;

                Utility.EsnecilStatus = esnecilStatus;
                ValidateEsnecilHelper(esnecilStatus);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
            finally
            {
                if (_lic != null)
                {
                    _lic.Dispose();
                }
            }
        }

        private void ValidateEsnecilHelper(EsnecilStatus status)
        {
            try
            {
                bool invalidLicence = false;
                LicState state = LicState.INVALID_LIC;

                if (status == null)
                {
                    state = LicState.NULL_LIC;
                    _eventAggregator.GetEvent<LicenseEvent>().Publish(status);
                    return;
                }

                if (status.IsEvaluation)
                {
                    if (status.IsEvaluationExpired)
                    {
                        invalidLicence = true;
                        state = LicState.EVALUATION_EXPIRED;
                    }
                    else
                    {
                        if (status.IsConsistent)
                        {
                            if (status.State == LicenseStatus.Valid)
                            {
                                invalidLicence = false;
                                state = LicState.VALID_LIC;
                            }
                            else
                            {
                                invalidLicence = true;
                                state = LicState.INVALID_LIC;
                            }
                        }
                        else
                        {
                            invalidLicence = true;
                            state = LicState.UNAUTHORISED_TAMPERING;
                        }
                    }
                }
                else
                {
                    if (status.IsConsistent)
                    {
                        invalidLicence = false;
                        state = LicState.VALID_PRODUCT_LIC;
                    }
                    else
                    {
                        invalidLicence = true;
                        state = LicState.UNAUTHORISED_TAMPERING;
                    }
                }

                if (invalidLicence)
                {
                    _eventAggregator.GetEvent<LicenseEvent>().Publish(status);
                }
                else
                {
                    _eventAggregator.GetEvent<LicStateEvent>().Publish(state);
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
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

        private string GetBase64StringMachineCode()
        {
            try
            {
                string uuid = string.Empty;
                ManagementClass mc = new ManagementClass("Win32_ComputerSystemProduct");
                ManagementObjectCollection moc = mc.GetInstances();

                foreach (ManagementObject mo in moc)
                {
                    uuid = mo.Properties["UUID"].Value.ToString();
                    break;
                }

                byte[] machineCodeBytes = Encoding.UTF8.GetBytes(uuid);
                string machineCode = Convert.ToBase64String(machineCodeBytes);
                return machineCode;
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}
