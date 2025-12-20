using System.Globalization;
using System.Windows.Data;

namespace RadioButtonGroup.ValueConverters;

public class ComparisonConverter : IValueConverter {
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
        // value是ViewModel里的Property，Enum，Apple
        // parameter：ConverterParameter，enum，Banana
        return value?.Equals(parameter);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
        // value：bool，RadioButtonGroup.IsChecked
        // parameter：ConverterParameter，enum，Banana
        return value is true ? parameter : Binding.DoNothing;
    }
}