using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hastane_otomasyon_maui_app.Services;

namespace hastane_otomasyon_maui_app.ViewModels;

public partial class LoadingPageViewModel: ObservableObject
{
    private readonly IAuthService _authService;

    public LoadingPageViewModel(IAuthService authService)
    {
        _authService = authService;
    }

    public bool IsAuthenticated()
    {
        return _authService.IsAuthenticated();
    }
}