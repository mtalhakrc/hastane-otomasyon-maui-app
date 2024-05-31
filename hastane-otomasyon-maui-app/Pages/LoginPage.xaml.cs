using hastane_otomasyon_maui_app.Services;
using hastane_otomasyon_maui_app.ViewModels;

namespace hastane_otomasyon_maui_app.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}

  
}