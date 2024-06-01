using System.Text.Json;
using hastane_otomasyon_maui_app.Models;

namespace hastane_otomasyon_maui_app.Services;


public interface IAuthService
{
    public bool IsAuthenticated();
    public Task<bool> LoginAsync(string username,  string password);
    public Task<bool> LogoutAsync();
    Task<bool> SaveMe();

}

public static class StorageKeys
{
    public const string AccessKey = "AccessKey";
    public const string RefreshKey = "RefreshKey";
    public const string IsAuthenticatedKey = "IsAuthenticated";
    public const string Me = "Me";
}

public class AuthService: IAuthService
{
    
    private readonly IClientService _clientService;

    public AuthService(IClientService clientService)
    {
        this._clientService=clientService;
    }
    

    public bool IsAuthenticated()
    {
        var authState = Preferences.Default.Get<bool>(StorageKeys.IsAuthenticatedKey, false);
        return authState;
    }
    public async Task<bool> LoginAsync(string email,  string password)
    {
        var response = new LoginResponse();
        try
        {
            response = await _clientService.Login(new LoginModel
            {
                Email = email,
                Password = password,
            });
        }
        catch (Exception e)
        {
            throw;
        }
        
        var serializeResponse = JsonSerializer.Serialize(
            new LoginResponse() { AccessToken = response.AccessToken, RefreshToken = response.RefreshToken, UserName = response.UserName });
        
        Preferences.Default.Set<bool>(StorageKeys.IsAuthenticatedKey, true);
        Preferences.Default.Set<string>(StorageKeys.AccessKey,response.AccessToken!);
        Preferences.Default.Set<string>(StorageKeys.RefreshKey,response.RefreshToken!);
        return true;
    }
    public Task<bool> LogoutAsync() 
    {
        Preferences.Default.Clear();
        return Task.FromResult(true);
    }

    public async Task<bool> SaveMe()
    {
        var memodel = await _clientService.GetMe();
        string memodelJson = JsonSerializer.Serialize(memodel);
        Preferences.Default.Set<string>(StorageKeys.Me, memodelJson);
        return true;
    }
}