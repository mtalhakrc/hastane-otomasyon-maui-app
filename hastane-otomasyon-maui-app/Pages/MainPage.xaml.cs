using hastane_otomasyon_maui_app.ViewModels;

namespace hastane_otomasyon_maui_app.Pages;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}

