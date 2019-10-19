using System;
using System.Globalization;
using MvvmCross.Platform.Converters;

namespace HiitApp.Core.ValueConverters
{
    public class IntToStringValueConverter : IMvxValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToString(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToInt32(value);
        }
    }
}
