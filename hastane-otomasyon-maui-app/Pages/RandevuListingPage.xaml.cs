using hastane_otomasyon_maui_app.Models;
using hastane_otomasyon_maui_app.ViewModels;

namespace hastane_otomasyon_maui_app.Pages;

public partial class RandevuListingPage : ContentPage
{
    private RandevuListingPageViewModel _viewmodel;
    private RandevuEditPageViewModel _randevuEditPageViewModel;

    public RandevuListingPage(RandevuListingPageViewModel viewmodel,RandevuEditPageViewModel randevuEditPageViewModel)
    {
        InitializeComponent();
        BindingContext = viewmodel;
        _viewmodel = viewmodel;
        _randevuEditPageViewModel = randevuEditPageViewModel;
    }
    
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var randevular = await _viewmodel.LoadRandevularAsync();
        CollectionView.ItemsSource = randevular;
    }

    async void OnItemAdded(object sender, EventArgs e)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "Item", new RandevuModel() },
            { "IsCreate", true }
        };
        await Shell.Current.GoToAsync(nameof(RandevuEditPage), navigationParameter);

    }

    async void OnListItemSelected(object sender, SelectionChangedEventArgs e)
    {
        var current = (e.CurrentSelection.FirstOrDefault() as RandevuModel);
        var navigationParameter = new Dictionary<string, object>
        {
            { "Item", current },
            { "IsCreate", false }
        };
        if (current != null)
        {
            await Shell.Current.GoToAsync(nameof(RandevuEditPage), navigationParameter);
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