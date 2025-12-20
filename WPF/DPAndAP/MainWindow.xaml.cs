using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DPAndAP;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();

        var box = new CustomTextBox();
        // 以下两种写法等价
        box.IsHighlight = true;
        box.SetValue(CustomTextBox.IsHighlightProperty, true);
    }
}