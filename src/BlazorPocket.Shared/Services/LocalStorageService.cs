using Blazored.LocalStorage;
using BlazorPocket.Shared.Services.Interfaces;

namespace BlazorPocket.Shared.Services;

public class LocalStorageService : IStorageService
{
    private readonly ILocalStorageService _localStorageService;

    public LocalStorageService(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    public ValueTask<T?> GetItemAsync<T>(string key)
    {
        return _localStorageService.GetItemAsync<T>(key);
    }

    public ValueTask RemoveItemAsync(string key)
    {
        return _localStorageService.RemoveItemAsync(key);
    }

    public ValueTask SetItemAsync<T>(string key, T value)
    {
        return _localStorageService.SetItemAsync(key, value);
    }
}

