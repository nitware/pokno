using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Common.Models;
using Pokno.Service;
using Pokno.Model.Model;
using Microsoft.Reporting.WinForms;

namespace Pokno.Report.Models.Miscellaneous
{
    public abstract class BaseCustomerStatisticsReport : BaseReport
    {
        protected List<StoreCustomerStatistics> _topCustomerTransactionsCount;
        protected List<StoreCustomerStatistics> _leastCustomerTransactionsCount;
        protected List<StoreCustomerStatistics> _topProfitableCustomerTransactions;
        protected List<StoreCustomerStatistics> _leastProfitableCustomerTransactions;
        protected List<StoreCustomerStatistics> _topCustomerTransactionsVolume;
        protected List<StoreCustomerStatistics> _leastCustomerTransactionsVolume;

        public BaseCustomerStatisticsReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {
            _topCustomerTransactionsCount = new List<StoreCustomerStatistics>();
            _leastCustomerTransactionsCount = new List<StoreCustomerStatistics>();
            _topProfitableCustomerTransactions = new List<StoreCustomerStatistics>();
            _leastProfitableCustomerTransactions = new List<StoreCustomerStatistics>();
            _topCustomerTransactionsVolume = new List<StoreCustomerStatistics>();
            _leastCustomerTransactionsVolume = new List<StoreCustomerStatistics>();
        }

        public virtual string Title { get; set; }

