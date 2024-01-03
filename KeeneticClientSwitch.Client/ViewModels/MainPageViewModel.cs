using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KeeneticClientSwitch.Data.Services.Persistence;

namespace KeeneticClientSwitch.Client.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private readonly LocalContext _localContext;

    public MainPageViewModel(LocalContext localContext)
    {
        _localContext = localContext;
    }

    [ObservableProperty]
    private int _count = 0;
    
    [ObservableProperty]
    private string _buttonText = "Click me!";
    
    [RelayCommand]
    private void CounterClick()
    {
        Count++;

        if (Count == 1)
            ButtonText = $"Clicked {Count} time";
        else
            ButtonText = $"Clicked {Count} times";

        _ = Toast.Make(_localContext.LastLogins.Count().ToString()).Show();

        SemanticScreenReader.Announce(ButtonText);
    }
}