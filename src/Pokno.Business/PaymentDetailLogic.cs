using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Pokno.Model;
using Pokno.Entity;
using System.Transactions;
using System.Linq.Expressions;
using Pokno.Business.Interfaces;
using System.Data.Entity.Core;

namespace Pokno.Business
{
    public class PaymentDetailLogic : BusinessLogicBase<PaymentDetail, PAYMENT_DETAIL>
    {
        private ChequeLogic checkLogic;

        public PaymentDetailLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            checkLogic = new ChequeLogic(repository);
            base.translator = new PaymentDetailTranslator();
        }

        public override int Add(List<PaymentDetail> paymentDetails)
        {
            try
            {
                int changeCount = 0;

                checkLogic.repository = repository;
                foreach (PaymentDetail paymentDetail in paymentDetails)
                {
                    PaymentDetail newPaymentDetail = Add(paymentDetail);
                    if (paymentDetail.Cheque != null)
                    {
                        paymentDetail.Cheque.Id = newPaymentDetail.Id;
                        checkLogic.Add(paymentDetail.Cheque);
                    }

                    changeCount++;
                }

                return changeCount;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public override int Add(List<PaymentDetail> paymentDetails)
        //{
        //    try
        //    {
        //        int changeCount = 0;

        //        using (TransactionScope transaction = new TransactionScope())
        //        {
        //            foreach (PaymentDetail paymentDetail in paymentDetails)
        //            {
        //                PaymentDetail newPaymentDetail = Add(paymentDetail);
        //                if (paymentDetail.Cheque != null)
        //                {
        //                    paymentDetail.Cheque.Id = newPaymentDetail.Id;
        //                    checkLogic.Add(paymentDetail.Cheque);
        //                }

        //                changeCount++;
        //            }

        //            transaction.Complete();
        //        }

        //        return changeCount;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<PaymentDetail> GetByPaymentId(long id)
        {
            try
            {
                Expression<Func<PAYMENT_DETAIL, bool>> selector = payDetail => payDetail.Payment_Id == id;
                Func<IQueryable<PAYMENT_DETAIL>, IOrderedQueryable<PAYMENT_DETAIL>> orderBy = p => p.OrderBy(pd => pd.Payment_Detail_Id);

                return GetModelsBy(selector, orderBy);

                //return GetModelsBy(selector).OrderBy(p => p.Id).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(List<PaymentDetail> paymentDetails)
        {
            try
            {
                bool suceeded = false;
                if (paymentDetails != null && paymentDetails.Count > 0)
                {
                    checkLogic.repository = repository;
                    checkLogic.Remove(paymentDetails);
                    repository.Save();

                    foreach (PaymentDetail paymentDetail in paymentDetails)
                    {
                        Expression<Func<PAYMENT_DETAIL, bool>> selector = payDetail => payDetail.Payment_Detail_Id == paymentDetail.Id;
                        suceeded = base.Remove(selector);
                    }

                    repository.Save();
                    return true;
                }

                return suceeded;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(List<PaymentDetail> paymentDetails)
        {
            try
            {
                if (paymentDetails == null || paymentDetails.Count <= 0)
                {
                    throw new Exception("No Pament Details found to update! Please update payment information and try again.");
                }

                bool updated = false;
                base.OpenDatabaseConnectionIfClosed();
                using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    updated = Modify(paymentDetails);
                    if (updated)
                    {
                        base.CommitTransaction(transaction);

                        //transaction.Commit();
                        //repository.DbContext.Database.Connection.Close();
                    }
                }

                return updated;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool Modify(List<PaymentDetail> oldPaymentDetails, List<PaymentDetail> newPaymentDetails)
        {
            try
            {
                for (int i = 0; i < oldPaymentDetails.Count; i++)
                {
                    oldPaymentDetails[i].PaymentType = newPaymentDetails[i].PaymentType;
                    oldPaymentDetails[i].PaymentDate = newPaymentDetails[i].PaymentDate;
                    oldPaymentDetails[i].AmountPaid = newPaymentDetails[i].AmountPaid;

                    if (!Modify(oldPaymentDetails[i]))
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Modify(List<PaymentDetail> newPaymentDetails)
        {
            try
            {
                int rowsAdded = -1;
                bool modified = false;

                if (newPaymentDetails != null && newPaymentDetails.Count > 0)
                {
                    int difference = 0;
                    List<PaymentDetail> oldPaymentDetails = GetByPaymentId(newPaymentDetails[0].Payment.Id);

                    int oldRecordCount = oldPaymentDetails.Count;
                    int newRecordCount = newPaymentDetails.Count;
                    if (oldRecordCount == newRecordCount)
                    {
                        modified = Modify(oldPaymentDetails, newPaymentDetails);
                        repository.Save();
                    }
                    else if (oldRecordCount > newRecordCount)
                    {
                        difference = oldRecordCount - newRecordCount;
                        List<PaymentDetail> paymentDetailsToDiscard = oldPaymentDetails.Skip(newRecordCount).Take(difference).ToList();
                        List<PaymentDetail> oldPaymentDetailsToModify = oldPaymentDetails.Take(newRecordCount).ToList();

                        if (Modify(oldPaymentDetailsToModify, newPaymentDetails))
                        {
                            repository.Save();
                            modified = Remove(paymentDetailsToDiscard);
                        }
                    }
                    else if (oldRecordCount < newRecordCount)
                    {
                        difference = newRecordCount - oldRecordCount;
                        List<PaymentDetail> paymentDetailsToAdd = newPaymentDetails.Skip(oldRecordCount).Take(difference).ToList();

                        if (Modify(oldPaymentDetails, newPaymentDetails))
                        {
                            repository.Save();
                            
                            rowsAdded = Add(paymentDetailsToAdd);
                            modified = rowsAdded > -1 ? true : false;
                        }
                    }
                }

                return modified;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Modify(PaymentDetail paymentDetail)
        {
            try
            {
                int rowsAffected = 0;
                Expression<Func<PAYMENT_DETAIL, bool>> predicate = pd => pd.Payment_Detail_Id == paymentDetail.Id;
                PAYMENT_DETAIL paymentDetailEntity = GetEntityBy(predicate);

                paymentDetailEntity.Payment_Id = paymentDetail.Payment.Id;
                paymentDetailEntity.Payment_Type_Id = paymentDetail.PaymentType.Id;
                paymentDetailEntity.Amount_Paid = paymentDetail.AmountPaid;
                paymentDetailEntity.Payment_Date = paymentDetail.PaymentDate;
                rowsAffected = repository.Save();

                if (paymentDetail.Cheque != null)
                {
                    checkLogic.repository = repository;
                    checkLogic.Modify(paymentDetail.Cheque);
                }

                return true;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(ArgumentNullException);
            }
            catch (UpdateException)
            {
                throw new UpdateException(UpdateException);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PaymentDetail> GetPaymenDetailsByPaymentId(long paymentId)
        {
            try
            {
                Expression<Func<PAYMENT_DETAIL, bool>> selector = P => (P.Payment_Id == paymentId);
                List<PaymentDetail> paymentDetails = base.GetModelsBy(selector);

                return paymentDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }



        
    }
}
