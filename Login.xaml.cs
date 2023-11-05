namespace PrismBug;

public partial class Login : ContentPage
{
    private INavigationService _nav;

    public Login(INavigationService navigationService)
    {
        InitializeComponent();

        _nav = navigationService;
    }

    private async void OnLogin(object sender, EventArgs e)
    {
        await _nav.NavigateAsync("nav/MainPage");
    }
    private async void OnSettings(object sender, EventArgs e)
    {
        await _nav.NavigateAsync("Setting");

    }
}