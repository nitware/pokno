using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Model;
using System.Collections.ObjectModel;
using Pokno.Common.Interfaces;
using Prism.Commands;
using System.ComponentModel;
using Pokno.Service;
using Pokno.Infrastructure.Models;
using System.Windows.Threading;
using System.Windows;
using Pokno.Common.Models;
using Pokno.Report.Models.Payment;

namespace Pokno.Report.ViewModels.Payment
{
    public class PaymentHistoryByPersonReportViewModel : BaseReportViewModel
    {
        private Dispatcher _dispatcher;

         private bool _isEnabled;
        private Person _person;
        private ObservableCollection<Person> _people;
        private IBusinessFacade _businessFacade;
        private BackgroundWorker _worker;

        public PaymentHistoryByPersonReportViewModel(IBusinessFacade businessFacade, IBaseReportFactory reportFactory)
            : base(reportFactory)
        {
            _businessFacade = businessFacade;
            _dispatcher = Application.Current.Dispatcher;
            DisplayCommand = new DelegateCommand(OnDisplayCommand, CanDisplay);
            
            UpdateDisplayButtonState();
            LoadCustomerAndSupplier();
        }

        public DelegateCommand DisplayCommand { get; private set; }
               
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                base.OnPropertyChanged("IsEnabled");
                DisplayCommand.RaiseCanExecuteChanged();
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
                UpdateDisplayButtonState();
            }
        }

        private bool CanDisplay()
        {
            return IsEnabled;
        }

        private void LoadCustomerAndSupplier()
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadPeopleCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        e.Result = _businessFacade.GetAllCustomerAndSupplier();
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnLoadPeopleCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                    List<Person> people = e.Result as List<Person>;
                    PopulatePeople(people);
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void PopulatePeople(List<Person> people)
        {
            try
            {
                if (people == null)
                {
                    people = new List<Person>();
                }

                _dispatcher.Invoke(() =>
                {
                    if (people.Count > 0)
                    {
                        people.Insert(0, new Person() { FullName = "<< Select Person >>" });
                    }

                    People = new ObservableCollection<Person>(people);
                    Person = People.FirstOrDefault();
                });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }


        protected void OnDisplayCommand()
        {
            try
            {
                ReportEngine.ReportLoadCompleted += ReportEngine_ReportLoadCompleted;
                base.OnInitialise(ReportType.PaymentHistoryByPerson);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected override void OnInitialiseHelper(ReportType reportType)
        {
            try
            {
                BaseReport report = _reportFactory.Create(reportType);
                PaymentHistoryByPersonReport paymentHistoryReport = report as PaymentHistoryByPersonReport;

                paymentHistoryReport.Person = Person;
                ReportEngine reportEngine = new ReportEngine(paymentHistoryReport);
                reportEngine.Generate();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void UpdateDisplayButtonState()
        {
            try
            {
                if (Person != null && Person.Id > 0 )
                {
                    IsEnabled = true;
                }
                else
                {
                    IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

    }



}
