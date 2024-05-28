using hastane_otomasyon_maui_app.ViewModels;

namespace hastane_otomasyon_maui_app
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();
            BindingContext = mainPageViewModel;
        }

    }
}