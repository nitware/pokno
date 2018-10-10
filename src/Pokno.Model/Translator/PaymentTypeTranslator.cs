using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Entity;

namespace Pokno.Model
{
   public class PaymentTypeTranslator : TranslatorBase<PaymentType, PAYMENT_TYPE>
    {
        public override PaymentType TranslateToModel(PAYMENT_TYPE paymentTypeEntity)
        {
            try
            {
                PaymentType paymentType = null;
                if (paymentTypeEntity != null)
                {
                    paymentType = new PaymentType();
                    paymentType.Id = (int)paymentTypeEntity.Payment_Type_Id;
                    paymentType.Name = paymentTypeEntity.Payment_Name;
                }

                return paymentType;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override PAYMENT_TYPE TranslateToEntity(PaymentType paymentType)
        {
            try
            {
                PAYMENT_TYPE paymentTypeEntity = null;
                if (paymentType != null)
                {
                    paymentTypeEntity = new PAYMENT_TYPE();
                    paymentTypeEntity.Payment_Type_Id = paymentType.Id;
                    paymentTypeEntity.Payment_Name = paymentType.Name;
                }

                return paymentTypeEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }




    }


}
