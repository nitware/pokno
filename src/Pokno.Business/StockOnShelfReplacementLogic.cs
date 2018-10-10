using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Model;
using Pokno.Entity;
using Pokno.Business.Interfaces;

namespace Pokno.Business
{
    public class StockOnShelfReplacementLogic : BusinessLogicBase<StockOnShelfReplacement, SHELF_STOCK_REPLACEMENT>
    {
        public StockOnShelfReplacementLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
           // base.translator = new StockOnShelfReplacementTranslator();
        }


    }
}
