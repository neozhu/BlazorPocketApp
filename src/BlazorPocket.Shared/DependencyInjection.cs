using PocketBaseClient.BlazorPocket;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorPocket.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BlazorPocket.Shared.Configurations;
namespace BlazorPocket.Shared;

public static class DependencyInjection
{
 
    public static void TryAddProcketbaseServer(this IServiceCollection services,IConfiguration config)
    {
        var appSettings = new ApplicationSettings();
        config.GetSection(ApplicationSettings.KEY).Bind(appSettings);
        services.AddSingleton(appSettings);
        services.AddScoped(s => new BlazorPocketApplication(appSettings.PocketbaseUrl, appSettings.AppName));
    }
    public static void TryAddProcketbaseWebAssembly(this IServiceCollection services, IConfiguration config)
    {
   
        var appSettings= config.GetSection(ApplicationSettings.KEY).Get<ApplicationSettings>();
        services.AddSingleton(appSettings);
        services.AddSingleton(s => new BlazorPocketApplication(appSettings.PocketbaseUrl, appSettings.AppName));
    }

    public static void TrAddAuthenticationServer(this IServiceCollection services)
    {
        services.AddAuthorizationCore();
        services.AddCascadingAuthenticationState();
        services.AddScoped<AuthenticationStateProvider, PocketBaseAuthenticationStateProvider>();
    }
    public static void TrAddAuthenticationWebAssembly(this IServiceCollection services)
    {
        services.AddAuthorizationCore();
        services.AddCascadingAuthenticationState();
        services.AddSingleton<AuthenticationStateProvider, PocketBaseAuthenticationStateProvider>();
    }
}

