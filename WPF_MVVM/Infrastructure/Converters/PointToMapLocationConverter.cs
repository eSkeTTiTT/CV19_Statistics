using MapControl;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using WPF_MVVM.Infrastructure.Converters.Base;

namespace WPF_MVVM.Infrastructure.Converters
{
    public class PointToMapLocationConverter : ConverterBase<PointToMapLocationConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Point point))
                return null;

            return new Location(point.X, point.Y);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Location location))
                return null;

            return new Point(location.Latitude, location.Longitude);
        }
    }
}
