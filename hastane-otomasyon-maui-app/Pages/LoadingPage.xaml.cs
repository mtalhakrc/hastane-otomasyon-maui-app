using hastane_otomasyon_maui_app.Services;
using hastane_otomasyon_maui_app.ViewModels;

namespace hastane_otomasyon_maui_app.Pages;

public partial class LoadingPage : ContentPage
{
    private LoadingPageViewModel _viewModel;
    public LoadingPage(LoadingPageViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
        this._viewModel = viewModel;

    }

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        if (this._viewModel.IsAuthenticated())
        {
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            return;
        }
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }
}