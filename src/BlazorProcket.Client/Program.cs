using Blazored.LocalStorage;
using BlazorProcket.Client.Services.UserPreferences;
using BlazorProcket.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MudExtensions.Services;
using MudBlazor;
using BlazorProcket.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.TryAddMudBlazorUI(builder.Configuration);

await builder.Build().RunAsync();
