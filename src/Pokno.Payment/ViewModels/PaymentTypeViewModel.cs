using System;
using System.Net;
using System.Windows;
using System.Windows.Input;

using Pokno.Model;
using Pokno.Infrastructure.Interfaces;
using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure.Models;
using Prism.Commands;

namespace Pokno.Payment.ViewModels
{
    public class PaymentTypeViewModel : SetupViewModelBase<PaymentType> 
    {
        public PaymentTypeViewModel(ISetupService<PaymentType> _service)
            : base(_service) 
        {
            _modelName = "Payment Type";
            base.LoadAll();

            base._addSelector = l => l.Name.Equals(Model.Name.Replace(" ", "").Trim(), StringComparison.OrdinalIgnoreCase);
            base._modifySelector = l => l.Name.Equals(Model.Name.Replace(" ", "").Trim(), StringComparison.OrdinalIgnoreCase) && l.Id != Model.Id;

            IsLoggedInUserHasRight = Utility.LoggedInUser.Role.PersonRight.CanSetupPaymentType;
        }

        public string TabCaption
        {
            get { return "Payment Type"; }
        }

        protected override void OnSaveCommand()
        {
            try
            {
                if (base.InvalidEntry(Model.Name))
                {
                    return;
                }

                base.OnSaveCommand();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }



    }



}
