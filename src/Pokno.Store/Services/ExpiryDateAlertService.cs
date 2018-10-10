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
using Pokno.Service;
using Pokno.Model.Model;
using System.Collections.Generic;

namespace Pokno.Store.Services
{
    public class ExpiryDateAlertService : IExpiryDateAlertService
    {
         private IBusinessFacade _service;

         public ExpiryDateAlertService(IBusinessFacade service)
         {
             _service = service;
         }

        public List<ExpiryDateAlert> GetAboutToExpiredStock()
        {
            try
            {
               return _service.GetAboutToExpiredStock();
            }
            catch (Exception)
            {
                throw;
            }
        }





    }
}
