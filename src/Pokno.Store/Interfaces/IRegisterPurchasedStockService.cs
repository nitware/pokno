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
using Pokno.Model.Model;

namespace Pokno.Store.Interfaces
{
    public interface IRegisterPurchasedStockService
    {
        List<StockPurchaseBatch> LoadAll();
        StockPurchaseBatch LoadBatchDetailsByBatch(StockPurchaseBatch stockPurchaseBatch);
        List<StockPurchased> LoadStockPurchasedByBatch(StockPurchaseBatch stockPurchaseBatch);
        bool Save(List<StockPurchased> StockPurchases);
        bool Modify(StockPurchaseBatch purchaseBatch);
        List<StockPurchasedAtHand> LoadStockPurchasedAtHand();
    }


}
