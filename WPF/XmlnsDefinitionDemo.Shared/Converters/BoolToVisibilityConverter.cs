using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace XmlnsDefinitionDemo.Shared.Converters;

public class BoolToVisibilityConverter : IValueConverter {
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
        if (value is not bool @bool) {
            return DependencyProperty.UnsetValue;
        }

        return @bool ? Visibility.Visible : Visibility.Collapsed;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
        if (value is not Visibility vis)
            return DependencyProperty.UnsetValue;
        return vis == Visibility.Visible;
    }
}