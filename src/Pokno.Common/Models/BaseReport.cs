using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;

namespace Pokno.Common.Models
{
    public abstract class BaseReport : IDisposable
    {
        public ReportViewer _report;
        protected readonly IBusinessFacade _businessFacade;

        public BaseReport(IBusinessFacade businessFacade)
        {
            _report = new ReportViewer();
            _businessFacade = businessFacade;
        }
               
        public ReportViewer Viewer { set; get; }
        protected string ReportName { get; set; }
        public string ReportEmbeddedResource { get; set; }
        
        public abstract ReportViewer GenerateHelper();
        public abstract void GetData();

        public virtual void SetViewerProperties()
        {
            try
            {
                if (_report != null)
                {
                    _report.BorderStyle = BorderStyle.None;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void SetProperties()
        {
            try
            {
                if (_report != null)
                {
                    _report.Reset();
                    _report.LocalReport.DisplayName = ReportName;
                    _report.LocalReport.ReportEmbeddedResource = ReportEmbeddedResource;
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        public virtual void NoResultFoundHelper()
        {
            try
            {
                if (_report != null)
                {
                    _report.ProcessingMode = ProcessingMode.Local;
                    _report.LocalReport.DataSources.Clear();
                    _report.LocalReport.Refresh();
                    _report.RefreshReport();
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        //public virtual string NoResultFound()
        //{
        //    try
        //    {
        //        return "No data found!";


        //        //string errorMessage = KeyPropertiesNotSet();
        //        //if (!string.IsNullOrWhiteSpace(errorMessage))
        //        //{
        //        //    NoResultFoundHelper();
        //        //}

        //        //return errorMessage;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public virtual string KeyPropertiesNotSet()
        {
            try
            {
                string errorMessage = null;
                if (string.IsNullOrWhiteSpace(ReportName))
                {
                    errorMessage = ReportName + " Report Name not set!";
                }
                else if (string.IsNullOrWhiteSpace(ReportEmbeddedResource))
                {
                    errorMessage = ReportName + " Report Embedded Resource not set!";
                }

                return errorMessage;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_report != null)
                {
                    _report.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //~BaseReport()
        //{
        //    Viewer.Dispose();
        //}





        
    }


}
