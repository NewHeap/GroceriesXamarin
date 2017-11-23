using Xamarin.Forms;
using System;
using System.Globalization;

namespace GroceriesPlatformApp.ViewModels
{
    public class StringArrayToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Join(", ", value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((string)value).Split(',');
        }
    }
}