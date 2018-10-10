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
using System.Collections.Generic;

namespace Pokno.Store.Interfaces
{
    public interface ISoldStockService
    {
        List<SoldStockBatch> LoadAllOutgoingStockBatch();
        List<SoldStock> LoadOutgoingStockByBatch(SoldStockBatch outgoingStockBatch);
        bool Remove(SoldStockBatch outgoingStockBatch);
        bool Modify(SoldStockBatch soldStockBatch);
        

        //bool Modify(Payment payment, SoldStockBatch soldStockBatch);
        //List<SoldStock> LoadOutgoingStockByBatchId(long receiptNumber);


    }


}
