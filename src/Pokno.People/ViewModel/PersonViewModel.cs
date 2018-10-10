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

using Microsoft.Practices.Unity;
using System.ComponentModel;
using System.Windows.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.Events;
using Pokno.Infrastructure.Services;
using Pokno.Infrastructure.Interfaces;
using Pokno.Infrastructure.ViewModel;
using Pokno.Model;
using Prism.Events;
using System.Collections.ObjectModel;

namespace Pokno.People.ViewModel
{
    public class PersonViewModel : SetupViewModelBase<Person>
    {
        private Location _location;
        private PersonType _personType;
        private ObservableCollection<Location> _locations;
        private ObservableCollection<PersonType> _personTypes;
        private readonly ISetupService<PersonType> _personTypeService;
        private readonly ISetupService<Location> _locationService;
        private BackgroundWorker _worker;

        //protected override string 

        public PersonViewModel(ISetupService<Person> service, ISetupService<Location> locationService, ISetupService<PersonType> personTypeService, IEventAggregator eventAggregator)
            : base(service)
        {
            base.NAME = "FullName";
            TabCaption = "Person";

            _locationService = locationService;
            _personTypeService = personTypeService;

            //base._addSelector = p => p.FirstName.Trim().Equals(Model.FirstName.Trim(), StringComparison.CurrentCultureIgnoreCase) && p.LastName.Trim().Equals(Model.LastName.Trim(), StringComparison.CurrentCultureIgnoreCase) && p.OtherName.Trim().Equals(Model.OtherName.Trim(), StringComparison.CurrentCultureIgnoreCase);
            //base._modifySelector = p => p.FirstName.Trim().Equals(Model.FirstName.Trim(), StringComparison.CurrentCultureIgnoreCase) && p.LastName.Trim().Equals(Model.LastName.Trim(), StringComparison.CurrentCultureIgnoreCase) && p.OtherName.Trim().Equals(Model.OtherName.Trim(), StringComparison.CurrentCultureIgnoreCase) && p.Id != Model.Id;

            base._addSelector = p => p.FullName.Equals(Model.FullName.Replace(" ", "").Trim(), StringComparison.CurrentCultureIgnoreCase);
            base._modifySelector = p => p.FullName.Equals(Model.FullName.Replace(" ", "").Trim(), StringComparison.CurrentCultureIgnoreCase) && p.Id != Model.Id;
            
            IsLoggedInUserHasRight = Utility.LoggedInUser.Role.PersonRight.CanSetupUser;
            eventAggregator.GetEvent<PersonAccessControlEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);
            
            OnInitialise(UI.PeopleAccessControl.Person);
        }
               
        public string TabCaption
        {
            get { return _modelName; }
            set 
            { 
                _modelName = value;
                base.OnPropertyChanged("TabCaption");
            }
        }
        public Location Location
        {
            get { return _location; }
            set
            {
                _location = value;
                base.OnPropertyChanged("Location");
            }
        }
        public ObservableCollection<Location> Locations
        {
            get { return _locations; }
            set
            {
                _locations = value;
                base.OnPropertyChanged("Locations");
            }
        }
        public ObservableCollection<PersonType> PersonTypes
        {
            get { return _personTypes; }
            set
            {
                _personTypes = value;
                base.OnPropertyChanged("PersonTypes");
            }
        }
        public PersonType PersonType
        {
            get { return _personType; }
            set
            {
                _personType = value;
                base.OnPropertyChanged("PersonType");
            }
        }

        private bool IsView(UI.PeopleAccessControl ui)
        {
            return ui == UI.PeopleAccessControl.Person;
        }
        public void OnInitialise(UI.PeopleAccessControl ui)
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnInitialiseCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        List<Person> people = _service.LoadAll();
                        List<PersonType> personTypes = _personTypeService.LoadAll();
                        List<Location> locations = _locationService.LoadAll();

                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
                        dictionary["personTypes"] = personTypes;
                        dictionary["locations"] = locations;
                        dictionary["people"] = people;

                        e.Result = dictionary;
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
                    Dictionary<string, object> dictionary = e.Result as Dictionary<string, object>;
                    List<PersonType> personTypes = (List<PersonType>)dictionary["personTypes"];
                    List<Location> locations = (List<Location>)dictionary["locations"];
                    List<Person> people = (List<Person>)dictionary["people"];

