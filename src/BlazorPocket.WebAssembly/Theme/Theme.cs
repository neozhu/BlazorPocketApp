using MudBlazor;

namespace BlazorPocket.WebAssembly;

/// <summary>
/// Represents the theme configuration for the application.
/// </summary>
public class Theme
{
    /// <summary>
    /// Gets the application theme.
    /// </summary>
    /// <returns>The application theme.</returns>
    public static MudTheme ApplicationTheme()
    {
        var theme = new MudTheme()
        {
            PaletteLight = new()
            {
                Primary = "#1E3A8A", // Deep blue, primary color for highlights and key elements
                Surface = "#FFF", // Light gray, for card surfaces or secondary backgrounds
                Background = "#f1f4f6", // White, main background color
                BackgroundGray = "#F9FAFB", // Very light gray, for subtle background areas
                AppbarText = "#1F2937", // Dark gray, text color for app bar
                AppbarBackground = "rgba(255,255,255,1)", // Semi-transparent white, background for app bar
                DrawerBackground = "#FFFFFF", // White, background for drawer
                ActionDefault = "#6B7280", // Gray, default action color
                //ActionDisabled = "#D1D5DB4D", // Semi-transparent gray, color for disabled actions
                ActionDisabledBackground = "#9CA3AF4D", // Semi-transparent gray, background for disabled actions
                TextPrimary = "#1F2937", // Dark gray, primary text color
                TextSecondary = "#4B5563", // Medium gray, secondary text color
                //TextDisabled = "#9CA3AF33", // Semi-transparent gray, disabled text color
                DrawerIcon = "#4B5563", // Medium gray, icon color for drawer
                DrawerText = "#4B5563", // Medium gray, text color for drawer
                GrayLight = "#E5E7EB", // Light gray, for light gray elements
                GrayLighter = "#F3F4F6", // Very light gray, for lighter gray elements
                Info = "#2563EB", // Blue, for informational messages
                Success = "#10B981", // Green, for success messages
                Warning = "#F59E0B", // Orange, for warning messages
                Error = "#EF4444", // Red, for error messages
                LinesDefault = "#D1D5DB", // Light gray, for default lines
                TableLines = "#D1D5DB", // Light gray, for table lines
                Divider = "#E5E7EB", // Light gray, for dividers
                OverlayLight = "#F3F4F680", // Semi-transparent light gray, for overlays

            },
            PaletteDark = new()
            {
                Primary = "#206bc4", // Brighter deep blue, primary color for highlights and key elements
                Surface = "#1C1C2E", // Dark gray, for card surfaces or secondary backgrounds
                Background = "#161625", // Dark gray, main background color
                BackgroundGray = "#11111A", // Very dark gray, for subtle background areas
                AppbarText = "#D1D5DB", // Light gray, text color for app bar
                AppbarBackground = "rgba(22,22,37,0.8)", // Semi-transparent dark gray, background for app bar
                DrawerBackground = "#161625", // Dark gray, background for drawer
                ActionDefault = "#A4B0C2", // Gray, default action color
                ActionDisabled = "#6B72804D", // Semi-transparent gray, color for disabled actions
                ActionDisabledBackground = "#4B55634D", // Semi-transparent gray, background for disabled actions
                TextPrimary = "#E5E7EB", // Light gray, primary text color
                TextSecondary = "#9CA3AF", // Medium gray, secondary text color
                TextDisabled = "#9CA3AF33", // Semi-transparent gray, disabled text color
                DrawerIcon = "#9CA3AF", // Medium gray, icon color for drawer
                DrawerText = "#9CA3AF", // Medium gray, text color for drawer
                GrayLight = "#1F2937", // Dark gray, for light gray elements
                GrayLighter = "#1C1C2E", // Dark gray, for lighter gray elements
                Info = "#4299e1", // Bright blue, for informational messages
                Success = "#10B981", // Green, for success messages
                Warning = "#F59E0B", // Orange, for warning messages
                Error = "#EF4444", // Red, for error messages
                LinesDefault = "#374151", // Dark gray, for default lines
                TableLines = "#374151", // Dark gray, for table lines
                Divider = "#4B5563", // Gray, for dividers
                OverlayLight = "#1C1C2E80", // Semi-transparent dark gray, for overlays
                Black = "#27272F", // Dark grayish black color
                Dark = "#0D0D0D", // Very dark gray, almost black
                DarkContrastText = "#FFFFFF", // White, contrast text for dark background
                DarkDarken = "#0B0B0B", // Slightly darker dark
                DarkLighten = "#262626", // Slightly lighter dark
                DividerLight = "#2D2D2D", // Light gray for dividers
                ErrorContrastText = "#FFFFFF", // White, contrast text for errors
                ErrorDarken = "#CC3737", // Darker red for errors
                ErrorLighten = "#FF6B6B", // Lighter red for errors
                GrayDark = "#1A1A1A", // Very dark gray
                GrayDarker = "#141414", // Even darker gray
                GrayDefault = "#1C1C1C", // Default gray
                HoverOpacity = 0.06, // Opacity for hover effects
                InfoContrastText = "#FFFFFF", // White, contrast text for info
                InfoDarken = "#1E4DB7", // Darker blue for info
                InfoLighten = "#4D8FF7", // Lighter blue for info
                LinesInputs = "#2B2B2B", // Gray for input lines
                OverlayDark = "#0F0F1F80", // Semi-transparent very dark gray
                PrimaryContrastText = "#FFFFFF", // White, contrast text for primary color
                PrimaryDarken = "#2A6FCC", // Darker blue for primary
                PrimaryLighten = "#669EFF", // Lighter blue for primary
                RippleOpacity = 0.1, // Opacity for ripple effect
                RippleOpacitySecondary = 0.2, // Higher opacity for secondary ripple effect
                Secondary = "#EC4899", // Pink, secondary color (using Colors.Pink.Accent2)
                SecondaryContrastText = "#FFFFFF", // White, contrast text for secondary color
                SecondaryDarken = "#B91C70", // Darker pink for secondary
                SecondaryLighten = "#FF70B3", // Lighter pink for secondary
                SuccessContrastText = "#FFFFFF", // White, contrast text for success
                SuccessDarken = "#0A865F", // Darker green for success
                SuccessLighten = "#33E0A3", // Lighter green for success
                TableHover = "#2C2C3A", // Dark gray for table hover
                TableStriped = "#24242E", // Slightly lighter dark gray for table stripes
                Tertiary = "#9333EA", // Purple, tertiary color
                TertiaryContrastText = "#FFFFFF", // White, contrast text for tertiary color
                TertiaryDarken = "#6B21A8", // Darker purple for tertiary
                TertiaryLighten = "#C084FC", // Lighter purple for tertiary
                WarningContrastText = "#000000", // Black, contrast text for warnings
                WarningDarken = "#C47D08", // Darker orange for warnings
                WarningLighten = "#FFB340", // Lighter orange for warnings
                White = "#FFFFFF" // White color
            },
            LayoutProperties = new()
            {
                DefaultBorderRadius = "4px",
                AppbarHeight = "68px",
            },
            ZIndex = new ZIndex(),
            Typography = new()
            {
                
                Default = new DefaultTypography
                {
                    FontSize = ".8125rem",
                    FontWeight = "400",
                    LineHeight = "1.4",
                    LetterSpacing = "normal",
                    FontFamily = new[] { "Public Sans", "Roboto", "Arial", "sans-serif" }
                },
                H1 = new H1Typography
                {
                    FontSize = "3.5rem",
                    FontWeight = "700",
                    LineHeight = "1.167",
                    LetterSpacing = "-.01562em"
                },
                H2 = new H2Typography
                {
                    FontSize = "3rem",
                    FontWeight = "300",
                    LineHeight = "1.2",
                    LetterSpacing = "-.00833em"
                },
                H3 = new H3Typography
                {
                    FontSize = "2rem",
                    FontWeight = "600",
                    LineHeight = "1.167",
                    LetterSpacing = "0"
                },
                H4 = new H4Typography
                {
                    FontSize = "1.5rem",
                    FontWeight = "400",
                    LineHeight = "1.235",
                    LetterSpacing = ".00735em"
                },
                H5 = new H5Typography
                {
                    FontSize = "1.25rem",
                    FontWeight = "400",
                    LineHeight = "1.3",
                    LetterSpacing = "0"
                },
                H6 = new H6Typography
                {
                    FontSize = "1.125rem",
                    FontWeight = "600",
                    LineHeight = "1.5",
                    LetterSpacing = ".0075em"
                },
                Button = new ButtonTypography
                {
                    FontSize = ".8125rem",
                    FontWeight = "500",
                    LineHeight = "1.75",
                    LetterSpacing = ".02857em",
                    TextTransform = "uppercase"
                },
                Subtitle1 = new Subtitle1Typography
                {
                    FontSize = "1rem",
                    FontWeight = "600",
                    LineHeight = "1.75",
                    LetterSpacing = ".00938em",
                    TextTransform = "none"
                },
                Subtitle2 = new Subtitle2Typography
                {
                    FontSize = ".875rem",
                    FontWeight = "500",
                    LineHeight = "1.57",
                    LetterSpacing = ".00714em"
                },
                Body1 = new Body1Typography
                {
                    FontSize = "0.875rem",
                    FontWeight = "400",
                    LineHeight = "1.5",
                    LetterSpacing = ".00938em"
                },
                Body2 = new Body2Typography
                {
                    FontSize = ".8125rem",
                    FontWeight = "400",
                    LineHeight = "1.43",
                    LetterSpacing = ".01071em"
                },
                Caption = new CaptionTypography
                {
                    FontSize = ".75rem",
                    FontWeight = "400",
                    LineHeight = "1.66",
                    LetterSpacing = ".03333em"
                },
                Overline = new OverlineTypography
                {
                    FontSize = ".75rem",
                    FontWeight = "400",
                    LineHeight = "2.5",
                    LetterSpacing = ".08333em"
                }
            }
        };
        return theme;
    }

}