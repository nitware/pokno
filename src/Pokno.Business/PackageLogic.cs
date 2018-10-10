using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Pokno.Model;
using Pokno.Entity;
using System.Linq.Expressions;
using Pokno.Business.Interfaces;
using System.Data.Entity.Core;

namespace Pokno.Business
{
    public class PackageLogic : BusinessLogicBase<Package, PACKAGE>
    {
        private StockPackageLogic stockPackageLogic;

        public PackageLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            stockPackageLogic = new StockPackageLogic(repository);
            base.translator = new PackageTranslator();
        }

        public override List<Package> GetAll()
        {
            try
            {
                Expression<Func<PACKAGE, bool>> selector = p => p.Package_Id > 0;
                Func<IQueryable<PACKAGE>, IOrderedQueryable<PACKAGE>> orderBy = p => p.OrderBy(x => x.Package_Name);

                return base.GetModelsBy(selector, orderBy);

                //return base.GetAll().OrderBy(s => s.Name).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Modify(Package package)
        {
            try
            {
                Expression<Func<PACKAGE, bool>> predicate = _package => _package.Package_Id == package.Id;
                PACKAGE packageEntity = GetEntityBy(predicate);
                packageEntity.Package_Name = package.Name;
                packageEntity.Package_Description = package.Description;
               
                int rowAffected = repository.Save();

                if (rowAffected > 0)
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
            catch (ConstraintException)
            {
                throw new ConstraintException("");
            }
            catch (UpdateException)
            {
                throw new UpdateException(UpdateException);
            }
        }

        public bool Remove(Package package)
        {
            try
            {
                Expression<Func<PACKAGE, bool>> selector = _package => _package.Package_Id == package.Id;
                bool suceeded = base.Remove(selector);
                
                //repository.Save();
                return suceeded;

            }            
            catch (Exception)
            {
                throw;
            }
        }
        public List<Package> GetPackageForStock(Stock stock)
        {
            try
            {
                List<Package> packages = null;
                List<StockPackage> stockPackages = stockPackageLogic.GetAll();
                if (stockPackages != null && stockPackages.Count > 0)
                {
                    packages = stockPackages.Where(s => s.Stock.Id == stock.Id).Select(s => s.Package).ToList();
                }

                return packages;

               //return stockPackageLogic.GetAll().Where(stk => stk.Stock.Id == stock.Id).Select(stk =>stk.Package).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Package Get(long id)
        {
            try
            {
                Expression<Func<PACKAGE, bool>> selector = p => p.Package_Id == id;
                return base.GetModelBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
