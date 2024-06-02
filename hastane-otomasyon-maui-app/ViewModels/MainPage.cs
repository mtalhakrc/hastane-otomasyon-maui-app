using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hastane_otomasyon_maui_app.Models;
using hastane_otomasyon_maui_app.Services;using System.Text.Json;


namespace hastane_otomasyon_maui_app.ViewModels
{
    public partial class MainPageViewModel: ObservableObject
    {
  
        private readonly IAuthService _authService;

        [ObservableProperty] private  string _userName;


        public MainPageViewModel(IAuthService authService)
        {
            _authService = authService;
            Initialize();
        }

        private async Task Initialize()
        {
            var memodel = await _authService.GetMeModel();
            UserName = memodel.UserName;
        }

    }
}