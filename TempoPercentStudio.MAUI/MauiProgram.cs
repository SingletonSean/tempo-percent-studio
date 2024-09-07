using Microsoft.Extensions.Logging;
using TempoPercentStudio.MAUI.Entities.PersonalBests;
using TempoPercentStudio.MAUI.Pages;
using TempoPercentStudio.MAUI.Shared.Database;

namespace TempoPercentStudio.MAUI
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
            builder.Services.AddSingleton<SqliteConnectionFactory>();

            builder.Services.AddSingleton<PersonalBestRepository>();

            builder.Services.AddSingleton<PersonalBestListingView>();
            builder.Services.AddSingleton<PersonalBestListingViewModel>();

            builder.Services.AddSingleton<AddPersonalBestView>();
            builder.Services.AddSingleton<AddPersonalBestViewModel>();

            return builder.Build();
        }
    }
}
