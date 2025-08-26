using BlazorAppBreedsDogs.Services;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;

namespace BlazorAppBreedsDogs
{
    public static class MauiProgram
    {
        private const string apiKey = "4988b8203098eb4ddbeabac215934ce0";
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services
              .AddHttpClient<BreedsDogsServices>(client =>
              {
                  client.BaseAddress = new Uri("https://breeds-dogs-api-node.onrender.com/");
                  client.DefaultRequestHeaders.Add("x-api-key", apiKey);
              });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
