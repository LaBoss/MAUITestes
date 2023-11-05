using Microsoft.Extensions.Logging;

namespace PrismBug
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiApp<App>()
                .UsePrism((p) =>
                {
                    p.RegisterTypes(c =>
                    {
                        c.RegisterForNavigation<NavigationPage>("nav");
                        c.RegisterForNavigation<StartPage>();
                        c.RegisterForNavigation<Login>();
                        c.RegisterForNavigation<Setting>();
                        c.RegisterForNavigation<MainPage>();
                    })
                    .OnAppStart("StartPage");
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}