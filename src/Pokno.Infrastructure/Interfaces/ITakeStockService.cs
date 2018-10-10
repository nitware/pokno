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

using System.Collections.Generic;
using Pokno.Model.Model;

namespace Pokno.Infrastructure.Interfaces
{
    public interface ITakeStockService
    {
        List<Year> GetTotalYears();
        bool TakeStock(StockReview stockReview);
        List<StockReviewDetail> GetYearlyStockReview(int year);
    }


}
