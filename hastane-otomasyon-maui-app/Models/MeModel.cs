namespace hastane_otomasyon_maui_app.Models;

public class MeModel
{
    public string ID { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public IList<string> Roles { get; set; }
}