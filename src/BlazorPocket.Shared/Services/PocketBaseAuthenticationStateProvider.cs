using BlazorPocket.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using pocketbase_csharp_sdk;
using pocketbase_csharp_sdk.Models;
using pocketbase_csharp_sdk.Models.Auth;
using PocketBaseClient.BlazorPocket;
using PocketBaseClient.BlazorPocket.Models;
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

                var parsedClaims = ParseClaimsFromJwt(e.Token);

                var userid = parsedClaims.First(x => x.Type == "id").Value;
                if (userid != null)
                {
                    User? userModel = await GetUserModelFromCacheOrPocketBaseAsync(userid);
                    
                    if (userModel != null)
                    {
                        parsedClaims.Add(new Claim(ClaimTypes.Name, !string.IsNullOrWhiteSpace(userModel.Name) ? userModel.Name : userModel.Email?.Address ?? string.Empty));
                        parsedClaims.Add(new Claim(ClaimTypes.Email, userModel.Email?.Address ?? string.Empty));
                    }
                }

                MarkUserAsAuthenticated(parsedClaims);
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
            if (userid != null)
            {
                _pocketBase.Auth.AuthStore.Token = savedToken;

                User? userModel = await GetUserModelFromCacheOrPocketBaseAsync(userid);
                _pocketBase.Auth.AuthStore.Save(savedToken, userModel);
                await _pocketBase.Sdk.User.RefreshAsync();

                if (userModel != null)
                {
                    parsedClaims.Add(new Claim(ClaimTypes.Name, !string.IsNullOrWhiteSpace(userModel.Name) ? userModel.Name : userModel.Email?.Address ?? string.Empty));
                    parsedClaims.Add(new Claim(ClaimTypes.Email, userModel.Email?.Address ?? string.Empty));
                }
            }
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(parsedClaims, "jwt")));
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
        await _localStorage.RemoveItemAsync("pocketbase_auth_usermodel");
        NotifyAuthenticationStateChanged(authState);
    }

    public static List<Claim> ParseClaimsFromJwt(string? jwt)
    {
        if (string.IsNullOrWhiteSpace(jwt))
        {
            return new List<Claim>();
        }

        var payload = jwt.Split(".")[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<IDictionary<string, object>>(jsonBytes);

        if (keyValuePairs is null)
        {
            return new List<Claim>();
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

    private async Task<User?> GetUserModelFromCacheOrPocketBaseAsync(string userid)
    {
        string? userModelString = await _localStorage.GetItemAsync("pocketbase_auth_usermodel");

        User? userModel = null;
        if (!string.IsNullOrWhiteSpace(userModelString))
            userModel = JsonSerializer.Deserialize<User?>(userModelString);

        if (userModel == null)
            userModel = await _pocketBase.Data.UsersCollection.GetByIdAsync(userid);

        if (userModel != null)
        {
            if (string.IsNullOrWhiteSpace(userModelString))
                await _localStorage.SetItemAsync("pocketbase_auth_usermodel", JsonSerializer.Serialize(userModel));
        }


        return userModel;
    }

}