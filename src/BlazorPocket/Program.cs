using Blazored.LocalStorage;
using BlazorPocket.Client;
using BlazorPocket.Client.Pages;
using BlazorPocket.Client.Services;
using BlazorPocket.Client.Services.UserPreferences;
using BlazorPocket.Components;
using MudBlazor;
using MudBlazor.Services;
using MudExtensions.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();




builder.Services.TryAddMudBlazorUI(builder.Configuration);
builder.Services.TryAddProcketbase(builder.Configuration);



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
    .AddAdditionalAssemblies(typeof(BlazorPocket.Client._Imports).Assembly);

app.Run();
