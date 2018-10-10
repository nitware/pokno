using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;
using Pokno.Business.Interfaces;
using Pokno.Model.Translator;
using System.Linq.Expressions;

namespace Pokno.Business
{
    public class ReplacedStockActionLogic : BusinessLogicBase<ReplacedStockAction, REPLACED_STOCK_ACTION>
    {
        public ReplacedStockActionLogic(IRepository repository) : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            translator = new ReplacedStockActionTranslator();
        }

        //public override List<ReplacedStockAction> GetAll()
        //{
        //    try
        //    {
        //        string include = "";

        //        Expression<Func<REPLACED_STOCK_ACTION, bool>> selector = rsa => rsa.Replaced_Stock_Action_Id > 0;
        //        return base.GetModelsBy(selector, null, include);
        //    }
        //    catch(Exception)
        //    {
        //        throw;
        //    }
        //}




    }
}
