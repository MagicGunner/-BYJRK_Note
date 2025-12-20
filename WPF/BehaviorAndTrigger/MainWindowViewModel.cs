using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BehaviorAndTrigger;

public partial class MainWindowViewModel : ObservableObject {
    [ObservableProperty]
    private string? _text;

    [RelayCommand]
    private async Task Loaded() {
        await Task.Delay(1000);
        Text = "MissBlue";
    }
}