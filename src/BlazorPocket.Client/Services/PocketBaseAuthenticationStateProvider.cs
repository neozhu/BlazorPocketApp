using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using pocketbase_csharp_sdk;
using PocketBaseClient.BlazorPocket;
using System.Security.Claims;
using System.Text.Json;

namespace BlazorPocket.Client.Services;

public class PocketBaseAuthenticationStateProvider : AuthenticationStateProvider
{

    private readonly BlazorPocketApplication _pocketBase;
    private readonly ILocalStorageService _localStorage;

    public PocketBaseAuthenticationStateProvider(BlazorPocketApplication pocketBase, ILocalStorageService localStorage)
    {
        this._pocketBase = pocketBase;
        this._localStorage = localStorage;

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

            await _localStorage.SetItemAsync<string>("token", e.Token);
            //await _localStorage.SetItemAsync<string>("Id", e.Model.Id); 

            var claims = ParseClaimsFromJwt(e.Token);
            MarkUserAsAuthenticated(claims);

        }

        //Debug.WriteLine(e.Token);
    }

    public async override Task<AuthenticationState> GetAuthenticationStateAsync()
    {

        var savedToken = await _localStorage.GetItemAsync<string>("token");

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

        _pocketBase.Auth.AuthStore.Save(savedToken, null);
        await _pocketBase.Auth.User.RefreshAsync();

        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(savedToken), "jwt")));
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

        //await _localStorage.ClearAsync();

        await _localStorage.RemoveItemAsync("Id");
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