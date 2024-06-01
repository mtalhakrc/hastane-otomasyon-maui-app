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
            var success = false;
            try
            {
                success = await _authService.LoginAsync(Email, Password);
                Console.WriteLine(success);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Hata", ex.Message, "Tamam");
                return;
            }

            if (!success)
            {
                await Shell.Current.DisplayAlert("Hata","Bir hata meydana geldi", "Tamam");
                return;
            }


            success = await _authService.SaveMe();
            if (!success)
            {
                await Shell.Current.DisplayAlert("Hata","Bir hata meydana geldi", "Tamam");
            }
            
            
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
        
    }
}
