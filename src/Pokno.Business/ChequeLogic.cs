using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Pokno.Model;
using Pokno.Entity;
using Pokno.Business.Interfaces;
using System.Linq.Expressions;
using System.Data.Entity.Core;

namespace Pokno.Business
{
    public class ChequeLogic : BusinessLogicBase<Cheque, CHEQUE>
    {
        public ChequeLogic(IRepository repository) : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new ChequeTranslator();
        }

        public bool Remove(List<PaymentDetail> paymentDetails)
        {
            try
            {
                int rowsAffected = 0;
                foreach (PaymentDetail paymentDetail in paymentDetails)
                {
                    if (paymentDetail.Cheque != null)
                    {
                        Expression<Func<CHEQUE, bool>> selector = cheque => cheque.Payment_Detail_Id == paymentDetail.Cheque.Id;
                        base.Remove(selector);
                        
                        rowsAffected++;
                    }
                }
               
                if (rowsAffected > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Modify(Cheque cheque)
        {
            try
            {
                Expression<Func<CHEQUE, bool>> predicate = c => c.Payment_Detail_Id == cheque.Id;
                CHEQUE chequeEntity = GetEntityBy(predicate);
                chequeEntity.Bank_Id = cheque.Bank.Id;
                chequeEntity.Cheque_Number = cheque.ChequeNumber;
                chequeEntity.Account_Number = cheque.AccountNumber;

                repository.Save();

                return true;
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

        
    }
     
}
