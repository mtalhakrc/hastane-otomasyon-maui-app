using hastane_otomasyon_maui_app.Services;
using hastane_otomasyon_maui_app.ViewModels;

namespace hastane_otomasyon_maui_app.Pages;

public partial class ProfilePage : ContentPage
{
    public ProfilePage(ProfilePageViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
}