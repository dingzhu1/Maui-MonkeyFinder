using Maui_MonkeyFinder.Services;
using Maui_MonkeyFinder.View;
using Maui_MonkeyFinder.ViewModel;
using Microsoft.Extensions.Logging;

namespace Maui_MonkeyFinder
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
            builder.Services.AddSingleton<IMap>(Map.Default);

            builder.Services.AddSingleton<MonkeyService>();
            builder.Services.AddSingleton<MonkeysViewModel>();
            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddTransient<MonkeyDetailsViewModel>();
            builder.Services.AddTransient<DetailsPage>();

         

            return builder.Build();
        }
    }
}
