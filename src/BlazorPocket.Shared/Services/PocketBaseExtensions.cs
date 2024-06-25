using PocketBaseClient.BlazorPocket.Models;
using PocketBaseClient.BlazorPocket;

namespace BlazorPocket.Shared.Services;


/// <summary>
/// Extension methods for the BlazorPocketApplication class.
/// </summary>
public static class PocketBaseExtensions
{
    /// <summary>
    /// Gets the current user.
    /// </summary>
    /// <param name="pocketBaseClient">The BlazorPocketApplication instance.</param>
    /// <returns>The current user if authenticated, otherwise null.</returns>
    public static User? GetCurrentUser(this BlazorPocketApplication pocketBaseClient)
    {
        if (pocketBaseClient.Auth.AuthStore.Model is not null && !string.IsNullOrWhiteSpace(pocketBaseClient.Auth.AuthStore.Model.Id))
        {
            return pocketBaseClient.Data.UsersCollection.GetById(pocketBaseClient.Auth.AuthStore.Model.Id);
        }
        return null;
    }

    /// <summary>
    /// Asynchronously gets the current user.
    /// </summary>
    /// <param name="pocketBaseClient">The BlazorPocketApplication instance.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the current user if authenticated, otherwise null.</returns>
    public static Task<User?> GetCurrentUserAsync(this BlazorPocketApplication pocketBaseClient)
    {
        if (pocketBaseClient.Auth.AuthStore.Model is not null && !string.IsNullOrWhiteSpace(pocketBaseClient.Auth.AuthStore.Model.Id))
        {
            return pocketBaseClient.Data.UsersCollection.GetByIdAsync(pocketBaseClient.Auth.AuthStore.Model.Id);
        }

        return null;
    }
}
