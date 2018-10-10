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
using Pokno.Infrastructure.Interfaces;
using Pokno.Model;
using Pokno.Service;
using System.Collections.Generic;

namespace Pokno.Infratructure.Services
{
    public class PackageService : ISetupService<Package>
    {
        private IBusinessFacade _service;

        public PackageService(IBusinessFacade service)
        {
            _service = service;
        }

        public List<Package> LoadAll()
        {
            try
            {
                return _service.GetAllPackages();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Save(Package package)
        {
            try
            {
                return _service.AddPackage(package);
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
                return _service.ModifyPackage(package);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Remove(Package package)
        {
            try
            {
                return _service.RemovePackage(package);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }


}
