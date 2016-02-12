using MyInventory.Models;
using System;
using Windows.UI.Xaml.Data;

namespace MyInventory.WinRT.Converters
{
    public class EnumToStringConveter : IValueConverter 
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return Enum.Parse(typeof(TextSize), (string)value);
        }
    }
}
