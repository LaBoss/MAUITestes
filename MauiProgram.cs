using Microsoft.Extensions.Logging;
using Prism.Navigation;

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
                    .OnAppStart((c, n) =>
                    {
                        return n.CreateBuilder().AddSegment("StartPage").NavigateAsync(HandleNavigationError);
                    });
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
        private static void HandleNavigationError(Exception ex)
        {
            Console.WriteLine(ex);
            System.Diagnostics.Debugger.Break();
        }
    }

}