using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace MixIT.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var boolValue = (bool?)value;
            var invert = string.Compare(parameter as string, "invert", StringComparison.CurrentCultureIgnoreCase) == 0;

            if (invert)
            {
                boolValue = !boolValue.HasValue || !boolValue.Value;
            }

            return boolValue.HasValue && boolValue.Value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var visibilityValue = (Visibility?)value;

            return visibilityValue.HasValue && visibilityValue.Value == Visibility.Visible;
        }
    }
}