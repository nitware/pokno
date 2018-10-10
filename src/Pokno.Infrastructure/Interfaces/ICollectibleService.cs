using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Pokno.Model;

namespace Pokno.Infrastructure.Interfaces
{
    public interface ICollectibleService<T>
    {
        //List<StockPackage> LoadAll();
        List<T> LoadByStock(Stock stock);
        bool Save(List<T> models);
        bool Modify(List<T> models);
    }


}
