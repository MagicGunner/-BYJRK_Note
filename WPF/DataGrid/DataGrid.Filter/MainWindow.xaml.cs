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

namespace DataGrid.Filter;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow {
    private readonly List<Employee> _employees;

    public MainWindow() {
        InitializeComponent();
        _employees = Employee.FakeMany(10).ToList();
    }


    private void FilterTextBox_OnTextChanged(object sender, TextChangedEventArgs e) {
        CollectionViewSource.GetDefaultView(DataGrid.ItemsSource).Refresh();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
        _employees.Add(Employee.FakeOne());
        CollectionViewSource.GetDefaultView(DataGrid.ItemsSource).Refresh();
    }
}