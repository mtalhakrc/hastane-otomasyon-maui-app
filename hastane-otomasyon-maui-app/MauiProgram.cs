﻿using hastane_otomasyon_maui_app.Pages;
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
        builder.Services.AddScoped<IClientService,ClientService>();
        builder.Services.AddScoped<IAuthService,AuthService>();
        builder.Services.AddScoped<IRandevuService,RandevuService>();
        
        
        builder.Services.AddTransient<LoadingPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddTransient<RandevuListingPage>();
        builder.Services.AddTransient<RandevuEditPage>();
        
        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<LoginPageViewModel>();
        builder.Services.AddTransient<LoadingPageViewModel>();
        builder.Services.AddTransient<ProfilePageViewModel>();
        builder.Services.AddTransient<RandevuListingPageViewModel>();
        builder.Services.AddTransient<RandevuEditPageViewModel>();
        return builder.Build();
    }
}