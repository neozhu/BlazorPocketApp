using BlazorPocket.Client.Services.UserPreferences;
using MudBlazor;

namespace BlazorPocket.Client.Services;

public class LayoutService
{
    private readonly IUserPreferencesService _userPreferencesService;
    private UserPreferences.UserPreferences _userPreferences;
    private bool _systemPreferences;

    public bool IsRTL { get; private set; }
    public DarkLightMode CurrentDarkLightMode { get; private set; } = DarkLightMode.Light;

    public bool IsDarkMode { get; private set; }

    public MudTheme CurrentTheme { get; private set; }

    public LayoutService(IUserPreferencesService userPreferencesService)
    {
        CurrentTheme = Theme.ApplicationTheme();
        _userPreferencesService = userPreferencesService;
        
    }

    public void SetDarkMode(bool value)
    {
        IsDarkMode = value;
        OnMajorUpdateOccurred();
    }

    public async Task ApplyUserPreferences(bool isDarkModeDefaultTheme)
    {
        _systemPreferences = isDarkModeDefaultTheme;

        _userPreferences = await _userPreferencesService.LoadUserPreferences();

        if (_userPreferences != null)
        {
            CurrentDarkLightMode = _userPreferences.DarkLightTheme;
            IsDarkMode = CurrentDarkLightMode switch
            {
                DarkLightMode.Dark => true,
                DarkLightMode.Light => false,
                DarkLightMode.System => isDarkModeDefaultTheme,
                _ => IsDarkMode
            };

            IsRTL = _userPreferences.RightToLeft;
        }
        else
        {
            IsDarkMode = isDarkModeDefaultTheme;
            _userPreferences = new UserPreferences.UserPreferences { DarkLightTheme = DarkLightMode.System };
            await _userPreferencesService.SaveUserPreferences(_userPreferences);
        }
    }

    public Task OnSystemPreferenceChanged(bool newValue)
    {
        _systemPreferences = newValue;

        if (CurrentDarkLightMode == DarkLightMode.System)
        {
            IsDarkMode = newValue;
            OnMajorUpdateOccurred();
        }

        return Task.CompletedTask;
    }

    public event EventHandler MajorUpdateOccurred;

    private void OnMajorUpdateOccurred() => MajorUpdateOccurred?.Invoke(this, EventArgs.Empty);

    public async Task CycleDarkLightModeAsync()
    {
        switch (CurrentDarkLightMode)
        {
            case DarkLightMode.System:
                CurrentDarkLightMode = DarkLightMode.Light;
                IsDarkMode = false;
                break;
            case DarkLightMode.Light:
                CurrentDarkLightMode = DarkLightMode.Dark;
                IsDarkMode = true;
                break;
            case DarkLightMode.Dark:
                CurrentDarkLightMode = DarkLightMode.System;
                IsDarkMode = _systemPreferences;
                break;
        }

        _userPreferences.DarkLightTheme = CurrentDarkLightMode;
        await _userPreferencesService.SaveUserPreferences(_userPreferences);
        OnMajorUpdateOccurred();
    }

    public async Task ToggleRightToLeft()
    {
        IsRTL = !IsRTL;
        _userPreferences.RightToLeft = IsRTL;
        await _userPreferencesService.SaveUserPreferences(_userPreferences);
        OnMajorUpdateOccurred();
    }

    public void SetBaseTheme(MudTheme theme)
    {
        CurrentTheme = theme;
        OnMajorUpdateOccurred();
    }

   
}