        protected void UpdateStatistics()
        {
            try
            {
                if (_leastCustomerTransactionsCount == null || _leastCustomerTransactionsCount.Count <= 0 || _topCustomerTransactionsCount == null || _topCustomerTransactionsCount.Count <= 0)
                {
                    List<StoreCustomerStatistics> leastCustomerTransactions = new List<StoreCustomerStatistics>();
                    for (int i = 0; i < _leastCustomerTransactionsCount.Count; i++)
                    {
                        StoreCustomerStatistics leastCustomerTransaction = _leastCustomerTransactionsCount[i];
                        List<StoreCustomerStatistics> sales = _topCustomerTransactionsCount.Where(s => s.Frequency == leastCustomerTransaction.Frequency).ToList();
                        if (sales == null || sales.Count <= 0)
                        {
                            leastCustomerTransactions.Add(leastCustomerTransaction);
                        }
                    }

                    if (leastCustomerTransactions.Count > 0)
                    {
                        _leastCustomerTransactionsCount = leastCustomerTransactions;
                    }
                }

                if (_leastProfitableCustomerTransactions == null || _leastProfitableCustomerTransactions.Count <= 0 || _topProfitableCustomerTransactions == null || _topProfitableCustomerTransactions.Count <= 0)
                {
                    List<StoreCustomerStatistics> leastProfitableleastProfitableCustomerTransactions = new List<StoreCustomerStatistics>();
                    for (int i = 0; i < _leastProfitableCustomerTransactions.Count; i++)
                    {
                        StoreCustomerStatistics leastProfitableCustomerTransaction = _leastProfitableCustomerTransactions[i];
                        List<StoreCustomerStatistics> profitableleastProfitableCustomerTransactions = _topProfitableCustomerTransactions.Where(s => s.Profit == leastProfitableCustomerTransaction.Profit).ToList();
                        if (profitableleastProfitableCustomerTransactions == null || profitableleastProfitableCustomerTransactions.Count <= 0)
                        {
                            leastProfitableleastProfitableCustomerTransactions.Add(leastProfitableCustomerTransaction);
                        }
                    }

                    if (leastProfitableleastProfitableCustomerTransactions.Count > 0)
                    {
                        _leastProfitableCustomerTransactions = leastProfitableleastProfitableCustomerTransactions;
                    }
                }


                if (_leastCustomerTransactionsVolume == null || _leastCustomerTransactionsVolume.Count <= 0 || _topCustomerTransactionsVolume == null || _topCustomerTransactionsVolume.Count <= 0)
                {
                    List<StoreCustomerStatistics> customerTransactionsVolume = new List<StoreCustomerStatistics>();
                    for (int i = 0; i < _leastCustomerTransactionsVolume.Count; i++)
                    {
                        StoreCustomerStatistics leastCustomerTransactionVolume = _leastCustomerTransactionsVolume[i];
                        List<StoreCustomerStatistics> leastCustomerTransactionsVolume = _topCustomerTransactionsVolume.Where(s => s.SellingPrice == leastCustomerTransactionVolume.SellingPrice).ToList();
                        if (leastCustomerTransactionsVolume == null || leastCustomerTransactionsVolume.Count <= 0)
                        {
                            customerTransactionsVolume.Add(leastCustomerTransactionVolume);
                        }
                    }

                    if (customerTransactionsVolume.Count > 0)
                    {
                        _leastCustomerTransactionsVolume = customerTransactionsVolume;
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
                ReportEmbeddedResource = "Pokno.Common.Reports.Statistics.CustomerStatistics.rdlc";
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

                string dsTopCustomerTransactionsFrequency = "dsTopCustomerTransactionsFrequency";
                string dsLeastCustomerTransactionsFrequency = "dsLeastCustomerTransactionsFrequency";
                string dsTopCustomerTransactionsVolume = "dsTopCustomerTransactionsVolume";
                string dsLeastCustomerTransactionsVolume = "dsLeastCustomerTransactionsVolume";
                string dsTopProfitableCustomerTransactions = "dsTopProfitableCustomerTransactions";
                string dsLeastProfitableCustomerTransactions = "dsLeastProfitableCustomerTransactions";

                if (_topCustomerTransactionsCount == null || _topCustomerTransactionsCount.Count <= 0)
                {
                    _topCustomerTransactionsCount = new List<StoreCustomerStatistics>();
                }
                if (_leastCustomerTransactionsCount == null || _leastCustomerTransactionsCount.Count <= 0)
                {
                    _leastCustomerTransactionsCount = new List<StoreCustomerStatistics>();
                }
                if (_topCustomerTransactionsVolume == null || _topCustomerTransactionsVolume.Count <= 0)
                {
                    _topCustomerTransactionsVolume = new List<StoreCustomerStatistics>();
                }
                if (_leastCustomerTransactionsVolume == null || _leastCustomerTransactionsVolume.Count <= 0)
                {
                    _leastCustomerTransactionsVolume = new List<StoreCustomerStatistics>();
                }
                if (_topProfitableCustomerTransactions == null || _topProfitableCustomerTransactions.Count <= 0)
                {
                    _topProfitableCustomerTransactions = new List<StoreCustomerStatistics>();
                }
                if (_leastProfitableCustomerTransactions == null || _leastProfitableCustomerTransactions.Count <= 0)
                {
                    _leastProfitableCustomerTransactions = new List<StoreCustomerStatistics>();
                }

                _report.ProcessingMode = ProcessingMode.Local;
                _report.LocalReport.DataSources.Add(new ReportDataSource(dsTopCustomerTransactionsFrequency.Trim(), _topCustomerTransactionsCount));
                _report.LocalReport.DataSources.Add(new ReportDataSource(dsLeastCustomerTransactionsFrequency.Trim(), _leastCustomerTransactionsCount));
                _report.LocalReport.DataSources.Add(new ReportDataSource(dsTopCustomerTransactionsVolume.Trim(), _topCustomerTransactionsVolume));
                _report.LocalReport.DataSources.Add(new ReportDataSource(dsLeastCustomerTransactionsVolume.Trim(), _leastCustomerTransactionsVolume));
                _report.LocalReport.DataSources.Add(new ReportDataSource(dsTopProfitableCustomerTransactions.Trim(), _topProfitableCustomerTransactions));
                _report.LocalReport.DataSources.Add(new ReportDataSource(dsLeastProfitableCustomerTransactions.Trim(), _leastProfitableCustomerTransactions));
                
                _report.LocalReport.Refresh();
                _report.RefreshReport();
                
                return _report;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }



}
