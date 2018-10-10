using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Model;
using System.ComponentModel;
using Prism.Commands;
using System.Windows.Input;
using Pokno.Infrastructure.Models;
using System.Windows;
using Pokno.Infratructure.Services;
using System.Windows.Threading;
using System.Windows.Data;
using Pokno.Service;

namespace Pokno.Infrastructure.ViewModel.Popups
{
    public class BankAccountDetailPopUpViewModel : BaseViewModel
    {
        private Bank _bank;
        private Cheque _cheque;
        private ListCollectionView _banks;

        private IBusinessFacade _service;
        private Dispatcher _dispatcher;
        private Window PopUp;

        public BankAccountDetailPopUpViewModel()
        {
            _dispatcher = Application.Current.Dispatcher;

            Cheque = new Cheque();
            OkCommand = new DelegateCommand(OnOkCommand);
            SetPopUpCommand = new DelegateCommand<object>(OnSetPopUpCommand);
            CancelCommand = new DelegateCommand(OnCancelCommand);
        }
                
        public DelegateCommand CancelCommand { get; private set; }
        public DelegateCommand OkCommand { get; private set; }
        public ICommand SetPopUpCommand { get; private set; }
        public bool? UserResponse { get; private set; }

        public IBusinessFacade BusinessFacade
        {
            set
            {
                _service = value;
            }
        }

        public Cheque Cheque 
        {
            get { return _cheque; }
            set
            {
                _cheque = value;
                OnPropertyChanged("Cheque");
            }
        }
        public Bank Bank 
        {
            get { return _bank; }
            set
            {
                _bank = value;
                OnPropertyChanged("Bank");
            }
        }
        public ListCollectionView Banks
        {
            get { return _banks; }
            set
            {
                _banks = value;
                OnPropertyChanged("Banks");
            }
        }
       
        private void OnOkCommand()
        {
            try
            {
                if (!IsAllDataEntered())
                {
                    return;
                }

                PopUp.DialogResult = true;
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private bool IsAllDataEntered()
        {
            try
            {
                if (Bank == null)
                {
                    Utility.DisplayMessage("Please select bank!");
                    return false;
                }
                else if (string.IsNullOrEmpty(Cheque.AccountNumber))
                {
                    Utility.DisplayMessage("Please enter account no.!");
                    return false;
                }
                else if (string.IsNullOrEmpty(Cheque.ChequeNumber))
                {
                    Utility.DisplayMessage("Please enter cheque no.!");
                    return false;
                }

                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private void OnCancelCommand()
        {
            PopUp.DialogResult = false;
        }

        private void OnSetPopUpCommand(object param)
        {
            PopUp = (Window)param;
        }
        private bool CanSetPopUp(object param)
        {
            return true;
        }

        public virtual void PopulateBankDropDown()
        {
            try
            {
                List<Bank> banks = _service.GetAllBanks();
                if (banks != null)
                {
                    if (banks.Count > 0)
                    {
                        banks.Insert(0, new Bank() { Name = "<< Select Bank >>" });
                    }

                    _dispatcher.Invoke(() =>
                    {
                        Banks = new ListCollectionView(banks);
                        if (Banks != null)
                        {
                            Banks.CurrentChanged += (sc, ea) =>
                            {
                                Bank = Banks.CurrentItem as Bank;
                                Cheque.Bank = Bank;
                            };
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }


       

    }


}
