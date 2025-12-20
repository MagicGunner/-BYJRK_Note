using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Xaml.Behaviors;

namespace BehaviorAndTrigger;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}

internal class MyBehavior : Behavior<Border> {
    protected override void OnAttached() {
        AssociatedObject.Background = Brushes.Blue;
        AssociatedObject.MouseEnter += (_, _) => AssociatedObject.Background = Brushes.Orange;
        AssociatedObject.MouseLeave += (_, _) => AssociatedObject.Background = Brushes.Red;
    }

    protected override void OnDetaching() {
    }
}

internal class ClearTextBehavior : Behavior<Button> {
    public static readonly DependencyProperty TargetProperty = DependencyProperty.Register(nameof(Target), typeof(TextBox), typeof(ClearTextBehavior), new PropertyMetadata(null));

    public TextBox Target {
        get => (TextBox)GetValue(TargetProperty);
        set => SetValue(TargetProperty, value);
    }

    protected override void OnAttached() {
        AssociatedObject.Click += OnButtonClick;
    }

    private void OnButtonClick(object sender, RoutedEventArgs e) {
        Target.Clear();
    }
}

internal class MouseWheelBehavior : Behavior<TextBox> {
    public int MaxValue { get; set; }
    public int MinValue { get; set; }
    public int Step     { get; set; } = 1;

    protected override void OnAttached() {
        AssociatedObject.MouseWheel += OnMouseWheel;
    }

    private void OnMouseWheel(object sender, MouseWheelEventArgs e) {
        if (int.TryParse(AssociatedObject.Text, out var num)) {
            if (e.Delta > 0) {
                AssociatedObject.Text = (Math.Min(num + Step, MaxValue)).ToString();
            }

            if (e.Delta < 0) {
                AssociatedObject.Text = (Math.Max(num - Step, MinValue)).ToString();
            }
        }
    }
}