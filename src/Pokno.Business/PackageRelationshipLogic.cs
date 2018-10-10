using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Pokno.Model;
using Pokno.Entity;
using Pokno.Model.Model;
using System.Linq.Expressions;
using Pokno.Business.Interfaces;
using System.Data.Entity.Core;
using Pokno.Model.Views;

namespace Pokno.Business
{
    public class PackageRelationshipLogic : BusinessLogicBase<PackageRelationship, PACKAGE_RELATIONSHIP>
    {
        private StockPackageLogic _stockPackageLogic;
        private CurrentStockPackageRelationshipLogic _currentStockPackageRelationshipLogic;

        public PackageRelationshipLogic(IRepository repository) : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            _stockPackageLogic = new StockPackageLogic(repository);
            _currentStockPackageRelationshipLogic = new CurrentStockPackageRelationshipLogic(repository);
            base.translator = new PackageRelationshipTranslator();
        }

        public List<StockPackage> GetBy(Stock stock, StockPackageRelationship stockPackageRelationship)
        {
            try
            {
                List<StockPackage> stockPackages = null;
                List<PackageRelationship> packageRelationships = GetBy(stockPackageRelationship);
                if (packageRelationships != null && packageRelationships.Count > 0)
                {
                    stockPackages = new List<StockPackage>();
                    foreach (PackageRelationship packageRelationship in packageRelationships)
                    {
                        if (packageRelationship.Package != null && packageRelationship.Package.Id > 0)
                        {
                             List<StockPackage> existingStockPackages = stockPackages.Where(s => s.Id == packageRelationship.Package.Id).ToList();
                             if (existingStockPackages == null || existingStockPackages.Count <= 0)
                             {
                                 stockPackages.Add(packageRelationship.Package);
                             }
                        }

                        if (packageRelationship.SubPackage != null && packageRelationship.SubPackage.Id > 0)
                        {
                            List<StockPackage> existingStockPackages = stockPackages.Where(s => s.Id == packageRelationship.SubPackage.Id).ToList();
                             if (existingStockPackages == null || existingStockPackages.Count <= 0)
                             {
                                 stockPackages.Add(packageRelationship.SubPackage);
                             }
                        }
                    }
                }

                return stockPackages;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetRelationshipString(int StockPackageRelationshipId)
        {
            try
            {
                List<PackageRelationship> packageRelationships = GetBy(StockPackageRelationshipId);
                packageRelationships = packageRelationships.OrderByDescending(p => p.Rank).ToList();

                string packageRelationshipString = null;
                for (int i = 0; i < packageRelationships.Count; i++)
                {
                    if (packageRelationships[i].SubPackage != null && packageRelationships[i].Package != null)
                    {
                        packageRelationshipString += packageRelationships[i].Quantity + " " + packageRelationships[i].SubPackage.Package.Name + Get(packageRelationships[i].Quantity) + packageRelationships[i].Package.Package.Name;
                    }
                    else if (packageRelationships[i].SubPackage == null && packageRelationships[i].Package != null)
                    {
                        packageRelationshipString += packageRelationships[i].Quantity + " " + Get(packageRelationships[i].Quantity) + packageRelationships[i].Package.Package.Name;
                    }

                    if (i != (packageRelationships.Count - 1))
                    {
                        packageRelationshipString += ",";
                    }
                }

                return packageRelationshipString;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string Get(decimal number)
        {
            return number > 1 ? "s in " : " in ";
        }

        //private string Get(long number)
        //{
        //    return number > 1 ? "s in " : " in ";
        //}

        public override List<PackageRelationship> GetAll()
        {
            try
            {
                List<CurrentStockPackageRelationship> packageRelationships = _currentStockPackageRelationshipLogic.GetAll();
                return ConvertToPackageRelationship(packageRelationships);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PackageRelationship> GetBy(StockPackageRelationship stockPackageRelationship)
        {
            try
            {
                Expression<Func<PACKAGE_RELATIONSHIP, bool>> selector = pr => pr.Stock_Package_Relationship_Id == stockPackageRelationship.Id;
                return base.GetModelsBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PackageRelationship> GetBy(int stockPackageRelationshipId)
        {
            try
            {
                Expression<Func<PACKAGE_RELATIONSHIP, bool>> selector = pr => pr.Stock_Package_Relationship_Id == stockPackageRelationshipId;
                return base.GetModelsBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PackageRelationship> GetBy(Stock stock)
        {
            List<PackageRelationship> currentPackageRelationships = null;

            try
            {
                string query = "SELECT Stock_Package_Relationship_Id FROM VW_CURRENT_STOCK_PACKAGE_RELATIONSHIP where Stock_Id = " + stock.Id;
                long packageRelationshipId = repository.DbContext.Database.SqlQuery<long>(query).FirstOrDefault();
                //long packageRelationshipId = repository.DbContext.Database.SqlQuery<long>(query).SingleOrDefault();

                
                if (packageRelationshipId > 0)
                {
                    currentPackageRelationships = GetModelsBy(pr => pr.Stock_Package_Relationship_Id == packageRelationshipId);
                }
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return currentPackageRelationships;
        }

        private List<PackageRelationship> ConvertToPackageRelationship(List<CurrentStockPackageRelationship> currentPackageRelationships)
        {
            try
            {
                if (currentPackageRelationships == null || currentPackageRelationships.Count <= 0)
                {
                    return null;
                }

                List<PackageRelationship> packageRelationships = new List<PackageRelationship>();
                foreach (CurrentStockPackageRelationship currentPackageRelationship in currentPackageRelationships)
                {
                    packageRelationships.AddRange(currentPackageRelationship.StockPackageRelationship.Relationships);
                }

                return packageRelationships;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StorePackage> Get()
        {
            List<StorePackage> packageRelationships = null;

            try
            {
                string query = "SELECT * FROM VW_CURRENT_STOCK_PACKAGE_RELATIONSHIP";
                packageRelationships = (from pr in repository.DbContext.Database.SqlQuery<VW_CURRENT_STOCK_PACKAGE_RELATIONSHIP>(query)
                                        select new StorePackage
                                              {
                                                  StockName = pr.Stock_Name,
                                                  PackageName = pr.Package_Name,
                                                  SubPackageName = pr.Sub_Package_Name,
                                                  QuantityInPackage = pr.Quantity_In_Package,

                                              }).ToList();
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return packageRelationships;
        }

        //public List<StorePackage> Get()
        //{
        //    try
        //    {
        //        List<PackageRelationship> packageQuantities = GetAll();
        //        List<StorePackage> storePackages = new List<StorePackage>();
        //        if (packageQuantities != null && packageQuantities.Count > 0)
        //        {
        //            foreach (PackageRelationship packageQuantity in packageQuantities)
        //            {
        //                StorePackage storePackage = new StorePackage();
        //                if (packageQuantity.Package != null && packageQuantity.Package.Id > 0)
        //                {
        //                    storePackage.StockName = packageQuantity.Package.Stock.Name;
        //                    storePackage.PackageName = packageQuantity.Package.Package.Name;
        //                }
        //                if (packageQuantity.SubPackage != null && packageQuantity.SubPackage.Id > 0)
        //                {
        //                    storePackage.SubPackageName = packageQuantity.SubPackage.Package.Name;
        //                    storePackage.QuantityInPackage = packageQuantity.Quantity;
        //                }

        //                storePackages.Add(storePackage);
        //            }
        //        }

        //        return storePackages;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public List<PackageRelationship> GetBy(PackageRelationship packageRelationship)
        {
            try
            {
                if (packageRelationship == null || packageRelationship.Id <= 0)
                {
                    throw new ArgumentNullException("packageRelationship");
                }

                Func<IQueryable<PACKAGE_RELATIONSHIP>, IOrderedQueryable<PACKAGE_RELATIONSHIP>> orderBy = p => p.OrderBy(x => x.Rank);
                Expression<Func<PACKAGE_RELATIONSHIP, bool>> selector = pq => (pq.Stock_Package_Relationship_Id == packageRelationship.StockPackageRelationship.Id) && (pq.Rank >= packageRelationship.Rank);

                //Expression<Func<PACKAGE_RELATIONSHIP, bool>> selector = pq => (pq.Package_Relationship_Id == packageQuantity.Id) && (pq.Rank >= packageQuantity.Rank);
                
                return GetModelsBy(selector, orderBy);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public PackageRelationship GetBy(StockPackage stockPackage)
        //{
        //    try
        //    {
        //        string query = "SELECT Stock_Package_Relationship_Id FROM VW_CURRENT_STOCK_PACKAGE_RELATIONSHIP where Stock_Package_Id = " + stockPackage.Id;
        //        long packageRelationshipId = repository.DbContext.Database.SqlQuery<long>(query).SingleOrDefault();

        //        //PackageRelationship packageRelationship = new PackageRelationship() { Id = packageRelationshipId };

        //        //Expression<Func<VW_CURRENT_STOCK_PACKAGE_RELATIONSHIP, bool>> selector = pr => pr.Stock_Package_Id == stockPackage.Id;
        //        //PackageRelationship packageRelationship = (from pr in repository.DbContext.Database.SqlQuery<long>(query)
        //        //                                           select new PackageRelationship
        //        //                                           {
        //        //                                               Id = pr.Package_Relationship_Id,
        //        //                                           }).SingleOrDefault();

        //        PackageRelationship packageRelationship = null;
        //        if (packageRelationshipId > 0)
        //        {
        //            packageRelationship = GetModelBy(pr => pr.Package_Relationship_Id == packageRelationshipId);
        //        }

        //        return packageRelationship;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public PackageRelationship GetBy(long stockPackageId, StockPackageRelationship stockPackageRelationship)
        {
            try
            {
                return GetByHelper(stockPackageId, stockPackageRelationship);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public PackageRelationship GetBy(StockPackage stockPackage, StockPackageRelationship stockPackageRelationship)
        {
            try
            {
                return GetByHelper(stockPackage.Id, stockPackageRelationship);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private PackageRelationship GetByHelper(long stockPackageId, StockPackageRelationship stockPackageRelationship)
        {
            try
            {
                Expression<Func<PACKAGE_RELATIONSHIP, bool>> selector = pr => pr.Stock_Package_Id == stockPackageId && pr.Stock_Package_Relationship_Id == stockPackageRelationship.Id;
                PackageRelationship packageRelationship = (from pr in repository.FindAll(selector)
                                                           select new PackageRelationship
                                                           {
                                                               Id = pr.Package_Relationship_Id,
                                                           }).SingleOrDefault();

                if (packageRelationship != null && packageRelationship.Id > 0)
                {
                    packageRelationship = GetModelBy(pr => pr.Package_Relationship_Id == packageRelationship.Id);
                }

                return packageRelationship;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public PackageRelationship GetSubPackageBy(long stockPackageId, StockPackageRelationship stockPackageRelationship)
        {
            try
            {
                return GetSubPackageByHelper(stockPackageId, stockPackageRelationship);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public PackageRelationship GetSubPackageBy(StockPackage stockPackage, StockPackageRelationship stockPackageRelationship)
        {
            try
            {
                return GetSubPackageByHelper(stockPackage.Id, stockPackageRelationship);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private PackageRelationship GetSubPackageByHelper(long stockPackageId, StockPackageRelationship stockPackageRelationship)
        {
            try
            {
                Expression<Func<PACKAGE_RELATIONSHIP, bool>> selector = pr => pr.Sub_Stock_Package_Id == stockPackageId && pr.Stock_Package_Relationship_Id == stockPackageRelationship.Id;
                PackageRelationship packageRelationship = (from pr in repository.FindAll(selector)
                                                           select new PackageRelationship
                                                           {
                                                               Id = pr.Package_Relationship_Id,
                                                           }).SingleOrDefault();

                if (packageRelationship != null && packageRelationship.Id > 0)
                {
                    packageRelationship = GetModelBy(pr => pr.Package_Relationship_Id == packageRelationship.Id);
                }

                return packageRelationship;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public decimal GetTotalUnitItem(int StockPackageRelationshipId)
        {
            try
            {
                StockPackageRelationship stockPackageRelationship = new StockPackageRelationship() { Id = StockPackageRelationshipId };
                List<PackageRelationship> packageRelationships = GetBy(stockPackageRelationship);

                return GetTotalUnitItem(packageRelationships);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public long GetTotalUnitItem(int StockPackageRelationshipId)
        //{
        //    try
        //    {
        //        StockPackageRelationship stockPackageRelationship = new StockPackageRelationship() { Id = StockPackageRelationshipId };
        //        List<PackageRelationship> packageRelationships = GetBy(stockPackageRelationship);

        //        return GetTotalUnitItem(packageRelationships);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public decimal GetTotalUnitItem(long stockPackageId, StockPackageRelationship stockPackageRelationship)
        {
            try
            {
                return GetTotalUnitItemHelper(stockPackageId, stockPackageRelationship);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public decimal GetTotalUnitItem(StockPackage stockPackage, StockPackageRelationship stockPackageRelationship)
        {
            try
            {
                return GetTotalUnitItemHelper(stockPackage.Id, stockPackageRelationship);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public long GetTotalUnitItem(long stockPackageId, StockPackageRelationship stockPackageRelationship)
        //{
        //    try
        //    {
        //        return GetTotalUnitItemHelper(stockPackageId, stockPackageRelationship);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //public long GetTotalUnitItem(StockPackage stockPackage, StockPackageRelationship stockPackageRelationship)
        //{
        //    try
        //    {
        //        return GetTotalUnitItemHelper(stockPackage.Id, stockPackageRelationship);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        private decimal GetTotalUnitItemHelper(long stockPackageId, StockPackageRelationship stockPackageRelationship)
        {
            try
            {
                PackageRelationship packageQuantity = GetBy(stockPackageId, stockPackageRelationship);

                if (packageQuantity == null)
                {
                    PackageRelationship subPackageQuantity = GetSubPackageBy(stockPackageId, stockPackageRelationship);
                    if (subPackageQuantity != null)
                    {
                        return 1;
                    }
                }

                List<PackageRelationship> packageQuantities = GetBy(packageQuantity);
                return GetTotalUnitItem(packageQuantities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //private long GetTotalUnitItemHelper(long stockPackageId, StockPackageRelationship stockPackageRelationship)
        //{
        //    try
        //    {
        //        PackageRelationship packageQuantity = GetBy(stockPackageId, stockPackageRelationship);

        //        if (packageQuantity == null)
        //        {
        //            PackageRelationship subPackageQuantity = GetSubPackageBy(stockPackageId, stockPackageRelationship);
        //            if (subPackageQuantity != null)
        //            {
        //                return 1;
        //            }
        //        }

        //        List<PackageRelationship> packageQuantities = GetBy(packageQuantity);
        //        return GetTotalUnitItem(packageQuantities);
        //    }
        //    catch(Exception)
        //    {
        //        throw;
        //    }
        //}

        public decimal GetTotalUnitItem(List<StockPurchased> stockPurchases)
        {
            try
            {
                decimal totalUnitItem = 0;
                if (stockPurchases != null)
                {
                    foreach (StockPurchased stockPurchased in stockPurchases)
                    {
                        PackageRelationship packageRelationship = GetBy(stockPurchased.StockPackage, stockPurchased.StockPackageRelationship);
                        if (packageRelationship == null)
                        {
                            packageRelationship = GetSubPackageBy(stockPurchased.StockPackage, stockPurchased.StockPackageRelationship);
                            if (packageRelationship != null)
                            {
                                totalUnitItem += stockPurchased.Quantity;
                                continue;
                            }
                        }

                        List<PackageRelationship> packageRelationships = GetBy(packageRelationship);
                        if (packageRelationships == null || packageRelationships.Count <= 0)
                        {
                            throw new Exception("Package Relationships for '" + stockPurchased.Stock.Name + "' has not been setup! Please set it up.");
                        }

                        decimal stockUnitItemQuantity = GetTotalUnitItem(packageRelationships);
                        totalUnitItem += (stockUnitItemQuantity * stockPurchased.Quantity);
                    }
                }

                return totalUnitItem;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        //public long GetTotalUnitItem(List<StockPurchased> stockPurchases)
        //{
        //    try
        //    {
        //        long totalUnitItem = 0;
        //        if (stockPurchases != null)
        //        {
        //            foreach (StockPurchased stockPurchased in stockPurchases)
        //            {
        //                PackageRelationship packageRelationship = GetBy(stockPurchased.StockPackage, stockPurchased.StockPackageRelationship);
        //                if (packageRelationship == null)
        //                {
        //                    packageRelationship = GetSubPackageBy(stockPurchased.StockPackage, stockPurchased.StockPackageRelationship);
        //                    if (packageRelationship != null)
        //                    {
        //                        totalUnitItem += stockPurchased.Quantity;
        //                        continue;
        //                    }
        //                }

        //                List<PackageRelationship> packageRelationships = GetBy(packageRelationship);
        //                if (packageRelationships == null || packageRelationships.Count <= 0)
        //                {
        //                    throw new Exception("Package Relationships for '" + stockPurchased.Stock.Name + "' has not been setup! Please set it up.");
        //                }

        //                long stockUnitItemQuantity = GetTotalUnitItem(packageRelationships);
        //                totalUnitItem += (stockUnitItemQuantity * stockPurchased.Quantity);
        //            }
        //        }

        //        return totalUnitItem;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public decimal GetTotalUnitItem(List<PackageRelationship> packageRelationships)
        {
            try
            {
                decimal totalUnitItem = 1;
                foreach (PackageRelationship packageRelationship in packageRelationships)
                {
                    totalUnitItem *= packageRelationship.Quantity;
                }

                return totalUnitItem;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public long GetTotalUnitItem(List<PackageRelationship> packageRelationships)
        //{
        //    try
        //    {
        //        long totalUnitItem = 1;
        //        foreach (PackageRelationship packageRelationship in packageRelationships)
        //        {
        //            totalUnitItem *= packageRelationship.Quantity;
        //        }

        //        return totalUnitItem;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public PackageRelationship GetSmallestBy(Stock stock)
        {
            try
            {
                if (stock != null)
                {
                    List<PackageRelationship> packageRelationships = GetBy(stock);
                    if (packageRelationships != null && packageRelationships.Count > 0)
                    {
                        return packageRelationships.OrderBy(pq => pq.Rank).LastOrDefault();
                    }
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public StockPackage GetSmallestPackageBy(Stock stock)
        {
            try
            {
                if (stock != null)
                {
                    List<PackageRelationship> packageQuantities = GetBy(stock);
                    if (packageQuantities != null && packageQuantities.Count > 0)
                    {
                        PackageRelationship packageQuantity = packageQuantities.OrderBy(pq => pq.Rank).LastOrDefault();
                        if (packageQuantity.SubPackage != null)
                        {
                            return packageQuantity.SubPackage;
                        }
                        else
                        {
                            return packageQuantity.Package;
                        }
                    }
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Get(decimal totalUnitItemQuantity, long stockPackageRelationshipId)
        {
            try
            {
                string packages = null;
                decimal totalUnitItemCount = 0;
                decimal totalPackageRelationship = 0;

                List<PackageRelationship> stockTotalPackageRelationships = GetBy((int)stockPackageRelationshipId);
                for (int i = 0; i < stockTotalPackageRelationships.Count; i++)
                {
                    PackageRelationship packagepackageRelationship = stockTotalPackageRelationships[i];
                    List<PackageRelationship> packageRelationships = GetBy(packagepackageRelationship);

                    if (packageRelationships != null && packageRelationships.Count > 0)
                    {
                        totalUnitItemCount = GetTotalUnitItem(packageRelationships);
                        if ((totalUnitItemCount <= totalUnitItemQuantity) && (i < stockTotalPackageRelationships.Count))
                        {
                            totalPackageRelationship = Math.Truncate(totalUnitItemQuantity / totalUnitItemCount);
                            totalUnitItemQuantity = totalUnitItemQuantity - (totalPackageRelationship * totalUnitItemCount);
                            packages += totalPackageRelationship + " " + packagepackageRelationship.Package.Package.Name;
                        }

                        if (i == stockTotalPackageRelationships.Count - 1)
                        {
                            if (totalUnitItemQuantity > 0)
                            {
                                if (!string.IsNullOrWhiteSpace(packages))
                                {
                                    packages += ", ";
                                }

                                packages += totalUnitItemQuantity + " " + packagepackageRelationship.SubPackage.Package.Name;
                            }
                        }
                    }
                }

                return packages;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public string Get(double totalUnitItemQuantity, long stockPackageRelationshipId)
        //{
        //    try
        //    {
        //        string packages = null;
        //        long totalUnitItemCount = 0;
        //        double totalPackageRelationship = 0;

        //        List<PackageRelationship> stockTotalPackageRelationships = GetBy((int)stockPackageRelationshipId);
        //        for (int i = 0; i < stockTotalPackageRelationships.Count; i++)
        //        {
        //            PackageRelationship packagepackageRelationship = stockTotalPackageRelationships[i];
        //            List<PackageRelationship> packageRelationships = GetBy(packagepackageRelationship);

        //            if (packageRelationships != null && packageRelationships.Count > 0)
        //            {
        //                totalUnitItemCount = GetTotalUnitItem(packageRelationships);
        //                if ((totalUnitItemCount <= totalUnitItemQuantity) && (i < stockTotalPackageRelationships.Count))
        //                {
        //                    totalPackageRelationship = Math.Truncate(totalUnitItemQuantity / (double)totalUnitItemCount);
        //                    totalUnitItemQuantity = totalUnitItemQuantity - (totalPackageRelationship * totalUnitItemCount);
        //                    packages += totalPackageRelationship + " " + packagepackageRelationship.Package.Package.Name;
        //                }

        //                if (i == stockTotalPackageRelationships.Count - 1)
        //                {
        //                    if (totalUnitItemQuantity > 0)
        //                    {
        //                        if (!string.IsNullOrWhiteSpace(packages))
        //                        {
        //                            packages += ", ";
        //                        }

        //                        packages += totalUnitItemQuantity + " " + packagepackageRelationship.SubPackage.Package.Name;
        //                    }
        //                }
        //            }
        //        }

        //        return packages;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public bool Remove(Stock stock)
        {
            try
            {
                if (stock == null || stock.Id <= 0)
                {
                    throw new ArgumentNullException("stock");
                }

                Expression<Func<PACKAGE_RELATIONSHIP, bool>> selector = cpr => cpr.STOCK_PACKAGE_RELATIONSHIP.Stock_Id == stock.Id;
                return base.Remove(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }


       



    }
}
