using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Data;

using Pokno.Model;
using Pokno.Entity;
using System.Linq.Expressions;
using Pokno.Business.Interfaces;
using System.Data.Entity.Core;


namespace Pokno.Business
{
    public class PaymentTypeLogic : BusinessLogicBase<PaymentType, PAYMENT_TYPE>
    {
        public PaymentTypeLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new PaymentTypeTranslator();
        }

        public bool Modify(PaymentType paymentType)
        {
            try
            {
                Expression<Func<PAYMENT_TYPE, bool>> predicate = pay => pay.Payment_Type_Id == paymentType.Id;
                PAYMENT_TYPE paymentTypeEntity = GetEntityBy(predicate);
                paymentTypeEntity.Payment_Name = paymentType.Name;

                int rowsAffected = repository.Save();
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    throw new Exception(NoItemModified);
                }
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

        public bool Remove(PaymentType paymentType)
        {
            try
            {
                Expression<Func<PAYMENT_TYPE, bool>> predicate = pay => pay.Payment_Type_Id == paymentType.Id;
                bool suceeded = Remove(predicate);

                //repository.Save();
                return suceeded;
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}
