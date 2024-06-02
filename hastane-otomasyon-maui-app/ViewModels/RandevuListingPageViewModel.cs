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

    /*
    private async Task EditRandevuAsync(RandevuModel randevu)
    {
        try
        {
            await _randevuService.UpdateRandevuAsync(randevu);
            // Optionally, refresh the list or update the UI
        }
        catch (Exception ex)
        {
            // Handle error (e.g., display a message to the user)
        }
    }
    */

    // private async Task DeleteRandevuAsync(int id)
    // {
    //     try
    //     {
    //         await _randevuService.DeleteRandevuAsync(id);
    //         var randevuToRemove = Randevular.FirstOrDefault(r => r.Id == id);
    //         if (randevuToRemove != null)
    //         {
    //             Randevular.Remove(randevuToRemove);
    //         }
    //     }
    //     catch (Exception ex)
    //     {
    //         // Handle error (e.g., display a message to the user)
    //     }
    // }

    /*
    private async Task CreateRandevuAsync(RandevuModel randevu)
    {
        try
        {
            var newRandevu = await _randevuService.CreateRandevuAsync(randevu);
            Randevular.Add(newRandevu);
        }
        catch (Exception ex)
        {
            // Handle error (e.g., display a message to the user)
        }
    }*/
}