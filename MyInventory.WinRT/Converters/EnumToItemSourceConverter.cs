using System;
using Windows.UI.Xaml.Data;

namespace MyInventory.WinRT.Converters
{
    public class EnumToItemSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return Enum.GetNames(value.GetType()); 
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
