using System;
using Xamarin.Forms;
using System.Globalization;
using GroceriesPlatformApp.ViewModels;

namespace GroceriesPlatformApp.Converters
{
    public class IsVisableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                ValidationViewModel item = (ValidationViewModel)value;
                return item.Errors.Length > 0;
            }
            catch
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}