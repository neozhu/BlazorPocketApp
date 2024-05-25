using Blazored.LocalStorage;
using BlazorPocket.Shared.Services.Interfaces;

namespace BlazorPocket.WebAssembly.MudBlazorTemplate.Services
{
    public class LocalStorageService : IStorageService
    {
        private readonly ILocalStorageService _localStorageService;

        public LocalStorageService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public ValueTask<string?> GetItemAsync(string key)
        {
            return _localStorageService.GetItemAsync<string?>(key);
        }

        public ValueTask RemoveItemAsync(string key)
        {
            return _localStorageService.RemoveItemAsync(key);
        }

        public ValueTask SetItemAsync(string key, string value)
        {
            return _localStorageService.SetItemAsync(key, value);
        }
    }
}
