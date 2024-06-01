
using System.Net;
using System.Net.Http.Headers;
using hastane_otomasyon_maui_app.Models;
using System.Net.Http.Json;
using System.Text.Json;
using hastane_otomasyon_maui_app.Services;


public interface IClientService
{
    Task Register(RegisterModel model);
    Task<LoginResponse> Login(LoginModel model);
    Task<MeModel> GetMe();
}

namespace hastane_otomasyon_maui_app.Services
{
    public class ClientService: IClientService
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

        public async Task<LoginResponse> Login(LoginModel model)
        {
            var httpClient = _httpClientFactory.CreateClient("custom-httpclient");
            var result = await httpClient.PostAsJsonAsync("/login", model);
            if (result.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new Exception("wrong credentials");
            }

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("an error occured");
            }
            var response = await result.Content.ReadFromJsonAsync<LoginResponse>();
            if (response is null)
            {
                throw new Exception("internal server error");
            }
            return response;
        }

        public async Task<MeModel> GetMe()
        {
            var httpClient = _httpClientFactory.CreateClient("custom-httpclient");
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Preferences.Default.Get(StorageKeys.AccessKey,""));
            
            var result = await httpClient.GetAsync("/api/User/me");
            if (result.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new Exception("wrong credentials");
            }

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("an error occured");
            }
            var response = await result.Content.ReadFromJsonAsync<MeModel>();
            if (response is null)
            {
                throw new Exception("internal server error");
            }
            return response;
        }
        
    }
}