using System.Text.Json;
using hastane_otomasyon_maui_app.Models;

namespace hastane_otomasyon_maui_app.Services;


public interface IAuthService
{
    public bool IsAuthenticated();
    public Task<bool> LoginAsync(string username,  string password);
    public Task<bool> LogoutAsync();

}

public class AuthService: IAuthService
{
    private readonly IClientService _clientService;

    public AuthService(IClientService clientService)
    {
        this._clientService=clientService;
    }
    
    private const string AccessKey = "AccessKey";
    private const string RefreshKey = "RefreshKey";
    private const string IsAuthenticatedKey = "IsAuthenticated";
    public bool IsAuthenticated()
    {
        var authState = Preferences.Default.Get<bool>(IsAuthenticatedKey, false);
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
        
        Preferences.Default.Set<bool>(IsAuthenticatedKey, true);
        Preferences.Default.Set<string>(AccessKey,response.AccessToken!);
        Preferences.Default.Set<string>(RefreshKey,response.RefreshToken!);
        return true;
    }
    public Task<bool> LogoutAsync() 
    {
        Preferences.Default.Remove(AccessKey);
        Preferences.Default.Remove(RefreshKey);
        Preferences.Default.Remove(IsAuthenticatedKey);
        return Task.FromResult(true);
    }
}