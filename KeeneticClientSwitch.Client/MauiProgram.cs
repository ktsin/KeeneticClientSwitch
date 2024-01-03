using CommunityToolkit.Maui;
using KeeneticClientSwitch.Client.ViewModels;
using KeeneticClientSwitch.Data.Services.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KeeneticClientSwitch.Client;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainPageViewModel>();
        
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<LoginPageViewModel>();
        
        builder.Services.AddHttpClient();

        builder.Services.AddDbContext<LocalContext>(options =>
        {
            var localPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var databaseFile = Path.Combine(localPath, "local.db");
            options.UseSqlite($"Filename={databaseFile}");
        });

        builder.Services.AddSingleton<ILoginPersistenceService, LoginPersistenceService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}