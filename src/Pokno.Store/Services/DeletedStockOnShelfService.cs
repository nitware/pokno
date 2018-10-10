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
using Pokno.Store.Interfaces;
using Pokno.Model.Model;
using Pokno.Service;
using System.Collections.Generic;

namespace Pokno.Store.Services
{
    public class DeletedStockOnShelfService : IDeletedStockOnShelfService
    {
        private IBusinessFacade _service;

        public DeletedStockOnShelfService(IBusinessFacade service)
        {
            _service = service;
        }
        
        public bool Add(List<DeletedShelfStock> deletedStockOnShelfs)
        {
            try
            {
                return _service.AddDeletedStockOnShelf(deletedStockOnShelfs);
            }
            catch (Exception)
            {
                throw;
            }
        }


       

    }
}
