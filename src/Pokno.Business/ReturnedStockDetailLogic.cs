using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;
using Pokno.Model.Translator;
using Pokno.Business.Interfaces;

namespace Pokno.Business
{
    public class ReturnedStockDetailLogic : BusinessLogicBase<ReturnedStockDetail, RETURNED_STOCK_DETAIL>
    {
        private PaymentLogic _paymentLogic;

        public ReturnedStockDetailLogic(IRepository repository) : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            _paymentLogic = new PaymentLogic(repository);
            translator = new ReturnedStockDetailTranslator();
        }

        public override ReturnedStockDetail Add(ReturnedStockDetail stockToReturn)
        {
            try
            {
                if (stockToReturn.Payment != null && stockToReturn.Payment.Details != null && stockToReturn.Payment.Details.Count > 0)
                {
                    stockToReturn.Payment = _paymentLogic.Add(stockToReturn.Payment);
                }

                return base.Add(stockToReturn);
            }
            catch (Exception)
            {
                throw;
            }
        }




    }


}
