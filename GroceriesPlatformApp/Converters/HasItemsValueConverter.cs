using System;
using Xamarin.Forms;
using System.Collections;
using System.Globalization;

namespace GroceriesPlatformApp.Converters
{
    public class HasItemsValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = ((IList)value);
            return !(list != null && list.Count > 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}