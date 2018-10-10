using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Common.Models;
using Pokno.Model.Model;
using Pokno.Service;
using Microsoft.Reporting.WinForms;

namespace Pokno.Report.Models.Miscellaneous
{
    public abstract class BaseStockStatisticsReport : BaseReport
    {
        protected List<StoreSalesFrequency> _topSellingStocks;
        protected List<StoreSalesFrequency> _leastSellingStocks;
        protected List<StoreSalesFrequency> _topProfitableStocks;
        protected List<StoreSalesFrequency> _leastProfitableStocks;
        protected List<StoreReturnStock> _topReturnedStocks;

        public BaseStockStatisticsReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {
            _topSellingStocks = new List<StoreSalesFrequency>();
            _leastSellingStocks = new List<StoreSalesFrequency>();
            _topProfitableStocks = new List<StoreSalesFrequency>();
            _leastProfitableStocks = new List<StoreSalesFrequency>();
            _topReturnedStocks = new List<StoreReturnStock>();
        }

        public virtual string Title { get; set; }

        protected void UpdateStatistics()
        {
            try
            {
                if (_leastSellingStocks == null || _leastSellingStocks.Count <= 0 || _topSellingStocks == null || _topSellingStocks.Count <= 0)
                {
                    List<StoreSalesFrequency> leastSalesStock = new List<StoreSalesFrequency>();
                    for (int i = 0; i < _leastSellingStocks.Count; i++)
                    {
                        StoreSalesFrequency leastSale = _leastSellingStocks[i];
                        List<StoreSalesFrequency> sales = _topSellingStocks.Where(s => s.Frequency == leastSale.Frequency).ToList();
                        if (sales == null || sales.Count <= 0)
                        {
                            leastSalesStock.Add(leastSale);
                        }
                    }

                    if (leastSalesStock.Count > 0)
                    {
                        _leastSellingStocks = leastSalesStock;
                    }
                }

                if (_leastProfitableStocks == null || _leastProfitableStocks.Count <= 0 || _topProfitableStocks == null || _topProfitableStocks.Count <= 0)
                {
                    List<StoreSalesFrequency> leastProfitableStocks = new List<StoreSalesFrequency>();
                    for (int i = 0; i < _leastProfitableStocks.Count; i++)
                    {
                        StoreSalesFrequency leastProfitableStock = _leastProfitableStocks[i];
                        List<StoreSalesFrequency> profitableStocks = _topProfitableStocks.Where(s => s.Profit == leastProfitableStock.Profit).ToList();
                        if (profitableStocks == null || profitableStocks.Count <= 0)
                        {
                            leastProfitableStocks.Add(leastProfitableStock);
                        }
                    }

                    if (leastProfitableStocks.Count > 0)
                    {
                        _leastProfitableStocks = leastProfitableStocks;
                    }
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
               
        private void SetParameter()
        {
            try
            {
                ReportParameter titleParam = new ReportParameter("Title", Title);
                ReportParameter[] reportParams = new ReportParameter[] { titleParam };
                _report.LocalReport.SetParameters(reportParams);
            }
            catch(Exception)
            {
                throw;
            }
        }
        public override void SetProperties()
        {
            try
            {
                ReportEmbeddedResource = "Pokno.Common.Reports.Statistics.Stock.rdlc";
                base.SetProperties();
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
                SetParameter();

                string dsTopSellingStocks = "dsTopSellingStocks";
                string dsLeastSellingStocks = "dsLeastSellingStocks";
                string dsTopProfitableStocks = "dsTopProfitableStocks";
                string dsLeastProfitableStocks = "dsLeastProfitableStocks";
                string dsTopReturnedStocks = "dsTopReturnedStocks";

                if (_topSellingStocks == null || _topSellingStocks.Count <= 0)
                {
                    _topSellingStocks = new List<StoreSalesFrequency>();
                }
                if (_leastSellingStocks == null || _leastSellingStocks.Count <= 0)
                {
                    _leastSellingStocks = new List<StoreSalesFrequency>();
                }
                if (_topProfitableStocks == null || _topProfitableStocks.Count <= 0)
                {
                    _topProfitableStocks = new List<StoreSalesFrequency>();
                }
                if (_leastProfitableStocks == null || _leastProfitableStocks.Count <= 0)
                {
                    _leastProfitableStocks = new List<StoreSalesFrequency>();
                }
                if (_topReturnedStocks == null || _topReturnedStocks.Count <= 0)
                {
                    _topReturnedStocks = new List<StoreReturnStock>();
                }

                _report.ProcessingMode = ProcessingMode.Local;
                _report.LocalReport.DataSources.Add(new ReportDataSource(dsTopSellingStocks.Trim(), _topSellingStocks));
                _report.LocalReport.DataSources.Add(new ReportDataSource(dsLeastSellingStocks.Trim(), _leastSellingStocks));
                _report.LocalReport.DataSources.Add(new ReportDataSource(dsTopProfitableStocks.Trim(), _topProfitableStocks));
                _report.LocalReport.DataSources.Add(new ReportDataSource(dsLeastProfitableStocks.Trim(), _leastProfitableStocks));
                _report.LocalReport.DataSources.Add(new ReportDataSource(dsTopReturnedStocks.Trim(), _topReturnedStocks));
                
                _report.LocalReport.Refresh();
                _report.RefreshReport();
                
                return _report;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public override string KeyPropertiesNotSet()
        //{
        //    try
        //    {
        //        string errorMessage = base.KeyPropertiesNotSet();

        //        if (string.IsNullOrWhiteSpace(errorMessage))
        //        {
        //            if (FromDate == null || DateTime.MinValue == FromDate)
        //            {
        //                errorMessage = "Please select From Date!";
        //            }
        //            else if (ToDate == null || DateTime.MinValue == ToDate)
        //            {
        //                errorMessage = "Please select To Date!";
        //            }
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
