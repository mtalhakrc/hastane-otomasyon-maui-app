using hastane_otomasyon_maui_app.Pages;
using hastane_otomasyon_maui_app.Services;
using hastane_otomasyon_maui_app.ViewModels;
using Microsoft.Extensions.Logging;

namespace hastane_otomasyon_maui_app;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        

#if DEBUG
        builder.Logging.AddDebug();
#endif


        builder.Services.AddHttpClient("custom-httpclient", httpClient =>
        {
            httpClient.BaseAddress = new Uri("http://localhost:5000");
        });
        builder.Services.AddSingleton<ClientService>();
        builder.Services.AddTransient<AuthService>();
        builder.Services.AddTransient<LoadingPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddSingleton<MainPageViewModel>();
        return builder.Build();
    }
}