using Blazored.LocalStorage;
using BlazorPocket.Shared.Configurations;
using BlazorPocket.Shared.Services;
using BlazorPocket.Shared.Services.Interfaces;
using BlazorPocket.WebAssembly.DefaultTemplate.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PocketBaseClient.BlazorPocket;

namespace BlazorPocket.WebAssembly.DefaultTemplate
{
    public static class DependencyInjection
    {
        //public static void AddWebAssemlblyConfiguration(this IServiceCollection services, WebAssemblyHostConfiguration configuration)
        //{
        //    // Load configuration from appsettings.json in wwwroot
        //    configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        //}

        public static void AddStorage(this IServiceCollection services)
        {
            services.AddBlazoredLocalStorageAsSingleton();
            services.AddSingleton<IStorageService, LocalStorageService>();
        }

        //public static void AddPocketbaseWebAssembly(this IServiceCollection services, IConfiguration config)
        //{

        //    var appSettings = config.GetSection(ApplicationSettings.KEY).Get<ApplicationSettings>();
        //    appSettings ??= new ApplicationSettings();

        //    services.AddSingleton(appSettings);
        //    services.AddSingleton(s => new BlazorPocketApplication(appSettings.PocketbaseUrl, appSettings.AppName));
        //}

        //public static void AddBlazorPocketAuthenticationWebAssembly(this IServiceCollection services)
        //{
        //    services.AddAuthorizationCore();
        //    services.AddCascadingAuthenticationState();
        //    services.AddSingleton<AuthenticationStateProvider, PocketBaseAuthenticationStateProvider>();
        //}
    }
}
