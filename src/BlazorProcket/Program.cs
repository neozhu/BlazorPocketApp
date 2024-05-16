using Blazored.LocalStorage;
using BlazorProcket.Client.Pages;
using BlazorProcket.Client.Services;
using BlazorProcket.Client.Services.UserPreferences;
using BlazorProcket.Components;
using MudBlazor;
using MudBlazor.Services;
using MudExtensions.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();


#region register MudBlazor.Services
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 10000;
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
builder.Services.AddMudPopoverService();
builder.Services.AddMudBlazorSnackbar();
builder.Services.AddMudBlazorDialog();
builder.Services.AddMudExtensions();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IUserPreferencesService, UserPreferencesService>();
builder.Services.AddScoped<LayoutService>();



#endregion




#region register EndpointsApi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    // enable SwaggerUI
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorProcket.Client._Imports).Assembly);

app.Run();
