using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFStyles;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
    }

    private void MainWindow_OnLoaded(object sender, RoutedEventArgs e) {
        var style = new Style();
        style.Setters.Add(new Setter(System.Windows.Controls.Panel.BackgroundProperty, Brushes.LightCoral));
        style.Setters.Add(new Setter(TextElement.FontSizeProperty, 32d));
        Panel.Style = style;
    }
}