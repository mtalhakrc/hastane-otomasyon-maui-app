using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hastane_otomasyon_maui_app.Models;
using hastane_otomasyon_maui_app.Services;

[QueryProperty("Item", "Item")]
[QueryProperty("IsCreate", "IsCreate")]


public partial class RandevuEditPageViewModel : ObservableObject
{
    private readonly IRandevuService _randevuService;
    [ObservableProperty] private UserModel _selectedDoktor;
    
    [ObservableProperty] private UserModel _selectedHasta;
    
    public class UserModel
    {
        public string ID { get; set; }
        public string Isim { get; set; }
    }
	
    public List<UserModel>Doktorlar { get; set; }
    public List<UserModel>Hastalar { get; set; }

    [ObservableProperty] private RandevuModel item;
    [ObservableProperty] private bool isCreate;
    public RandevuEditPageViewModel(IRandevuService randevuService)
    {
        _randevuService = randevuService;
        Doktorlar = new List<UserModel>();
        Doktorlar.Add(new UserModel(){ID = "91e9956e-1f24-48d6-9fee-01ca700b6657", Isim = "Ahmet Doktor Bey"});
        Doktorlar.Add(new UserModel(){ID = "91e9956e-1f24-48d6-9fee-01ca700b6660", Isim = "Talha Doktor Bey"});


        Hastalar = new List<UserModel>();
        Hastalar.Add(new UserModel(){ID = "91e9956e-1f24-48d6-9fee-01ca700b6670", Isim = "Ender Hasta Bey"});
        Hastalar.Add(new UserModel(){ID = "91e9956e-1f24-48d6-9fee-01ca700b6680", Isim = "Tayyip Hasta Bey"});
    }
    
    [RelayCommand]

    private async Task EditRandevuAsync()
    {
        Item.HastaID = SelectedHasta?.ID;
        Item.DoctorID = SelectedDoktor?.ID;
        try
        {
            await _randevuService.UpdateRandevuAsync(Item);
            await Shell.Current.DisplayAlert("Bilgilendirme","İşlem Başarılı", "Tamam");
            await Shell.Current.GoToAsync("..");
            return;

        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Hata","Internal server error", "Tamam");
            return;
        }
    }

    [RelayCommand]
    private async Task DeleteRandevuAsync(int id)
    {
        try
        {
            await _randevuService.DeleteRandevuAsync(id);
            await Shell.Current.DisplayAlert("Bilgilendirme","İşlem Başarılı", "Tamam");
            await Shell.Current.GoToAsync("..");
            return;

        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Hata","Internal server error", "Tamam");
        }
    }

    
    [RelayCommand]
    private async Task CreateRandevuAsync(RandevuModel randevu)
    {
        Item.HastaID = SelectedHasta?.ID;
        Item.DoctorID = SelectedDoktor?.ID;
        try
        {
            await _randevuService.CreateRandevuAsync(Item);
            await Shell.Current.DisplayAlert("Bilgilendirme","İşlem Başarılı", "Tamam");
            await Shell.Current.GoToAsync("..");
            return;

        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Hata","Internal server error", "Tamam");
        }
    }

}
