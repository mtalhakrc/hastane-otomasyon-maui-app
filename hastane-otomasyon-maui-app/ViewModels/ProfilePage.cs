using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hastane_otomasyon_maui_app.Models;
using hastane_otomasyon_maui_app.Services;
using hastane_otomasyon_maui_app.Pages;

namespace hastane_otomasyon_maui_app.ViewModels;

public partial class ProfilePageViewModel: ObservableObject
{
    private readonly IAuthService _authService;
    private readonly IClientService _clientService;

    [ObservableProperty]
    private ResetPasswordModel _resetPasswordModel;

    public ProfilePageViewModel(IAuthService authService, IClientService clientService)
    {
        _authService = authService;
        _clientService = clientService;
        _resetPasswordModel = new ResetPasswordModel();
    }
    [RelayCommand]
    public async Task ResetPassword()
    {
        var me = await _authService.GetMeModel();
        ResetPasswordModel.Email = me.Email;

        try
        {
            await _clientService.ResetPassword(ResetPasswordModel);
        }
        catch (Exception e)
        {
            await Shell.Current.DisplayAlert("Hata",e.Message, "Tamam");
        }
        return;
    }

    [RelayCommand]
    public async  void Logout()
    {
        var success = await _authService.LogoutAsync();
        if (!success)
        {
            await Shell.Current.DisplayAlert("Hata","Bir hata meydana geldi", "Tamam");
            return;
        }
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }
    
    
}