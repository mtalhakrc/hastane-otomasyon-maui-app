using hastane_otomasyon_maui_app.Services;

namespace hastane_otomasyon_maui_app.Pages;

public partial class ProfilePage : ContentPage
{
    private readonly AuthService _authService;

    public ProfilePage(AuthService authService)
	{
		InitializeComponent();
        _authService = authService;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        _authService.Logout();
        Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }
}