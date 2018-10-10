using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Model;
using Pokno.Entity;
using Pokno.Model.Model;
using Pokno.Model.Translator;
using System.Linq.Expressions;
using Pokno.Business.Interfaces;

namespace Pokno.Business
{
    public class CurrentStockPackageRelationshipLogic : BusinessLogicBase<CurrentStockPackageRelationship, CURRENT_STOCK_PACKAGE_RELATIONSHIP>
    {
        public CurrentStockPackageRelationshipLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            translator = new CurrentStockPackageRelationshipTranslator();
        }

        public List<CurrentStockPackageRelationship> GetBy(Stock stock)
        {
            try
            {
                string include = "STOCK_PACKAGE_RELATIONSHIP";

                Expression<Func<CURRENT_STOCK_PACKAGE_RELATIONSHIP, bool>> selector = pr => pr.STOCK_PACKAGE_RELATIONSHIP.Stock_Id == stock.Id;
                return base.GetModelsBy(selector, null, include);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override CurrentStockPackageRelationship Add(CurrentStockPackageRelationship model)
        {
            try
            {
                bool done = Remove(model.StockPackageRelationship.Stock);
                return base.Add(model);
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
                if (stock == null || stock.Id <= 0)
                {
                    throw new ArgumentNullException("stock");
                }

                Expression<Func<CURRENT_STOCK_PACKAGE_RELATIONSHIP, bool>> selector = cpr => cpr.STOCK_PACKAGE_RELATIONSHIP.Stock_Id == stock.Id;
                return base.Remove(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }






    }


}
