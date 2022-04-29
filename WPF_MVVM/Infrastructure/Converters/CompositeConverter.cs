using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;
using WPF_MVVM.Infrastructure.Converters.Base;

namespace WPF_MVVM.Infrastructure.Converters
{
    public class CompositeConverter : ConverterBase<CompositeConverter>
    {
        [ConstructorArgument(nameof(First))]
        public IValueConverter First { get; set; }

        [ConstructorArgument(nameof(Second))]
        public IValueConverter Second { get; set; }

        public CompositeConverter() { }
        public CompositeConverter(IValueConverter First) => this.First = First;
        public CompositeConverter(IValueConverter First, IValueConverter Second) : this(First) => this.Second = Second; 

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result_1 = First?.Convert(value, targetType, parameter, culture) ?? value;
            var result_2 = Second?.Convert(result_1, targetType, parameter, culture) ?? result_1;

            return result_2;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result_2 = Second?.Convert(value, targetType, parameter, culture) ?? value;
            var result_1 = First?.Convert(result_2, targetType, parameter, culture) ?? result_2;

            return result_1;
        }
    }
}
