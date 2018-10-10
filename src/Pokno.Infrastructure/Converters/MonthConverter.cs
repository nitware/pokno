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
    public class MonthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int month = (int)value;
            string monthName = "";
            switch (month)
            {
                case 1:
                    {
                         monthName = "January";
                        break;
                    }
                case 2:
                    {
                        monthName = "February";
                        break;
                    }
                case 3:
                    {
                        monthName = "March";
                        break;
                    }
                case 4:
                    {
                        monthName = "April";
                        break;
                    }
                case 5:
                    {
                        monthName = "May";
                        break;
                    }
                case 6:
                    {
                        monthName = "June";
                        break;
                    }
                case 7:
                    {
                        monthName = "July";
                        break;
                    }
                case 8:
                    {
                        monthName = "August";
                        break;
                    }
                case 9:
                    {
                        monthName = "September";
                        break;
                    }
                case 10:
                    {
                        monthName = "October";
                        break;
                    }
                case 11:
                    {
                        monthName = "November";
                        break;
                    }
                case 12:
                    {
                        monthName = "December";
                        break;
                    }
            }

            return monthName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
