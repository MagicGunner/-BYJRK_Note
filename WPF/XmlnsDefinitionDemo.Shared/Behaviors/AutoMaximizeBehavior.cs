using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace XmlnsDefinitionDemo.Shared.Behaviors;

public class AutoMaximizeBehavior : Behavior<Window> {
    protected override void OnAttached() {
        AssociatedObject.Loaded -= OnLoaded;
        AssociatedObject.Loaded += OnLoaded;
    }

    protected override void OnDetaching() {
        AssociatedObject.Loaded -= OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e) {
        AssociatedObject.WindowState = WindowState.Maximized;
    }
}