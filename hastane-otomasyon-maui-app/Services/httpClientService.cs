
using System.Net;
using hastane_otomasyon_maui_app.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace hastane_otomasyon_maui_app.Services
{
    public class ClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ClientService(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        public async Task Register(RegisterModel model)
        {
            // model.Email = "maui@gmail.com"; model.Password = "Maui@123";
            var httpClient = _httpClientFactory.CreateClient("custom-httpclient");
            var result = await httpClient.PostAsJsonAsync("/register", model);
            if (result.IsSuccessStatusCode)
            {
                await Shell.Current.DisplayAlert("Alert", "sucessfully Register", "Ok");
            }
            await Shell.Current.DisplayAlert("Alert", result.ReasonPhrase, "Ok");
        }

        public async Task Login(LoginModel model)
        {
            //model.Email = "maui@gmail.com"; model.Password = "Maui@123";
            var serializedLoginResponseInStorage = await SecureStorage.Default.GetAsync("Authentication");
            Console.WriteLine(serializedLoginResponseInStorage);
            Console.WriteLine(value:(serializedLoginResponseInStorage));
            
            var httpClient = _httpClientFactory.CreateClient("custom-httpclient");
            var result = await httpClient.PostAsJsonAsync("/login", model);
            var response = await result.Content.ReadFromJsonAsync<LoginResponse>();
            if (result.StatusCode != HttpStatusCode.OK)
            {
                await Shell.Current.DisplayAlert("Alert", "wrong credentials!", "Ok");
                return;
            }
            Console.WriteLine(response);
            
            if (response is not null)
            {
                var serializeResponse = JsonSerializer.Serialize(
                    new LoginResponse() { AccessToken = response.AccessToken, RefreshToken = response.RefreshToken, UserName = model.Email });
                
                await Shell.Current.DisplayAlert("Alert", "burdsa", "Ok");
                Preferences.Default.Set("Authentication", serializeResponse);
                
            }
            await Shell.Current.DisplayAlert("Alert", "oldu kanka", "Ok");
        }
    }
}