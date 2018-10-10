using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Transactions;

using Pokno.Model;
using Pokno.Entity;
using Pokno.Model.Model;
using System.Linq.Expressions;
using Pokno.Business.Helper;
using Pokno.Model.Views;
using Pokno.Business.Interfaces;
using System.Data.Entity.Core;

namespace Pokno.Business
{
    public class PaymentLogic : BusinessLogicBase<Payment, PAYMENT>
    {
        private PaymentDetailLogic paymentDetailLogic;

        public PaymentLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new PaymentTranslator();
            paymentDetailLogic = new PaymentDetailLogic(repository);
        }

        public List<PaymentHistory> GetHistory()
        {
            List<PaymentHistory> paymentHistories = null;

            try
            {
                string query = "SELECT * FROM VW_STOCK_PURCHASE_PAYMENT_OVERALL";
                paymentHistories = GetHistoryHelper(query);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return paymentHistories;
        }
        public List<PaymentHistory> GetHistoryBy(Person person)
        {
            List<PaymentHistory> paymentHistories = null;

            try
            {
                string query = "SELECT * FROM VW_STOCK_PURCHASE_PAYMENT_OVERALL where Person_Id = " + person.Id;
                paymentHistories = GetHistoryHelper(query);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return paymentHistories;
        }
        public List<PaymentHistory> GetHistoryBy(PersonType personType)
        {
            List<PaymentHistory> paymentHistories = null;

            try
            {
                string query = "SELECT * FROM VW_STOCK_PURCHASE_PAYMENT_OVERALL WHERE Person_Type_Id = " + personType.Id;
                paymentHistories = GetHistoryHelper(query);
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return paymentHistories;
        }
        private List<PaymentHistory> GetHistoryHelper(string query)
        {
            List<PaymentHistory> payments = null;

            try
            {
                payments = (from ph in repository.DbContext.Database.SqlQuery<VW_STOCK_PURCHASE_PAYMENT_OVERALL>(query)
                            select new PaymentHistory
                            {
                                PersonId = (long)ph.Person_Id,
                                Name = ph.Name,
                                InvoiceNumber = ph.Invoice_Number,
                                TransactionDate = ph.Transaction_Date,
                                TotalAmountPayable = (decimal)ph.Total_Amount_Payable.Value,
                                AmountPayable = (decimal)ph.Amount_Payable,
                                AmountPaid = (decimal)ph.Amount_Paid,
                                Balance = (decimal)ph.Balance,
                                TotalAmountPaid = (decimal)ph.Total_Amount_Paid,
                                TotalBalance = (decimal)ph.Total_Balance,
                                PaymentDate = ph.Payment_Date,
                                PaymentTypeId = (int)ph.Payment_Type_Id,
                                PaymentId = ph.Payment_Id,
                                PaymentName = ph.Payment_Name,
                                PaymentDetailId = ph.Payment_Detail_Id,
                            }).ToList();
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return payments;
        }
        
        public List<Payment> GetAllTransaction(Person person)
        {
            List<Payment> payments = null;

            try
            {
                string query = "SELECT * FROM VW_PAYMENT_TRANSACTION where Person_Id = " + person.Id;
                List<VW_PAYMENT_TRANSACTION> paymentTransactions = repository.DbContext.Database.SqlQuery<VW_PAYMENT_TRANSACTION>(query).ToList();
                
                payments = new List<Payment>();
                if (paymentTransactions != null && paymentTransactions.Count > 0)
                {
                    foreach (VW_PAYMENT_TRANSACTION paymentTransaction in paymentTransactions)
                    {
                        Payment payment = new Payment();
                        payment.Id = paymentTransaction.Payment_Id;
                        payment.AmountPayable = Math.Round((decimal)paymentTransaction.Amount_Payable, 2);
                        payment.AmountPaid = Math.Round((decimal)paymentTransaction.Amount_Paid, 2);
                        payment.Balance = Math.Round((decimal)paymentTransaction.Balance, 2);
                        payment.TransactionDate = paymentTransaction.Transaction_Date;
                        payment.Details = paymentDetailLogic.GetByPaymentId(payment.Id);

                        payments.Add(payment);
                    }
                }
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return payments;
        }

        public override Payment Add(Payment payment)
        {
            try
            {
                payment.SerialNumber = 0;
                Payment newPayment = base.Add(payment);
                if (newPayment == null || newPayment.Id <= 0)
                {
                    throw new Exception("Add Payment operation failed! " + TryAgain);
                }
                                
                payment.Id = newPayment.Id;
                payment = SetInvoiceNumber(payment);
                                               
                SetPaymentToPaymentDetails(payment);

                paymentDetailLogic.repository = repository;
                paymentDetailLogic.Add(payment.Details);

                return payment;
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

        private Payment SetInvoiceNumber(Payment payment)
        {
            const int MAX_RETRY = 10;

            for (int i = 1; i <= MAX_RETRY; i++)
            {
                try
                {
                    payment = GenerateNextInvoiceNumber(payment);
                    SetInvoiceNumberHelper(payment);
                    break;
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                    {
                        if (i == MAX_RETRY)
                        {
                            throw new Exception("Violation of UNIQUE KEY constraint. Cannot insert duplicate key in object. The statement has been terminated. Please try again.");
                        }
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return payment;
        }

        private Payment GenerateNextInvoiceNumber(Payment payment)
        {
            try
            {
                long maximumSerialNo = base.GetMaxValueBy(p => (long)p.Serial_Number);
                if (maximumSerialNo > 0)
                {
                    maximumSerialNo = ++maximumSerialNo;
                }
                else
                {
                    maximumSerialNo = 1;
                }

                payment.SerialNumber = maximumSerialNo;
                payment.InvoiceNumber = "SP" + payment.DatePaid.ToString("yy") + BusinessLogicUtility.PaddNumber(maximumSerialNo, 14);

                return payment;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool SetInvoiceNumberHelper(Payment payment)
        {
            try
            {
                Expression<Func<PAYMENT, bool>> selector = p => p.Payment_Id == payment.Id;
                PAYMENT entity = base.GetEntityBy(selector);
                if (entity == null)
                {
                    throw new Exception("NoItemFound");
                }

                entity.Serial_Number = payment.SerialNumber;
                entity.Invoice_Number = payment.InvoiceNumber;

                return base.Save() > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(Payment payment)
        {
            try
            {
                if (payment.Details == null || payment.Details.Count <= 0)
                {
                    Expression<Func<PAYMENT_DETAIL, bool>> predicate = pd => pd.Payment_Id == payment.Id;
                    payment.Details = paymentDetailLogic.GetModelsBy(predicate);
                }

                paymentDetailLogic.repository = repository;
                paymentDetailLogic.Remove(payment.Details);
                Expression<Func<PAYMENT, bool>> selector = P => P.Payment_Id == payment.Id;
                bool suceeded = base.Remove(selector);

                //repository.Save();
                return suceeded;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Payment GetById(long id)
        {
            try
            {
                Expression<Func<PAYMENT, bool>> selector = p => p.Payment_Id == id;
                return GetModelBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Modify(Payment payment)
        {
            try
            {
                Expression<Func<PAYMENT, bool>> predicate = pay => pay.Payment_Id == payment.Id;
                PAYMENT paymentEntity = GetEntityBy(predicate);

                bool modified = false;
                paymentEntity.Amount_Payable = payment.AmountPayable;               
                if (payment.Details != null && payment.Details.Count > 0)
                {
                    foreach (PaymentDetail paymentDetail in payment.Details)
                    {
                        paymentDetail.Payment = payment;
                    }

                    paymentDetailLogic.repository = repository;
                    modified = paymentDetailLogic.Modify(payment.Details);
                }

                return modified;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(ArgumentNullException);
            }
            catch (ConstraintException)
            {
                throw new ConstraintException("");
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

        public Payment LoadBatchPaymentWithPaymentDetails(Payment payment)
        {
            try
            {
                payment = GetById(payment.Id);
                payment.Details = paymentDetailLogic.GetPaymenDetailsByPaymentId(payment.Id);
                return payment;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SetPaymentToPaymentDetails(Payment payment)
        {
            try
            {
                foreach (PaymentDetail paymentDetail in payment.Details)
                {
                    paymentDetail.Payment = payment;
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        public List<PaymentStatus> GetDailyTransaction(DateTime date)
        {
            List<PaymentStatus> dailyPayments = null;

            try
            {
                DateTime endDate = Range.Get(DateRange.End, date);
                DateTime startDate = Range.Get(DateRange.Start, date);

                string query = "SELECT * FROM VW_PAYMENT where Payment_Date >= '" + startDate.ToString(BusinessLogicUtility.DateTimeFormat) + "' AND Payment_Date <= '" + endDate.ToString(BusinessLogicUtility.DateTimeFormat) + "' ORDER BY Payment_Id";
                dailyPayments = (from p in base.repository.DbContext.Database.SqlQuery<VW_PAYMENT>(query)
                                 select new PaymentStatus
                                 {
                                     PaymentId = p.Payment_Id,
                                     InvoiceNumber = p.Invoice_Number,
                                     InitiatorName = p.Initiator_Name,
                                     RecipientName = p.Recipient_Name,
                                     InitiatorPersonType = p.Transaction_Type_Name,
                                     AmountPayable = p.Amount_Payable.HasValue ? p.Amount_Payable.Value : (decimal)0,
                                     AmountPaid = p.Amount_Paid.HasValue ? p.Amount_Paid.Value : (decimal)0,
                                     Balance = p.Balance,
                                     TransactionDate = p.Payment_Date,
                                     TransactionType = p.Transaction_Type_Name,
                                 }).ToList();
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return dailyPayments;
        }
        
        public List<PaymentStatus> GetTradeStatus(Trade trade)
        {
            List<PaymentStatus> status = null;

            try
            {
                switch (trade)
                {
                    case Trade.Creditor:
                        {
                            string query = "SELECT * FROM VW_CREDITOR_AND_DEBTOR where Balance < 0";
                            status = (from cd in base.repository.DbContext.Database.SqlQuery<VW_CREDITOR_AND_DEBTOR>(query)
                                      select new PaymentStatus
                                      {
                                          PaymentId = cd.Payment_Id,
                                          TransactionDate = cd.Transaction_Date,
                                          Status = cd.Status,
                                          AmountPayable = cd.Amount_Payable.HasValue ? cd.Amount_Payable.Value : (decimal)0,
                                          AmountPaid = cd.Amount_Paid.HasValue ? cd.Amount_Paid.Value : (decimal)0,
                                          Balance = cd.Balance.HasValue ? cd.Balance.Value : (decimal)0,

                                          InitiatorPersonType = cd.Initiator_Person_Type_Name,
                                          InitiatorName = cd.Initiator_Name,
                                          InitiatorContactAddress = cd.Initiator_Contact_Address,
                                          InitiatorEmail = cd.Initiator_Email,
                                          InitiatorMobilePhone = cd.Initiator_Mobile_Phone,

                                          RecipientPersonType = cd.Recipient_Person_Type_Name,
                                          RecipientName = cd.Recipient_Name,
                                          RecipientContactAddress = cd.Recipient_Contact_Address,
                                          RecipientEmail = cd.Recipient_Email,
                                          RecipientMobilePhone = cd.Recipient_Mobile_Phone,
                                          InvoiceNumber = cd.Invoice_Number
                                      }).ToList();
                            break;
                        }
                    case Trade.Debtor:
                        {
                            string query = "SELECT * FROM VW_CREDITOR_AND_DEBTOR where Balance > 0";
                            status = (from cd in base.repository.DbContext.Database.SqlQuery<VW_CREDITOR_AND_DEBTOR>(query)
                                      select new PaymentStatus
                                      {
                                          PaymentId = cd.Payment_Id,
                                          TransactionDate = cd.Transaction_Date,
                                          Status = cd.Status,
                                          AmountPayable = cd.Amount_Payable.HasValue ? cd.Amount_Payable.Value : (decimal)0,
                                          AmountPaid = cd.Amount_Paid.HasValue ? cd.Amount_Paid.Value : (decimal)0,
                                          Balance = cd.Balance.HasValue ? cd.Balance.Value : (decimal)0,

                                          InitiatorPersonType = cd.Initiator_Person_Type_Name,
                                          InitiatorName = cd.Initiator_Name,
                                          InitiatorContactAddress = cd.Initiator_Contact_Address,
                                          InitiatorEmail = cd.Initiator_Email,
                                          InitiatorMobilePhone = cd.Initiator_Mobile_Phone,

                                          RecipientPersonType = cd.Recipient_Person_Type_Name,
                                          RecipientName = cd.Recipient_Name,
                                          RecipientContactAddress = cd.Recipient_Contact_Address,
                                          RecipientEmail = cd.Recipient_Email,
                                          RecipientMobilePhone = cd.Recipient_Mobile_Phone,
                                          InvoiceNumber = cd.Invoice_Number
                                      }).ToList();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return status;
        }

        public List<PaymentStatus> GetDeptors(Trader trader)
        {
            List<PaymentStatus> status = null;

            try
            {
                string traderType = trader.ToString();

                string query = "SELECT * FROM VW_CREDITOR_AND_DEBTOR where Balance > 0 AND Initiator_Person_Type_Name = '" + traderType + "'";
                status = (from cd in base.repository.DbContext.Database.SqlQuery<VW_CREDITOR_AND_DEBTOR>(query)
                          select new PaymentStatus
                          {
                              PaymentId = cd.Payment_Id,
                              TransactionDate = cd.Transaction_Date,
                              Status = cd.Status,
                              AmountPayable = cd.Amount_Payable.HasValue ? cd.Amount_Payable.Value : (decimal)0,
                              AmountPaid = cd.Amount_Paid.HasValue ? cd.Amount_Paid.Value : (decimal)0,
                              Balance = cd.Balance.HasValue ? cd.Balance.Value : (decimal)0,

                              InitiatorPersonType = cd.Initiator_Person_Type_Name,
                              InitiatorName = cd.Initiator_Name,
                              InitiatorContactAddress = cd.Initiator_Contact_Address,
                              InitiatorEmail = cd.Initiator_Email,
                              InitiatorMobilePhone = cd.Initiator_Mobile_Phone,

                              RecipientPersonType = cd.Recipient_Person_Type_Name,
                              RecipientName = cd.Recipient_Name,
                              RecipientContactAddress = cd.Recipient_Contact_Address,
                              RecipientEmail = cd.Recipient_Email,
                              RecipientMobilePhone = cd.Recipient_Mobile_Phone,
                              InvoiceNumber = cd.Invoice_Number
                          }).ToList();
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return status;
        }

        public List<PaymentStatus> GetCreditors(Trader trader)
        {
            List<PaymentStatus> status = null;

            try
            {
                string traderType = trader.ToString();

                string query = "SELECT * FROM VW_CREDITOR_AND_DEBTOR where Balance < 0 AND Initiator_Person_Type_Name = '" + traderType + "'";
                status = (from cd in base.repository.DbContext.Database.SqlQuery<VW_CREDITOR_AND_DEBTOR>(query)
                          select new PaymentStatus
                          {
                              PaymentId = cd.Payment_Id,
                              TransactionDate = cd.Transaction_Date,
                              Status = cd.Status,
                              AmountPayable = cd.Amount_Payable.HasValue ? cd.Amount_Payable.Value : (decimal)0,
                              AmountPaid = cd.Amount_Paid.HasValue ? cd.Amount_Paid.Value : (decimal)0,
                              Balance = cd.Balance.HasValue ? Math.Abs(cd.Balance.Value) : (decimal)0,

                              InitiatorPersonType = cd.Initiator_Person_Type_Name,
                              InitiatorName = cd.Initiator_Name,
                              InitiatorContactAddress = cd.Initiator_Contact_Address,
                              InitiatorEmail = cd.Initiator_Email,
                              InitiatorMobilePhone = cd.Initiator_Mobile_Phone,

                              RecipientPersonType = cd.Recipient_Person_Type_Name,
                              RecipientName = cd.Recipient_Name,
                              RecipientContactAddress = cd.Recipient_Contact_Address,
                              RecipientEmail = cd.Recipient_Email,
                              RecipientMobilePhone = cd.Recipient_Mobile_Phone,
                              InvoiceNumber = cd.Invoice_Number
                          }).ToList();
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return status;
        }

       
    }
}
