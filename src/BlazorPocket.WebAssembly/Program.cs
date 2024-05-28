using BlazorPocket.WebAssembly;
using BlazorPocket.Shared;
using BlazorPocket.WebAssembly;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.TryAddMudBlazorWebAssembly(builder.Configuration);
builder.Services.TryAddProcketbaseWebAssembly(builder.Configuration);
builder.Services.TrAddAuthenticationWebAssembly();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

await builder.Build().RunAsync();
