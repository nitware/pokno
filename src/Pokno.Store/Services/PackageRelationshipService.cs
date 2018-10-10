using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using System.Collections.ObjectModel;
using Pokno.Model;
using Pokno.Service;
using System.Collections.Generic;
using Pokno.Infrastructure.Interfaces;

namespace Pokno.Store.Services
{
    public class PackageRelationshipService : ICollectibleService<PackageRelationship>
    {
        private IBusinessFacade _service;

        public PackageRelationshipService(IBusinessFacade service)
        {
            _service = service;
        }

        public bool Save(List<PackageRelationship> models)
        {
            try
            {
                return _service.AddPackageQuantities(models);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Modify(List<PackageRelationship> models)
        {
            try
            {
                return false;
                //return _service.ModifypackageQuantities(models);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<PackageRelationship> LoadByStock(Stock stock)
        {
            try
            {
                return _service.GetByStock(stock);
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}
