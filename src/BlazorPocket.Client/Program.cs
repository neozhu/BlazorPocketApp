using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorPocket.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.TryAddMudBlazorServer(builder.Configuration);
builder.Services.TryAddProcketbaseServer(builder.Configuration);
builder.Services.TrAddAuthenticationServer();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
await builder.Build().RunAsync();
