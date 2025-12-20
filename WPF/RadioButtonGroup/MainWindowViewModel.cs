using CommunityToolkit.Mvvm.ComponentModel;

namespace RadioButtonGroup;

public partial class MainWindowViewModel : ObservableObject {
    [ObservableProperty]
    private bool _booleanValue;

    [ObservableProperty]
    private Fruit _selectedFruit;

    [ObservableProperty]
    private int _selectedNum;

    [ObservableProperty]
    private Vegetable _selectedVegetable;
}

public enum Fruit {
    Apple,
    Banana,
    Melon
}

public enum Vegetable {
    Carrot,
    Potato,
    Tomato
}