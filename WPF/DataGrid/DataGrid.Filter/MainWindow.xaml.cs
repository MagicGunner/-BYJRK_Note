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
public partial class MainWindow : Window {
    private readonly List<Employee> _employees;

    public MainWindow() {
        InitializeComponent();
        _employees = Employee.FakeMany(10).ToList();
        var cvs = FindResource("CollectionViewSource") as CollectionViewSource;
        cvs?.Source = _employees;
    }

    private void CollectionViewSource_OnFilter(object sender, FilterEventArgs e) {
        var employee = e.Item as Employee;
        var filter = FilterTextBox.Text;

        if (employee is { FirstName: not null, LastName: not null })
            e.Accepted = employee.FirstName.Contains(filter) || employee.LastName.Contains(filter);
    }

    private void FilterTextBox_OnTextChanged(object sender, TextChangedEventArgs e) {
        CollectionViewSource.GetDefaultView(DataGrid.ItemsSource).Refresh();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
        _employees.Add(Employee.FakeOne());
        CollectionViewSource.GetDefaultView(DataGrid.ItemsSource).Refresh();
    }
}