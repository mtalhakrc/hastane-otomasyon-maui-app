using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using hastane_otomasyon_maui_app.Models;
using hastane_otomasyon_maui_app.ViewModels;

namespace hastane_otomasyon_maui_app.Pages;


public partial class RandevuEditPage : ContentPage
{
	
	public RandevuEditPage(RandevuEditPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
	
	private void OnSaveButtonClicked(object sender, EventArgs e)
	{
	}
	
	
}