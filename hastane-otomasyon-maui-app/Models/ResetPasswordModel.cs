namespace hastane_otomasyon_maui_app.Models;

public class ResetPasswordModel
{
    public string Email { get; set; }
    public string OldPassword{ get; set; }
    public string Password{ get; set; }
}