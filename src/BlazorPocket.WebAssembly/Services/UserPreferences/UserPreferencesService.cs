// Copyright (c) MudBlazor 2021
// MudBlazor licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Blazored.LocalStorage;
using BlazorPocket.Shared.Services.Interfaces;
using BlazorPocket.Shared.Services;
using System;
using System.Threading.Tasks;


namespace BlazorPocket.WebAssembly.Services.UserPreferences;
/// <summary>
/// Service for managing user preferences.
/// </summary>
public interface IUserPreferencesService
{
    /// <summary>
    /// Saves UserPreferences in local storage.
    /// </summary>
    /// <param name="userPreferences">The userPreferences to save in the local storage.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task SaveUserPreferences(UserPreferences userPreferences);

    /// <summary>
    /// Loads UserPreferences from local storage.
    /// </summary>
    /// <returns>UserPreferences object. Null when no settings were found.</returns>
    public Task<UserPreferences> LoadUserPreferences();
}


/// <summary>
/// Implementation of the IUserPreferencesService interface.
/// </summary>
public class UserPreferencesService : IUserPreferencesService
{
    private readonly IStorageService _localStorage;
    private const string Key = "userPreferences";

    /// <summary>
    /// Initializes a new instance of the <see cref="UserPreferencesService"/> class.
    /// </summary>
    /// <param name="localStorage">The storage service for accessing local storage.</param>
    public UserPreferencesService(IStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    /// <inheritdoc/>
    public async Task SaveUserPreferences(UserPreferences userPreferences)
    {
        await _localStorage.SetItemAsync(Key, userPreferences);
    }

    /// <inheritdoc/>
    public async Task<UserPreferences> LoadUserPreferences()
    {
        return await _localStorage.GetItemAsync<UserPreferences>(Key);
    }
}


