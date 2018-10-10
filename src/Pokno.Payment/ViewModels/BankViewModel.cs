using System;
using System.Net;
using System.Windows;
using System.Windows.Input;

using Pokno.Model;
using Pokno.Infrastructure.Interfaces;
using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure.Models;
using Prism.Events;

namespace Pokno.Payment.ViewModels
{
    public class BankViewModel : SetupViewModelBase<Bank>
    {
        public BankViewModel(ISetupService<Bank> _service)
            : base(_service)
        {
            _modelName = "Bank";
            base.LoadAll();

            base._addSelector = l => l.Name.Equals(Model.Name.Replace(" ", "").Trim(), StringComparison.OrdinalIgnoreCase);
            base._modifySelector = l => l.Name.Equals(Model.Name.Replace(" ", "").Trim(), StringComparison.OrdinalIgnoreCase) && l.Id != Model.Id;

            IsLoggedInUserHasRight = Utility.LoggedInUser.Role.PersonRight.CanSetupBank;
        }

        public string TabCaption
        {
            get { return "Bank"; }
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
