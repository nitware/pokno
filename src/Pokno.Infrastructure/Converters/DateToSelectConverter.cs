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
    public class DateToSelectConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string dateString = "";
            DateTime date = (DateTime)value;
            const string dateFormat = "dd/MM/yyyy";
                       
            if (value != null)
            {
                string mins = DateTime.MinValue.ToString(dateFormat);
                dateString = date.ToString(dateFormat);
                if (dateString == mins)
                {
                    return "";
                }
            }

            return date.ToString("dd/MM/yyyy HH:mm:ss");
            //return date.ToString("ddd, dd MMM yyyy HH:mm:ss");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


    }
}
