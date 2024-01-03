using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using KeeneticClientSwitch.Client.ViewModels;

namespace KeeneticClientSwitch.Client;

public partial class LoginPage : ContentPage
{
	private readonly LoginPageViewModel _viewModel;
	
	public LoginPage(LoginPageViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
	}
}