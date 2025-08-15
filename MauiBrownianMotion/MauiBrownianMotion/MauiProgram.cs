using CommunityToolkit.Maui;
using MauiBrownianMotion.Models;
using MauiBrownianMotion.ViewModels;
using Microsoft.Extensions.Logging;

namespace MauiBrownianMotion
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddSingleton<BrownianMotionModel>();
            builder.Services.AddSingleton<MainPage>(s => new MainPage(s.GetRequiredService<MainViewModel>()));
            return builder.Build();
        }
    }
}
