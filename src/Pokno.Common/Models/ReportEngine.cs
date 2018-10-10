using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Reporting.WinForms;
using System.ComponentModel;
using Pokno.Infrastructure.Models;

namespace Pokno.Common.Models
{
    public class ReportEngine
    {
        private BaseReport _report;
        private ReportViewer _viewer;
        private BackgroundWorker _worker;
        public static ReportViewer _loadedViewer;
        
        public static event EventHandler ReportLoadCompleted;

        public ReportEngine(BaseReport report)
        {
            _report = report;
        }
                
        public void Generate()
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadDataHelperCompleted);
                    _worker.DoWork += (s, e) => _report.GetData();
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void OnLoadDataHelperCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    throw new Exception(e.Error.Message);
                }

                _report.SetViewerProperties();
                _report.SetProperties();

                string errorMessage = _report.KeyPropertiesNotSet();
                if (!string.IsNullOrWhiteSpace(errorMessage))
                {
                    throw new Exception(errorMessage);
                }

                _viewer = _report.GenerateHelper();
                _loadedViewer = _viewer;

                if (ReportLoadCompleted != null)
                {
                    ReportLoadCompleted(this, e);
                }
            }
            catch (Exception ex)
            {
                if (ReportLoadCompleted != null)
                {
                    ReportLoadCompleted(ex, e);
                }
            }
        }

        



    }



}
