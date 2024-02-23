using FormSubmitter.ViewModel;
using Microsoft.Extensions.Logging;

namespace FormSubmitter
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
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<FormPage>();
            builder.Services.AddSingleton<FormViewModel>();

            builder.Services.AddTransient<FormPage>();
            builder.Services.AddTransient<FormViewModel>();
            return builder.Build();
        }
    }
}
