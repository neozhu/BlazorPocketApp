using BlazorPocket.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using pocketbase_csharp_sdk;
using PocketBaseClient.BlazorPocket;
using System.Security.Claims;
using System.Text.Json;

namespace BlazorPocket.Shared.Services;


/// <summary>
/// Provides authentication state for the PocketBase application.
/// </summary>
public class PocketBaseAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly BlazorPocketApplication _pocketBase;
    private readonly IStorageService _localStorage;

    /// <summary>
    /// Initializes a new instance of the <see cref="PocketBaseAuthenticationStateProvider"/> class.
    /// </summary>
    /// <param name="pocketBase">The PocketBase application instance.</param>
    /// <param name="localStorage">The storage service for storing authentication token.</param>
    public PocketBaseAuthenticationStateProvider(BlazorPocketApplication pocketBase, IStorageService localStorage)
    {
        _pocketBase = pocketBase;
        _localStorage = localStorage;
        pocketBase.Auth.AuthStore.OnChange += AuthStore_OnChange;
    }

    private async void AuthStore_OnChange(object? sender, AuthStoreEvent e)
    {
        if (e is null || string.IsNullOrWhiteSpace(e.Token))
        {
            MarkUserAsLoggedOut();
        }
        else
        {
            try
            {
                await _localStorage.SetItemAsync("token", e.Token);
                var claims = ParseClaimsFromJwt(e.Token);
                MarkUserAsAuthenticated(claims);
            }
            catch { }
        }
    }

    /// <summary>
    /// Gets the authentication state asynchronously.
    /// </summary>
    /// <returns>The authentication state.</returns>
    public async override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var savedToken = await _localStorage.GetItemAsync<string?>("token");
            if (string.IsNullOrWhiteSpace(savedToken))
            {
                return new AuthenticationState(new ClaimsPrincipal());
            }

            var parsedClaims = ParseClaimsFromJwt(savedToken);
            var expires = parsedClaims.FirstOrDefault(c => c.Type == "exp");

            if (expires is null || IsTokenExpired())
            {
                return new AuthenticationState(new ClaimsPrincipal());
            }
            var userid = parsedClaims.First(x => x.Type == "id").Value;
            _pocketBase.Auth.AuthStore.Token = savedToken;
            await _pocketBase.Sdk.User.RefreshAsync();
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(savedToken), "jwt")));
        }
        catch
        {
            return new AuthenticationState(new ClaimsPrincipal());
        }
    }

    /// <summary>
    /// Marks the user as authenticated with the specified claims.
    /// </summary>
    /// <param name="claims">The claims of the authenticated user.</param>
    public void MarkUserAsAuthenticated(IEnumerable<Claim> claims)
    {
        var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(claims, "pocketbase"));
        var authState = Task.FromResult(new AuthenticationState(authenticatedUser));

        NotifyAuthenticationStateChanged(authState);
    }

    /// <summary>
    /// Marks the user as logged out.
    /// </summary>
    public async void MarkUserAsLoggedOut()
    {
        var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
        var authState = Task.FromResult(new AuthenticationState(anonymousUser));
        await _localStorage.RemoveItemAsync("token");
        NotifyAuthenticationStateChanged(authState);
    }

    /// <summary>
    /// Parses the claims from the JWT token.
    /// </summary>
    /// <param name="jwt">The JWT token.</param>
    /// <returns>The claims parsed from the JWT token.</returns>
    public static IEnumerable<Claim> ParseClaimsFromJwt(string? jwt)
    {
        if (string.IsNullOrWhiteSpace(jwt))
        {
            return Enumerable.Empty<Claim>();
        }

        var payload = jwt.Split(".")[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<IDictionary<string, object>>(jsonBytes);

        if (keyValuePairs is null)
        {
            return Enumerable.Empty<Claim>();
        }

        return keyValuePairs
            .Select(kvp => new Claim(kvp.Key, kvp.Value.ToString() ?? ""))
            .ToList();
    }

    /// <summary>
    /// Parses the base64 string without padding.
    /// </summary>
    /// <param name="base64">The base64 string.</param>
    /// <returns>The byte array parsed from the base64 string.</returns>
    public static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2:
                base64 += "==";
                break;
            case 3:
                base64 += "=";
                break;
        }
        return Convert.FromBase64String(base64);
    }

    private bool IsTokenExpired()
    {
        return _pocketBase.Auth.AuthStore.IsValid;
    }
}
