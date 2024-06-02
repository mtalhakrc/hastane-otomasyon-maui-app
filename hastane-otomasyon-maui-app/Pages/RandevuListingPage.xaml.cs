using hastane_otomasyon_maui_app.Models;
using hastane_otomasyon_maui_app.ViewModels;

namespace hastane_otomasyon_maui_app.Pages;

public partial class RandevuListingPage : ContentPage
{
    private RandevuListingPageViewModel _viewmodel;

    public RandevuListingPage(RandevuListingPageViewModel viewmodel)
    {
        InitializeComponent();
        BindingContext = viewmodel;
        _viewmodel = viewmodel;
    }
    
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var randevular  = await _viewmodel.LoadRandevularAsync();
        ListView.ItemsSource = randevular;
    }

    async void OnItemAdded(object sender, EventArgs e)
    {
        // Handle the logic for adding a new appointment
        var newRandevu = new RandevuModel
        {
            Isim = "New Appointment",
            Tarih = DateTime.Now,
            DoctorID = "1",
            HastaID = "1"
        };
        
        //await _viewmodel.CreateRandevuCommand.ExecuteAsync(newRandevu);
    }

    async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is RandevuModel selectedRandevu)
        {
            // Navigate to an edit page or perform any desired action with the selected item
            //await _viewmodel.EditRandevuCommand.ExecuteAsync(selectedRandevu);
        }
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        if (menuItem?.CommandParameter is RandevuModel randevu)
        {
            //await _viewmodel.DeleteRandevuCommand.ExecuteAsync(randevu.Id);
        }
    }
}