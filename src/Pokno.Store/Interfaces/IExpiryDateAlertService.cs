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
using Pokno.Model.Model;
using System.Collections.Generic;

namespace Pokno.Store.Interfaces
{
    public interface IExpiryDateAlertService
    {
        List<ExpiryDateAlert> GetAboutToExpiredStock();
    }



}
