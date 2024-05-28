using PocketBaseClient.BlazorPocket.Models;
using PocketBaseClient.BlazorPocket;

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