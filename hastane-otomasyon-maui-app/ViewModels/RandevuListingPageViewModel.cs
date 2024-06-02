using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using hastane_otomasyon_maui_app.Models;
using hastane_otomasyon_maui_app.Services;

namespace hastane_otomasyon_maui_app.ViewModels;

public partial class RandevuListingPageViewModel: ObservableObject
{
    private readonly IRandevuService _randevuService;


    public RandevuListingPageViewModel(IRandevuService randevuService)
    {
        _randevuService = randevuService;
    }
    
    public async Task<IEnumerable<RandevuModel>> LoadRandevularAsync()
    {
        IEnumerable<RandevuModel> randevularList = null;  
        try
        {
            randevularList = await _randevuService.GetAllRandevularAsync();
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Hata","Internal server error", "Tamam");
        }
        return randevularList;
    }
}