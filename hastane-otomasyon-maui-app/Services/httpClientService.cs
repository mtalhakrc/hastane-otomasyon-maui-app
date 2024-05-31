
using System.Net;
using System.Net.Http.Headers;
using hastane_otomasyon_maui_app.Models;
using System.Net.Http.Json;
using System.Text.Json;


public interface IClientService
{
    Task Register(RegisterModel model);
    Task<LoginResponse> Login(LoginModel model);
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
            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("wrong credentials");
            }
            var response = await result.Content.ReadFromJsonAsync<LoginResponse>();
            if (response is null)
            {
                throw new Exception("internal server error");
            }
            return response;
        }
    }
}