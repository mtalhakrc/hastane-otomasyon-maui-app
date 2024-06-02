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

    [ObservableProperty] private RandevuModel item;
    [ObservableProperty] private bool isCreate;
    public RandevuEditPageViewModel(IRandevuService randevuService)
    {
        _randevuService = randevuService;
    }
    
    [RelayCommand]

    private async Task EditRandevuAsync()
    {
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
        try
        {
            await _randevuService.CreateRandevuAsync(null);
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
