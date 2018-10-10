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
    public class TabZIndexConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var tabItem = values[0] as TabItem;
            var tabControl = values[1] as TabControl;
            bool isSelected = true;
            if (values[2] != null)
            {
                isSelected = (bool)values[3];
            }
            if (isSelected)
            {
                return 1000;
            }
            else
            {
                if (tabItem == null || tabControl == null) return Binding.DoNothing;
                var count = (int)values[2];
                int index = tabControl.Items.IndexOf(tabItem);
                return count - index;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
