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

using Pokno.Infrastructure.Interfaces;
using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure.Models;
using System.ComponentModel;
using Pokno.Infrastructure.Services;
using System.Windows.Data;
using Pokno.Infrastructure.Events;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using Pokno.Model.Model;
using Pokno.Model;
using Prism.Events;
using Pokno.Service;

namespace Pokno.People.ViewModel
{
    public class CompanyRepViewModel : SetupViewModelBase<PersonCompany>
    {
        private Person _person;
        private Company _company;
        private ObservableCollection<Person> _people;
        private ObservableCollection<Company> _companies;
        private readonly IBusinessFacade _businessFacade;
        private BackgroundWorker _worker;

        public CompanyRepViewModel(ISetupService<PersonCompany> service, IBusinessFacade businessFacade, IEventAggregator eventAggregator)
            : base(service)
        {
            _businessFacade = businessFacade;
            _modelName = "Company Representative";

            base._addSelector = pc => pc.Company.Id == Model.Company.Id && pc.Person.Id == Model.Person.Id;
            base._modifySelector = pc => pc.Company.Id == Model.Company.Id && pc.Person.Id == Model.Person.Id && pc.Id != Model.Id;

            eventAggregator.GetEvent<CompanySetupEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);
        }

        private bool IsView(UI.PeopleCompany ui)
        {
            return ui == UI.PeopleCompany.CompanyRepresentative;
        }
               
        public string TabCaption
        {
            get { return _modelName; }
        }
        public ObservableCollection<Company> Companies
        {
            get { return _companies; }
            set
            {
                _companies = value;
                base.OnPropertyChanged("Companies");
            }
        }
        public Company Company
        {
            get { return _company; }
            set
            {
                _company = value;
                base.OnPropertyChanged("Company");
            }
        }
        public ObservableCollection<Person> People
        {
            get { return _people; }
            set
            {
                _people = value;
                base.OnPropertyChanged("People");
            }
        }
        public Person Person
        {
            get { return _person; }
            set
            {
                _person = value;
                base.OnPropertyChanged("Person");
            }
        }

        public void OnInitialise(UI.PeopleCompany ui)
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnInitialiseCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        //_businessFacade = new BusinessFacade(new Pokno.Data.Repository(Utility.DbPath));
                        List<Person> people = _businessFacade.GetAllCustomerAndSupplier();
                        List<Company> companies = _businessFacade.GetAllCompany();
                        List<PersonCompany> personCompanies = _service.LoadAll();

                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
                        dictionary["coy_personCompanies"] = personCompanies;
                        dictionary["coy_companies"] = companies;
                        dictionary["coy_people"] = people;

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
                    string st = e.Error.StackTrace;
                    int lenth = st.Length/2;

                    string st1 = st.Substring(0,lenth);
                    string st2 = st.Substring(lenth, st.Length - lenth);

                    Utility.DisplayMessage(e.Error.Message + "\n\n" + st1 );
                    Utility.DisplayMessage(e.Error.Message + "\n\n" + st2);

                    Utility.DisplayMessage(e.Error.Source);

                    System.Collections.IDictionary obj = e.Error.Data;

                    return;
                }

                List<Person> people = null;
                List<Company> companies = null;
                List<PersonCompany> personCompanies = null;
                if (e.Result != null)
                {
                    Dictionary<string, object> dictionary = e.Result as Dictionary<string, object>;
                    personCompanies = (List<PersonCompany>)dictionary["coy_personCompanies"];
                    companies = (List<Company>)dictionary["coy_companies"];
                    people = (List<Person>)dictionary["coy_people"];
                }

                PopulateEverybody(people);
                PopulateCompany(companies);
                PopulatePeopleCompany(personCompanies);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void PopulateEverybody(List<Person> people)
        {
            try
            {
                if (people == null)
                {
                    people = new List<Person>();
                }

                if (people.Count > 0)
                {
                    people.Insert(0, new Person() { FullName = "<< Select Person >>" });
                }

                People = new ObservableCollection<Person>(people);
                Person = People.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void PopulateCompany(List<Company> companies)
        {
            try
            {
                if (companies == null)
                {
                    companies = new List<Company>();
                }

                if (companies.Count > 0)
                {
                    companies.Insert(0, new Company() { Name = "<< Select Company >>" });
                }

                Companies = new ObservableCollection<Company>(companies);
                Company = Companies.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void PopulatePeopleCompany(List<PersonCompany> personCompanies)
        {
            try
            {
                if (personCompanies == null)
                {
                    personCompanies = new List<PersonCompany>();
                }

                Models = new ListCollectionView(personCompanies);
                RecordCount = RecordCountLabel + personCompanies.Count;
                LoadAllHelper();


                //if (personCompanies.Count > 0)
                //{
                //    RecordCount = RecordCountLabel + personCompanies.Count;

                //    LoadAllHelper();
                //}
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
                if (Models == null || Models.Count <= 0)
                {
                    return;
                }

                Models.MoveCurrentTo(null);
                Models.CurrentChanged += (s, e) =>
                {
                    if (Models.CurrentItem != null)
                    {
                        Model = Models.CurrentItem as PersonCompany;
                        if (Companies != null && Model.Company != null && Model.Company.Id > 0)
                        {
                            Company = Companies.Where(p => p.Id == Model.Company.Id).SingleOrDefault();
                        }

                        if (People != null && Model.Person != null && Model.Person.Id > 0)
                        {
                            Person = People.Where(p => p.Id == Model.Person.Id).SingleOrDefault();
                        }

                        UpdateViewState(Edit.Mode.Editing);
                    }
                    else
                    {
                        Model = new PersonCompany();
                    }
                };
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
                
        protected override void OnSaveCommand()
        {
            try
            {
                Model.Person = Person;
                Model.Company = Company;
                
                if (InvalidEntry())
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

        protected override List<PersonCompany> RemoveSpacesFromModelNamePropertyValue(List<PersonCompany> models)
        {
            try
            {
                return models;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool InvalidEntry()
        {
            try
            {
                IEnumerable<PersonCompany> personCompanies = (IEnumerable<PersonCompany>)Models.SourceCollection;

                if (Company == null || Company.Id <= 0)
                {
                    Utility.DisplayMessage("Please select company!");
                    return true;
                }
                else if (Person == null || Person.Id <= 0)
                {
                    Utility.DisplayMessage("Please select person!");
                    return true;
                }
                
                if (base.InvalidEntry(Model.Company.Name + " represented by " + Model.Person.Name))
                {
                    return true;
                }
                else if (personCompanies != null && personCompanies.Count() > 0)
                {
                    List<PersonCompany> personCompany = personCompanies.Where(pc => pc.Person.Id == Person.Id).ToList();
                    if (personCompany != null && personCompany.Count > 0)
                    {
                        Utility.DisplayMessage("Person cannot represent more than one company! '" + Person.Name + "' is already representing '" + personCompany[0].Company.Name + "'! Operation has been aborted. Please modify appropriately to continue.");
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
                if (People != null && People.Count > 0)
                {
                    Person = People.FirstOrDefault();
                }
                if (Companies != null && Companies.Count > 0)
                {
                    Company = Companies.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }



       
    }


}
