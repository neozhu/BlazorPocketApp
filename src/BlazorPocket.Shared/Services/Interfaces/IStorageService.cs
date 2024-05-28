using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPocket.Shared.Services.Interfaces;

public interface IStorageService
{
    ValueTask<string?> GetItemAsync(string key);
    ValueTask RemoveItemAsync(string key);
    ValueTask SetItemAsync(string key, string value);
}

