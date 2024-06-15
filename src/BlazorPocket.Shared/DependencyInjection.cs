using PocketBaseClient.BlazorPocket;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorPocket.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BlazorPocket.Shared.Configurations;
namespace BlazorPocket.Shared;

public static class DependencyInjection
{
 
    public static void TryAddProcketbase(this IServiceCollection services, IConfiguration config)
    {
        var appSettings= config.GetSection(ApplicationSettings.KEY).Get<ApplicationSettings>();
        services.AddSingleton(appSettings);
        services.AddSingleton(s => new BlazorPocketApplication(appSettings.PocketbaseUrl, appSettings.AppName));
    }
    public static void TrAddAuthentication(this IServiceCollection services)
    {
        services.AddAuthorizationCore();
        services.AddCascadingAuthenticationState();
        services.AddSingleton<AuthenticationStateProvider, PocketBaseAuthenticationStateProvider>();
    }
}

