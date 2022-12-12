using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace LittleHelper.Converters
{
    public class InvertableBooleanToVisibilityConverter : IValueConverter
    {
        public bool Invert { get; set; }
        public Visibility FalseVisibility { get; set; }
        public InvertableBooleanToVisibilityConverter()
        {
            FalseVisibility = Visibility.Collapsed;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return FalseVisibility;

            bool boolValue;
            bool result = bool.TryParse(value.ToString(), out boolValue);

            if (!result) return value;

            if ((boolValue && !Invert) || (!boolValue && Invert)) return Visibility.Visible;

            if ((boolValue && Invert) || (!boolValue && !Invert)) return FalseVisibility;

            else return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
