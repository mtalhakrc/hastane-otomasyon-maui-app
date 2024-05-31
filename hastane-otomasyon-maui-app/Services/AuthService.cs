namespace hastane_otomasyon_maui_app.Services;

public class AuthService
{
    private const string AuthStateKey = "AuthState";
    public async Task<bool> IsAuthenticatedAsync()
    {
        await Task.Delay(2000);

        var authState = Preferences.Default.Get<bool>(AuthStateKey, false);
        Console.WriteLine("burası: ",authState);

        return authState;
    }
    public void Login()
    {
        Preferences.Default.Set<bool>(AuthStateKey, true);
    }
    public void Logout() 
    {
        Preferences.Default.Remove(AuthStateKey);
    }
}