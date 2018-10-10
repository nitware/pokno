using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Pokno.Store.ViewModels;

namespace Pokno.Store.Views
{
    public partial class RegisterPurchasedStockView : UserControl
    {
        public RegisterPurchasedStockView(RegisterPurchasedStockViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;

            //System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.CreateSpecificCulture(System.Globalization.CultureInfo.CurrentCulture.Name);
            //ci.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
            //System.Threading.Thread.CurrentThread.CurrentCulture = ci;
        }

    }



}
