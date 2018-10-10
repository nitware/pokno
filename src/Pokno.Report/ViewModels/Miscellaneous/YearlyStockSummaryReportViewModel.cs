using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.Windows;
using System.ComponentModel;
using System.Windows.Data;
using Prism.Commands;
using Prism.Events;
using Pokno.Infrastructure.Models;
using Pokno.Common.Interfaces;
using Pokno.Service;
using Pokno.Model.Model;
using Pokno.Infrastructure.ViewModel;
using Pokno.Common.Models;
using Pokno.Report.Models.Miscellaneous;

namespace Pokno.Report.ViewModels.Miscellaneous
{
    public class YearlyStockSummaryReportViewModel : BaseReportByYearViewModel
    {
        public YearlyStockSummaryReportViewModel(IBusinessFacade service, IBaseReportFactory reportFactory) : base(service, reportFactory)
        {
            UpdateDisplayButtonState();
        }

        protected override void OnDisplayCommand()
        {
            try
            {
                ReportEngine.ReportLoadCompleted += ReportEngine_ReportLoadCompleted;
                base.OnInitialise(ReportType.YearlyStockSummary);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected override void OnInitialiseHelper(ReportType reportType)
        {
            try
            {
                BaseReport report = _reportFactory.Create(reportType);
                YearlyStockSummaryReport yearlyStockBreakDownReport = report as YearlyStockSummaryReport;

                yearlyStockBreakDownReport.Year = Year.Id;
                ReportEngine reportEngine = new ReportEngine(yearlyStockBreakDownReport);
                reportEngine.Generate();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override sealed void UpdateDisplayButtonState()
        {
            try
            {
                base.UpdateDisplayButtonState();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }




    }




}
