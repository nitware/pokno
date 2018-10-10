using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;
using Pokno.Business.Interfaces;
using Pokno.Model.Translator;
using Pokno.Model;
using System.Linq.Expressions;

namespace Pokno.Business
{
    public class CurrentStockPackageLogic : BusinessLogicBase<CurrentStockPackage, CURRENT_STOCK_PACKAGE>
    {
        public CurrentStockPackageLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            translator = new CurrentStockPackageTranslator();
        }

        public List<CurrentStockPackage> GetBy(Stock stock)
        {
            try
            {
                string include = "STOCK_PACKAGE";

                Expression<Func<CURRENT_STOCK_PACKAGE, bool>> selector = pr => pr.STOCK_PACKAGE.Stock_Id == stock.Id;
                return base.GetModelsBy(selector, null, include);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(Stock stock)
        {
            try
            {
                Expression<Func<CURRENT_STOCK_PACKAGE, bool>> selector = sp => sp.STOCK_PACKAGE.Stock_Id == stock.Id;
                return base.Remove(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}
