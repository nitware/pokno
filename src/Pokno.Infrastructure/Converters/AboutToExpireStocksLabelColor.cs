using System;
using System.Net;
using System.Windows;
using System.Windows.Input;

using System.Globalization;
using System.Windows.Data;

namespace Pokno.Infrastructure.Converters
{
    public class AboutToExpireStocksLabelColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int days = (int)value;
            string color = "";

            if (days < 0 )
            {
                color = "Red";
            }
            else if (days == 0)
            {
                color = "Gold";
            }
            else if (days == 1)
            {
                color = "Blue";
            }
            //else if (days == 1)
            //{
            //    color = "Green";
            //}
            else if (days == 2)
            {
                color = "YellowGreen";
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
