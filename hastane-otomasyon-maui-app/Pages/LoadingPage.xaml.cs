using hastane_otomasyon_maui_app.Services;

namespace hastane_otomasyon_maui_app.Pages;

public partial class LoadingPage : ContentPage
{
    public LoadingPage()
	{
		InitializeComponent();
    }

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        // if(await _authService.IsAuthenticatedAsync())
        // {
        //     // User is logged in
        //     // redirect to main page
        //     await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        // }
        // else
        // {
        //     // User is not logged in 
        //     // Redirect to LoginPage
        //     await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        // }
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }
}