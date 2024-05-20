using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorPocket.Client;
using BlazorPocket.Client.Configurations;
using System.Net.Http.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.TryAddMudBlazorWebAssembly(builder.Configuration);
builder.Services.TryAddProcketbaseWebAssembly(builder.Configuration);
builder.Services.TrAddAuthenticationWebAssembly();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
await builder.Build().RunAsync();
