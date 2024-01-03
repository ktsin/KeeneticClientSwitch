using KeeneticClientSwitch.Client.ViewModels;

namespace KeeneticClientSwitch.Client;

public partial class MainPage : ContentPage
{
    MainPageViewModel _viewModel;

    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}