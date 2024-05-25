using BlazorPocket.Shared.Configurations;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PocketBaseClient.BlazorPocket;
using PocketBaseClient.BlazorPocket.Models;

namespace BlazorPocket.Shared.Services;

public static class PocketBaseExtensions
{

    public static User? GetCurrentUser(this BlazorPocketApplication pocketBaseClient)
    {
        if (pocketBaseClient.Auth.AuthStore.Model is not null && !string.IsNullOrWhiteSpace(pocketBaseClient.Auth.AuthStore.Model.Id))
        {
            return pocketBaseClient.Data.UsersCollection.GetById(pocketBaseClient.Auth.AuthStore.Model.Id);
        }
        return null;
        
    }

    public static Task<User?> GetCurrentUserAsync(this BlazorPocketApplication pocketBaseClient)
    {
        if (pocketBaseClient.Auth.AuthStore.Model is not null && !string.IsNullOrWhiteSpace(pocketBaseClient.Auth.AuthStore.Model.Id))
        {
            return pocketBaseClient.Data.UsersCollection.GetByIdAsync(pocketBaseClient.Auth.AuthStore.Model.Id);
        }

        return null;
    }

}