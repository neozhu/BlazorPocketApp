using BlazorPocket.WebAssembly.Services.UserPreferences;
using MudBlazor;

namespace BlazorPocket.WebAssembly.Services;


/// <summary>
/// Represents a service that manages the layout and theme preferences of the application.
/// </summary>
public class LayoutService
{
    /// <summary>
    /// The service for managing user preferences.
    /// </summary>
    private readonly IUserPreferencesService _userPreferencesService;

    /// <summary>
    /// The user preferences.
    /// </summary>
    private UserPreferences.UserPreferences? _userPreferences;

    /// <summary>
    /// The system preferences for dark mode.
    /// </summary>
    private bool _systemPreferences;

    /// <summary>
    /// Gets or sets a value indicating whether the layout is right-to-left (RTL).
    /// </summary>
    public bool IsRTL { get; private set; }

    /// <summary>
    /// Gets or sets the current dark/light mode.
    /// </summary>
    public DarkLightMode CurrentDarkLightMode { get; private set; } = DarkLightMode.Light;

    /// <summary>
    /// Gets or sets a value indicating whether the application is in dark mode.
    /// </summary>
    public bool IsDarkMode { get; private set; }

    /// <summary>
    /// Gets or sets the current theme.
    /// </summary>
    public MudTheme CurrentTheme { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LayoutService"/> class.
    /// </summary>
    /// <param name="userPreferencesService">The user preferences service.</param>
    public LayoutService(IUserPreferencesService userPreferencesService)
    {
        _userPreferencesService = userPreferencesService ?? throw new ArgumentNullException(nameof(userPreferencesService));
        CurrentTheme = Theme.ApplicationTheme();
    }

    /// <summary>
    /// Sets the dark mode of the application.
    /// </summary>
    /// <param name="value">The value indicating whether dark mode is enabled.</param>
    public void SetDarkMode(bool value)
    {
        IsDarkMode = value;
        OnMajorUpdateOccurred();
    }

    /// <summary>
    /// Applies the user preferences to the layout.
    /// </summary>
    /// <param name="isDarkModeDefaultTheme">The value indicating whether dark mode is the default theme.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
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

    /// <summary>
    /// Handles the system preference change event.
    /// </summary>
    /// <param name="newValue">The new value of the system preference.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task OnSystemPreferenceChanged(bool newValue)
    {
        _systemPreferences = newValue;

        if (CurrentDarkLightMode == DarkLightMode.System)
        {
            IsDarkMode = newValue;
            OnMajorUpdateOccurred();
        }

        await Task.CompletedTask;
    }

    /// <summary>
    /// Event that is triggered when a major update occurs.
    /// </summary>
    public event EventHandler? MajorUpdateOccurred;

    /// <summary>
    /// Raises the MajorUpdateOccurred event.
    /// </summary>
    private void OnMajorUpdateOccurred() => MajorUpdateOccurred?.Invoke(this, EventArgs.Empty);

    /// <summary>
    /// Cycles through the dark/light mode options.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
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

        _userPreferences!.DarkLightTheme = CurrentDarkLightMode;
        await _userPreferencesService.SaveUserPreferences(_userPreferences);
        OnMajorUpdateOccurred();
    }

    /// <summary>
    /// Toggles the right-to-left (RTL) layout.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task ToggleRightToLeft()
    {
        IsRTL = !IsRTL;
        _userPreferences!.RightToLeft = IsRTL;
        await _userPreferencesService.SaveUserPreferences(_userPreferences);
        OnMajorUpdateOccurred();
    }

    /// <summary>
    /// Sets the base theme of the application.
    /// </summary>
    /// <param name="theme">The theme to set.</param>
    public void SetBaseTheme(MudTheme theme)
    {
        CurrentTheme = theme;
        OnMajorUpdateOccurred();
    }
}

