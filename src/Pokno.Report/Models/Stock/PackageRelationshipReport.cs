using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Microsoft.Reporting.WinForms;
using Pokno.Model.Model;
using Pokno.Common.Models;

namespace Pokno.Report.Models.Stock
{
    public class PackageRelationshipReport : BaseReport
    {
        private List<StorePackage> _packageQuntities;
        
        public PackageRelationshipReport(IBusinessFacade businessFacade) : base(businessFacade)
        {
            ReportName = "List of Product Packages";
            ReportEmbeddedResource = "Pokno.Common.Reports.Stock.PackageQuantity.rdlc";
            _packageQuntities = new List<StorePackage>();
            
        }

        public override void GetData()
        {
            try
            {
                _packageQuntities = _businessFacade.GetAllStorePackage();
                if (_packageQuntities == null || _packageQuntities.Count <= 0)
                {
                    throw new Exception("No package relationship found!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override ReportViewer GenerateHelper()
        {
            try
            {
                string dsPackageQuantity = "PackageQuantity";

                if (_packageQuntities != null)
                {
                    _report.ProcessingMode = ProcessingMode.Local;
                    _report.LocalReport.DataSources.Add(new ReportDataSource(dsPackageQuantity.Trim(), _packageQuntities));
                    _report.LocalReport.Refresh();
                    _report.RefreshReport();
                }

                return _report;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //protected override string ValidateReportData()
        //{
        //    try
        //    {
        //        string errorMessage = null;
        //        if (_packageQuntities == null || _packageQuntities.Count <= 0)
        //        {
        //            errorMessage = "Package Quantity not found in the system!";
        //        }

        //        return errorMessage;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

       




    }


}
