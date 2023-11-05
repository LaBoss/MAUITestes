namespace PrismBug;

public partial class StartPage : ContentPage
{
    private INavigationService _nav;

    public StartPage(INavigationService navigationService)
	{
		InitializeComponent();

        _nav = navigationService;
	}

    protected async override void OnAppearing()
    {
        await Task.Delay(1000);
        await _nav.NavigateAsync("Login");
    }
}