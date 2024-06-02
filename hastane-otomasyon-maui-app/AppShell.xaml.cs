using hastane_otomasyon_maui_app.Pages;

namespace hastane_otomasyon_maui_app;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute(nameof(ListingPage), typeof(ListingPage));
        Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
        Routing.RegisterRoute(nameof(RandevuListingPage), typeof(RandevuListingPage));
        Routing.RegisterRoute(nameof(RandevuEditPage), typeof(RandevuEditPage));
    }
}