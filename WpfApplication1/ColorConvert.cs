using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media;

namespace WpfApplication1
{
    public class ColorConvert: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            Color color = (Color)ColorConverter.ConvertFromString(value.ToString());
            SolidColorBrush brush = new SolidColorBrush(color);
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }
    }
}
