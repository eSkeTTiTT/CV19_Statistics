using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using WPF_MVVM.Infrastructure.Converters.Base;

namespace WPF_MVVM.Infrastructure.Converters
{
    public class CompositeConverter : ConverterBase<CompositeConverter>
    {
        public IValueConverter First { get; set; }
        public IValueConverter Second { get; set; }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result_1 = First?.Convert(value, targetType, parameter, culture) ?? value;
            var result_2 = Second?.Convert(value, targetType, parameter, culture) ?? result_1;

            return result_2;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result_2 = Second?.Convert(value, targetType, parameter, culture) ?? value;
            var result_1 = First?.Convert(value, targetType, parameter, culture) ?? result_2;

            return result_1;
        }
    }
}
