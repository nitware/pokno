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

using Pokno.Model.Model;
using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure.Interfaces;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.Events;
using System.Text.RegularExpressions;
using Prism.Events;

namespace Pokno.People.ViewModel
{
    public class CompanyViewModel : SetupViewModelBase<Company>
    {
        public CompanyViewModel(ISetupService<Company> _service, IEventAggregator eventAggregator)
            : base(_service)
        {
            _modelName = "Company";

            base._addSelector = c => c.Name.Equals(Model.Name.Replace(" ", "").Trim(), StringComparison.OrdinalIgnoreCase);
            base._modifySelector = c => c.Name.Equals(Model.Name.Replace(" ", "").Trim(), StringComparison.OrdinalIgnoreCase) && c.Id != Model.Id;

            IsLoggedInUserHasRight = Utility.LoggedInUser.Role.PersonRight.CanSetupCompany;
            eventAggregator.GetEvent<CompanySetupEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);

            OnInitialise(UI.PeopleCompany.Company);
        }

        private bool IsView(UI.PeopleCompany ui)
        {
            return ui == UI.PeopleCompany.Company;
        }
        public void OnInitialise(UI.PeopleCompany ui)
        {
            try
            {
                base.LoadAll();
                //UpdateViewState(Edit.Mode.Loaded);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        public string TabCaption
        {
            get { return _modelName; }
        }

        protected override void OnSaveCommand()
        {
            try
            {
                if (InvalidDataEntered())
                {
                    return;
                }

                base.OnSaveCommand();
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private bool InvalidDataEntered()
        {
            try
            {
                long mobileNumber = 0;
                const int ELEVEN = 11;
                const string EMAIL_PATTERN = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                const string WEBSITE = @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";

                //const string WEBSITE_2 = @"([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
                //const string WEBSITE = @"/^(https?):\/\/((?:[a-z0-9.-]|%[0-9A-F]{2}){3,})(?::(\d+))?((?:\/(?:[a-z0-9-._~!$&'()*+,;=:@]|%[0-9A-F]{2})*)*)(?:\?((?:[a-z0-9-._~!$&'()*+,;=:\/?@]|%[0-9A-F]{2})*))?(?:#((?:[a-z0-9-._~!$&'()*+,;=:\/?@]|%[0-9A-F]{2})*))?$/i;";
                //const string WEBSITE = @"^([a-zA-Z0-9+.-]+):(//([a-zA-Z0-9-._~!$&'()*+,;=:]*)@)?([a-zA-Z0-9-._~!$&'()*+,;=]+)(:(\\d*))?(/?[a-zA-Z0-9-._~!$&'()*+,;=:/]+)?(\\?[a-zA-Z0-9-._~!$&'()*+,;=:/?@]+)?(#[a-zA-Z0-9-._~!$&'()*+,;=:/?@]+)?$(:(\\d*))?(/?[a-zA-Z0-9-._~!$&'()*+,;=:/]+)?(\?[a-zA-Z0-9-._~!$&'()*+,;=:/?@]+)?(\#[a-zA-Z0-9-._~!$&'()*+,;=:/?@]+)?$";
                
                Regex emailPattern = new Regex(EMAIL_PATTERN, RegexOptions.IgnoreCase);
                Regex websitePattern = new Regex(WEBSITE, RegexOptions.IgnoreCase);
                //Regex websitePattern2 = new Regex(WEBSITE_2);

                if (base.InvalidEntry(Model.Name))
                {
                    return true;
                }
                else if (string.IsNullOrEmpty(Model.Address))
                {
                    MessageBox.Show("Please enter address!");
                    return true;
                }
                else if (!string.IsNullOrWhiteSpace(Model.Website))
                {
                    bool startsWithHttp = Model.Website.StartsWith("http");
                    bool startsWithHttps = Model.Website.StartsWith("https");

                    //bool validUrl = Uri.IsWellFormedUriString(Model.Website, UriKind.Absolute);
                    //if (!validUrl)
                    //{
                    //    Utility.DisplayMessage("Please enter a valid site URL!");
                    //    return true;
                    //}

                    //Uri uri = null;
                    //if (!Uri.TryCreate(Model.Website, UriKind.Absolute, out uri))
                    //{
                    //    Utility.DisplayMessage("Please enter a valid site URL!");
                    //    return true;
                    //}

                    if (startsWithHttp == true || startsWithHttps == true)
                    {
                        if (!websitePattern.IsMatch(Model.Website))
                        {
                            Utility.DisplayMessage("Please enter a valid site URL!");
                            return true;
                        }
                    }
                    else
                    {
                        string url = "http://" + Model.Website;
                        if (!websitePattern.IsMatch(url))
                        {
                            Utility.DisplayMessage("Please enter a valid site URL!");
                            return true;
                        }
                    }
                }
                else if (string.IsNullOrWhiteSpace(Model.Phone))
                {
                    Utility.DisplayMessage("Please enter mobile phone number!");
                    return true;
                }

                if (!string.IsNullOrWhiteSpace(Model.Email))
                {
                    if (!emailPattern.IsMatch(Model.Email))
                    {
                        Utility.DisplayMessage("Please enter a valid email address!");
                        return true;
                    }
                }

                if (Model.Phone.Trim().Length > 0)
                {
                    if (Model.Phone.Trim().Length == ELEVEN)
                    {
                        if (!long.TryParse(Model.Phone, out mobileNumber))
                        {
                            Utility.DisplayMessage("Please enter a valid mobile phone number (should not contain an alphabet)!");
                            return true;
                        }
                    }
                    else if (Model.Phone.Trim().Length != ELEVEN)
                    {
                        Utility.DisplayMessage("Please enter a valid mobile phone number (must be equal to " + ELEVEN + " numbers)!");
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
