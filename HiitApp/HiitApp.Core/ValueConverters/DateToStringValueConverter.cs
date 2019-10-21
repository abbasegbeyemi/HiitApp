using System;
using System.Globalization;
using MvvmCross.Platform.Converters;

namespace HiitApp.Core.ValueConverters
{
    public class DateToStringValueConverter : IMvxValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToString(value, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToDateTime(value, culture);
        }
    }
}
