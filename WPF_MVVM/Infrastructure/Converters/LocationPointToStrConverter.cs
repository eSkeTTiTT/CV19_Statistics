using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using WPF_MVVM.Infrastructure.Converters.Base;

namespace WPF_MVVM.Infrastructure.Converters
{
    public class LocationPointToStrConverter : ConverterBase<LocationPointToStrConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Point point)) return string.Empty;

            return $"Lat:{point.X}; Lon:{point.Y}";
        }
    }
}
