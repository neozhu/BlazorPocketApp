using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPocket.Shared.Services.Interfaces;

public interface IStorageService
{
    ValueTask<T?> GetItemAsync<T>(string key);
    ValueTask RemoveItemAsync(string key);
    ValueTask SetItemAsync<T>(string key, T value);
}

