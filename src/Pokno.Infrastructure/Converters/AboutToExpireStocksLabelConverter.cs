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

using System.Windows.Data;
using System.Globalization;

namespace Pokno.Infrastructure.Converters
{
    public class AboutToExpireStocksLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string label = "";
            int days = (int)value;
                       
            if (days == -1)
            {
                label = "Expired yesterday";
            }
            else if (days == -2)
            {
                label = "Expired day before yesterday";
            }
            else if (days == 0)
            {
                label = "Expires today";
            }
            else if (days == 1)
            {
                label = "Will expire tomorrow";
            }
            else if (days == 2)
            {
                label = "Will expire next tomorrow";
            }
            else if (days > 2)
            {
                //label = days + " days remaining to expire";
                label = days + " days remaining to expire";
            }
            else if (days < -2)
            {
                //label = "Expired " + Math.Abs(days) + " days ago";
                //label = Math.Abs(days) + " days ago";
                //label = "days ago";

                label = Math.Abs(days) + " days after expiration";
            }
            
            return label;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
