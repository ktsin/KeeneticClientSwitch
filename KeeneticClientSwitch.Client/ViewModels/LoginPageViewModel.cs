using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KeeneticClientSwitch.Data.Models;
using KeeneticClientSwitch.Data.Services.Persistence;

namespace KeeneticClientSwitch.Client.ViewModels;

public partial class LoginPageViewModel : ObservableObject
{
    private readonly HttpClient _httpClient;
    private readonly ILoginPersistenceService _loginPersistenceService;

    private string _login = string.Empty;
    private string _password = string.Empty;
    private string _host = "http://192.168.10.1";

    public LoginPageViewModel(IHttpClientFactory httpClientFactory, ILoginPersistenceService loginPersistenceService)
    {
        _httpClient = httpClientFactory.CreateClient();
        _loginPersistenceService = loginPersistenceService;
    }

    public string Login
    {
        get => _login;
        set => SetProperty(ref _login, value);
    }

    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    public string Host
    {
        get => _host;
        set => SetProperty(ref _host, value);
    }

    [RelayCommand]
    private async Task LogIntoService()
    {
        if (string.IsNullOrWhiteSpace(Host))
        {
            await Snackbar.Make("Host is empty").Show();
            return;
        }

        var response = await _httpClient.GetAsync($"{Host}/rci");
        if (!response.IsSuccessStatusCode)
        {
            await Snackbar.Make("Host is not available").Show();
            return;
        }

        _ = Snackbar.Make("Host is available").Show();
        await _loginPersistenceService.SaveLastLogin(new LastLogin
        {
            Host = Host,
            Login = Login,
            Password = Password
        });

        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
}