using BlazorPocket.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using pocketbase_csharp_sdk;
using PocketBaseClient.BlazorPocket;
using System.Security.Claims;
using System.Text.Json;

namespace BlazorPocket.Shared.Services;

public class PocketBaseAuthenticationStateProvider : AuthenticationStateProvider
{

    private readonly BlazorPocketApplication _pocketBase;
    private readonly IStorageService _localStorage;

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

    public async override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var savedToken = await _localStorage.GetItemAsync("token");
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
            var usermodel = await _pocketBase.Data.UsersCollection.GetByIdAsync(userid);
            _pocketBase.Auth.AuthStore.Save(savedToken, usermodel);
            await _pocketBase.Sdk.User.RefreshAsync();
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(savedToken), "jwt")));
        }
        catch
        {
            return new AuthenticationState(new ClaimsPrincipal());
        }
    }

    public void MarkUserAsAuthenticated(IEnumerable<Claim> claims)
    {
        var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(claims, "pocketbase"));
        var authState = Task.FromResult(new AuthenticationState(authenticatedUser));

        NotifyAuthenticationStateChanged(authState);
    }

    public async void MarkUserAsLoggedOut()
    {
        var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
        var authState = Task.FromResult(new AuthenticationState(anonymousUser));
        await _localStorage.RemoveItemAsync("token");
        NotifyAuthenticationStateChanged(authState);
    }

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