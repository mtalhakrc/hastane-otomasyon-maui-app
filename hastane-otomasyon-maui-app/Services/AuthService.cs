namespace hastane_otomasyon_maui_app.Services;


public interface IAuthService
{
    public Task<bool> IsAuthenticatedAsync();
    public Task<bool> Login(string username,  string password);
    public Task<bool> Logout();

}

public class AuthService: IAuthService
{
    private const string AuthStateKey = "AuthState";
    public async Task<bool> IsAuthenticatedAsync()
    {
        await Task.Delay(1000);

        var authState = Preferences.Default.Get<bool>(AuthStateKey, false);
        return authState;
    }
    public Task<bool> Login(string username,  string password)
    {
        Preferences.Default.Set<bool>(AuthStateKey, true);
        return Task.FromResult(true);
    }
    public Task<bool> Logout() 
    {
        Preferences.Default.Remove(AuthStateKey);
        return Task.FromResult(true);
    }
}