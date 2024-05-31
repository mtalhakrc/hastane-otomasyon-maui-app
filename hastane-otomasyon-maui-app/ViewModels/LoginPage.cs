using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hastane_otomasyon_maui_app.Models;
using hastane_otomasyon_maui_app.Pages;
using hastane_otomasyon_maui_app.Services;

namespace hastane_otomasyon_maui_app.ViewModels
{
    public partial class LoginPageViewModel : ObservableObject
    {
        [ObservableProperty] private string _email;

        [ObservableProperty] private string _password;

        private readonly IAuthService _authService;

        public LoginPageViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        [RelayCommand]
        public async void Login()
        {
            try
            {
                Console.WriteLine(Email);
                var success = await _authService.Login(Email, Password);
                
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
            }

        }
    }
}
