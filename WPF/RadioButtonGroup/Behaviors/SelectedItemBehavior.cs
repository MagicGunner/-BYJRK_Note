using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.Xaml.Behaviors;

namespace RadioButtonGroup.Behaviors;

public class SelectedItemBehavior : Behavior<FrameworkElement> {
    public static readonly DependencyProperty SelectedItemProperty
        = DependencyProperty.Register(nameof(SelectedItem), typeof(object), typeof(SelectedItemBehavior), new PropertyMetadata(null, OnSelectedItemChanged));

    private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        var selectedItemBehavior = Interaction.GetBehaviors(d).OfType<SelectedItemBehavior>().FirstOrDefault();
        foreach (var radioButton in selectedItemBehavior?.Children ?? []) {
            // radioButton.IsChecked = radioButton.Tag.Equals(selectedItemBehavior?.SelectedItem);
            radioButton.IsChecked = radioButton.Tag.Equals(e.NewValue);
        }
    }

    public object SelectedItem {
        get => GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    protected override void OnAttached() {
        AssociatedObject.Loaded += (_, _) => {
                                       foreach (var radioButton in Children) {
                                           radioButton.Checked += OnRadioButtonChecked;
                                           radioButton.IsChecked = radioButton.Tag.Equals(SelectedItem);
                                       }
                                   };
    }

    private void OnRadioButtonChecked(object sender, RoutedEventArgs e) {
        var radio = sender as RadioButton;
        SelectedItem = radio!.Tag;
        BindingOperations.GetBindingExpression(this, SelectedItemProperty)?.UpdateSource();
    }

    private IEnumerable<RadioButton> Children =>
        AssociatedObject switch {
            Panel panel               => panel.Children.OfType<RadioButton>(),
            ItemsControl itemsControl => itemsControl.Items.OfType<RadioButton>(),
            _                         => []
        };
}