                    PopulatePeople(people);
                    PopulatePersonType(personTypes);
                    PopulateLocation(locations);
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void PopulateLocation(List<Location> locations)
        {
            try
            {
                if (locations != null)
                {
                    if (locations != null && locations.Count > 0)
                    {
                        locations.Insert(0, new Location() { Name = "<< Select Location >>" });
                    }

                    _dispatcher.Invoke(() =>
                    {
                        Locations = new ObservableCollection<Location>(locations);
                        Location = Locations.FirstOrDefault();
                    });
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        protected override void OnSaveCommand()
        {
            try
            {
                if (InvalidDataEntered())
                {
                    return;
                }

                Model.Name = Model.FirstName + " " + Model.LastName;
                Model.FullName = Model.FirstName + " " + Model.LastName +  " " + Model.OtherName;
                if (base.InvalidEntry(Model.FullName))
                {
                    return;
                }
                                
                Model.Type = PersonType;
                Model.Location = Location;
                Model.Role = new Role() { Id = 1 };

                base.OnSaveCommand();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        //protected override List<Person> RemoveSpacesFromModelNamePropertyValue(List<Person> models)
        //{
        //    try
        //    {
        //        return models;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        private bool InvalidDataEntered()
        {
            try
            {
                long mobileNumber = 0;
                const string EMAIL_PATTERN = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                Regex emailPattern = new Regex(EMAIL_PATTERN);

                if (string.IsNullOrWhiteSpace(Model.LastName))
                {
                    Utility.DisplayMessage("Please enter surname!");
                    return true;
                }
                if (string.IsNullOrWhiteSpace(Model.FirstName))
                {
                    Utility.DisplayMessage("Please enter first name!");
                    return true;
                }
                else if (PersonType == null || PersonType.Id <= 0)
                {
                    Utility.DisplayMessage("Please select a Person Type!");
                    return true;
                }
                else if (string.IsNullOrWhiteSpace(Model.MobilePhone))
                {
                    Utility.DisplayMessage("Please enter mobile phone number!");
                    return true;
                }
                else if (string.IsNullOrWhiteSpace(Model.ContactAddress))
                {
                    Utility.DisplayMessage("Please enter contact address!");
                    return true;
                }
                else if (Location == null || Location.Id <= 0)
                {
                    Utility.DisplayMessage("Please select location!");
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

                if (Model.MobilePhone.Trim().Length > 0)
                {
                    if (Model.MobilePhone.Trim().Length == 11)
                    {
                        if (!long.TryParse(Model.MobilePhone, out mobileNumber))
                        {
                            Utility.DisplayMessage("Please enter a valid mobile phone number (should not contain an alphabet)!");
                            return true;
                        }
                    }
                    else if (Model.MobilePhone.Trim().Length != 11)
                    {
                        Utility.DisplayMessage("Please enter a valid mobile phone number (must be equal to 11 numbers)!");
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

        protected override void ClearHelper()
        {
            try
            {
                base.ClearHelper();
                if (PersonTypes != null && PersonTypes.Count > 0)
                {
                    PersonType = PersonTypes.FirstOrDefault();
                }
                if (Locations != null && Locations.Count > 0)
                {
                    Location = Locations.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void PopulatePersonType(List<PersonType> personTypes)
        {
            try
            {
                if (personTypes != null)
                {
                    if (personTypes.Count > 0)
                    {
                        personTypes.Insert(0, new PersonType() { Name = "<< Person Type >>" });
                    }

                    _dispatcher.Invoke(() =>
                    {
                        PersonTypes = new ObservableCollection<PersonType>(personTypes);
                        PersonType = PersonTypes.FirstOrDefault();
                    });
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void PopulatePeople(List<Person> people)
        {
            try
            {
                Models = new ListCollectionView(new List<Person>());
                if (people != null && people.Count > 0)
                {
                    _dispatcher.Invoke(() =>
                    {
                        ReturnedModels = people;
                        RecordCount = RecordCountLabel + people.Count;
                        Models = new ListCollectionView(people);

                        LoadAllHelper();
                    });
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected override void LoadAllHelper()
        {
            try
            {
                if (Models != null)
                {
                    Models.MoveCurrentTo(null);
                    Models.CurrentChanged += (s, e) =>
                    {
                        if (Models.CurrentItem != null)
                        {
                            Model = Models.CurrentItem as Person;
                            if (PersonTypes != null && Model.Type != null && Model.Type.Id > 0)
                            {
                                PersonType = PersonTypes.Where(p => p.Id == Model.Type.Id).SingleOrDefault();
                            }
                            if (Locations != null && Model.Location != null && Model.Location.Id > 0)
                            {
                                Location = Locations.Where(l => l.Id == Model.Location.Id).SingleOrDefault();
                            }

                            UpdateViewState(Edit.Mode.Editing);
                        }
                        else
                        {
                            Model = new Person();
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }





    }
}
