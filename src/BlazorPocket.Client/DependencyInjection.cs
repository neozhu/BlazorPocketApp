using BlazorPocket.Client.Services.UserPreferences;
using BlazorPocket.Client.Services;
using MudBlazor.Services;
using MudExtensions.Services;
using MudBlazor;

using Blazored.LocalStorage;
using BlazorPocket.Client.Configurations;
using PocketBaseClient.BlazorPocket;
using Microsoft.AspNetCore.Components.Authorization;
namespace BlazorPocket.Client;

public static class DependencyInjection
{
    public static void TryAddMudBlazorServer(this IServiceCollection services, IConfiguration config)
    {
        #region register MudBlazor.Services
        services.AddMudServices(config =>
        {
            MudGlobal.InputDefaults.ShrinkLabel = true;
            config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;
            config.SnackbarConfiguration.NewestOnTop = false;
            config.SnackbarConfiguration.ShowCloseIcon = true;
            config.SnackbarConfiguration.VisibleStateDuration = 3000;
            config.SnackbarConfiguration.HideTransitionDuration = 500;
            config.SnackbarConfiguration.ShowTransitionDuration = 500;
            config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;

            // we're currently planning on deprecating `PreventDuplicates`, at least to the end dev. however,
            // we may end up wanting to instead set it as internal because the docs project relies on it
            // to ensure that the Snackbar always allows duplicates. disabling the warning for now because
            // the project is set to treat warnings as errors.
#pragma warning disable 0618
            config.SnackbarConfiguration.PreventDuplicates = false;
#pragma warning restore 0618
        });
        services.AddMudPopoverService();
        services.AddMudBlazorSnackbar();
        services.AddMudBlazorDialog();
        services.AddMudExtensions();
        services.AddBlazoredLocalStorage();
        services.AddScoped<IUserPreferencesService, UserPreferencesService>();
        services.AddScoped<LayoutService>();

        #endregion
    }
    public static void TryAddMudBlazorWebAssembly(this IServiceCollection services, IConfiguration config)
    {
        #region register MudBlazor.Services
        services.AddMudServices(config =>
        { 
            MudGlobal.InputDefaults.ShrinkLabel = true;
            config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;
            config.SnackbarConfiguration.NewestOnTop = false;
            config.SnackbarConfiguration.ShowCloseIcon = true;
            config.SnackbarConfiguration.VisibleStateDuration = 3000;
            config.SnackbarConfiguration.HideTransitionDuration = 500;
            config.SnackbarConfiguration.ShowTransitionDuration = 500;
            config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;

            // we're currently planning on deprecating `PreventDuplicates`, at least to the end dev. however,
            // we may end up wanting to instead set it as internal because the docs project relies on it
            // to ensure that the Snackbar always allows duplicates. disabling the warning for now because
            // the project is set to treat warnings as errors.
#pragma warning disable 0618
            config.SnackbarConfiguration.PreventDuplicates = false;
#pragma warning restore 0618
        });
        services.AddMudPopoverService();
        services.AddMudBlazorSnackbar();
        services.AddMudBlazorDialog();
        services.AddMudExtensions();
        services.AddBlazoredLocalStorageAsSingleton();
        services.AddSingleton<IUserPreferencesService, UserPreferencesService>();
        services.AddSingleton<LayoutService>();

        #endregion
    }

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

