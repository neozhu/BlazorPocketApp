using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorPocket.Client;
using BlazorPocket.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.TryAddMudBlazorWebAssembly(builder.Configuration);
builder.Services.TryAddProcketbaseWebAssembly(builder.Configuration);
builder.Services.TrAddAuthenticationWebAssembly();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
await builder.Build().RunAsync();
