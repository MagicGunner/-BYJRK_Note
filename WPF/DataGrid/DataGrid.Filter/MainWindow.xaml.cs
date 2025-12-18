using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DataGrid.Filter;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow {
    private readonly List<Employee>  _employees;
    private readonly ICollectionView _collectionView;

    public MainWindow() {
        InitializeComponent();
        _employees = Employee.FakeMany(10).ToList();
        _collectionView = CollectionViewSource.GetDefaultView(_employees);
        DataGrid.ItemsSource = _collectionView;
        _collectionView.Filter = item => {
                                     if (item is not Employee employee) return false;
                                     var key = FilterTextBox.Text;
                                     if (employee.FirstName == null || employee.LastName == null) return false;
                                     return employee.FirstName.Contains(key) || employee.LastName.Contains(key);
                                 };
    }

    private void FilterTextBox_OnTextChanged(object sender, TextChangedEventArgs e) {
        _collectionView.Refresh();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
        _employees.Add(Employee.FakeOne());
        _collectionView.Refresh();
    }
}