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
using System.Collections.Generic;
using Pokno.Model.Model;

namespace Pokno.Store.Interfaces
{
    public interface IDeletedStockOnShelfService
    {
        bool Add(List<DeletedShelfStock> deletedStockOnShelfs);
    }


}
