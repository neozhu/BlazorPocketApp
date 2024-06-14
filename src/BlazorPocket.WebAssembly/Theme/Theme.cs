using MudBlazor;

namespace BlazorPocket.WebAssembly;
public class Theme
{
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
            Shadows = new()
            {
                Elevation = new string[]
        {
            "none",
            "0 2px 4px -1px rgba(6, 24, 44, 0.2)",
            "0px 3px 1px -2px rgba(0,0,0,0.2),0px 2px 2px 0px rgba(0,0,0,0.14),0px 1px 5px 0px rgba(0,0,0,0.12)",
            "0 30px 60px rgba(0,0,0,0.12)",
            "0 6px 12px -2px rgba(50,50,93,0.25),0 3px 7px -3px rgba(0,0,0,0.3)",
            "0 50px 100px -20px rgba(50,50,93,0.25),0 30px 60px -30px rgba(0,0,0,0.3)",
            "0px 3px 5px -1px rgba(0,0,0,0.2),0px 6px 10px 0px rgba(0,0,0,0.14),0px 1px 18px 0px rgba(0,0,0,0.12)",
            "0px 4px 5px -2px rgba(0,0,0,0.2),0px 7px 10px 1px rgba(0,0,0,0.14),0px 2px 16px 1px rgba(0,0,0,0.12)",
            "0px 5px 5px -3px rgba(0,0,0,0.2),0px 8px 10px 1px rgba(0,0,0,0.14),0px 3px 14px 2px rgba(0,0,0,0.12)",
            "0px 5px 6px -3px rgba(0,0,0,0.2),0px 9px 12px 1px rgba(0,0,0,0.14),0px 3px 16px 2px rgba(0,0,0,0.12)",
            "0px 6px 6px -3px rgba(0,0,0,0.2),0px 10px 14px 1px rgba(0,0,0,0.14),0px 4px 18px 3px rgba(0,0,0,0.12)",
            "0px 6px 7px -4px rgba(0,0,0,0.2),0px 11px 15px 1px rgba(0,0,0,0.14),0px 4px 20px 3px rgba(0,0,0,0.12)",
            "0px 7px 8px -4px rgba(0,0,0,0.2),0px 12px 17px 2px rgba(0,0,0,0.14),0px 5px 22px 4px rgba(0,0,0,0.12)",
            "0px 7px 8px -4px rgba(0,0,0,0.2),0px 13px 19px 2px rgba(0,0,0,0.14),0px 5px 24px 4px rgba(0,0,0,0.12)",
            "0px 7px 9px -4px rgba(0,0,0,0.2),0px 14px 21px 2px rgba(0,0,0,0.14),0px 5px 26px 4px rgba(0,0,0,0.12)",
            "0px 8px 9px -5px rgba(0,0,0,0.2),0px 15px 22px 2px rgba(0,0,0,0.14),0px 6px 28px 5px rgba(0,0,0,0.12)",
            "0px 8px 10px -5px rgba(0,0,0,0.2),0px 16px 24px 2px rgba(0,0,0,0.14),0px 6px 30px 5px rgba(0,0,0,0.12)",
            "0px 8px 11px -5px rgba(0,0,0,0.2),0px 17px 26px 2px rgba(0,0,0,0.14),0px 6px 32px 5px rgba(0,0,0,0.12)",
            "0px 9px 11px -5px rgba(0,0,0,0.2),0px 18px 28px 2px rgba(0,0,0,0.14),0px 7px 34px 6px rgba(0,0,0,0.12)",
            "0px 9px 12px -6px rgba(0,0,0,0.2),0px 19px 29px 2px rgba(0,0,0,0.14),0px 7px 36px 6px rgba(0,0,0,0.12)",
            "0px 10px 13px -6px rgba(0,0,0,0.2),0px 20px 31px 3px rgba(0,0,0,0.14),0px 8px 38px 7px rgba(0,0,0,0.12)",
            "0px 10px 13px -6px rgba(0,0,0,0.2),0px 21px 33px 3px rgba(0,0,0,0.14),0px 8px 40px 7px rgba(0,0,0,0.12)",
            "0px 10px 14px -6px rgba(0,0,0,0.2),0px 22px 35px 3px rgba(0,0,0,0.14),0px 8px 42px 7px rgba(0,0,0,0.12)",
            "0 50px 100px -20px rgba(50, 50, 93, 0.25), 0 30px 60px -30px rgba(0, 0, 0, 0.30)",
            "2.8px 2.8px 2.2px rgba(0, 0, 0, 0.02),6.7px 6.7px 5.3px rgba(0, 0, 0, 0.028),12.5px 12.5px 10px rgba(0, 0, 0, 0.035),22.3px 22.3px 17.9px rgba(0, 0, 0, 0.042),41.8px 41.8px 33.4px rgba(0, 0, 0, 0.05),100px 100px 80px rgba(0, 0, 0, 0.07)",
            "0px 0px 20px 0px rgba(0, 0, 0, 0.05)"
        }
            },
            LayoutProperties = new()
            {
                DefaultBorderRadius = "4px",
                AppbarHeight = "68px",
            },
            ZIndex = new ZIndex(),
            Typography = new()
            {
                Default = new Default()
                {
                    FontFamily = new[] { "Public Sans", "Roboto", "Arial", "sans-serif" },
                    LetterSpacing = "normal",
                    FontSize = ".75rem"
                },
                H1 = new H1()
                {
                    FontSize = "3rem",
                    FontWeight = 700,
                },
                H2 = new H2()
                {
                    FontSize = "2.4rem",
                    FontWeight = 700,
                },
                H3 = new H3()
                {
                    FontSize = "2rem",
                    FontWeight = 600,
                    LineHeight = 1.8,
                },
                H4 = new H4()
                {
                    FontSize = "1.6rem",
                    FontWeight = 700,
                },
                H5 = new H5()
                {
                    FontSize = "1.35rem",
                    FontWeight = 700,
                    LineHeight = 1.5,
                },
                H6 = new H6()
                {
                    FontSize = "1.125rem",
                    FontWeight = 700,
                    LineHeight = 1.5,
                },
                Subtitle1 = new Subtitle1()
                {
                    FontSize = ".75rem",
                    FontWeight = 500
                },
                Subtitle2 = new Subtitle2()
                {
                    FontSize = ".725rem",
                    FontWeight = 600,
                    LineHeight = 1.8,
                },
                Body1 = new Body1()
                {
                    FontSize = ".75rem",
                    FontWeight = 400
                },
                Body2 = new Body2()
                {
                    FontSize = ".725rem",
                    FontWeight = 400,
                },
                Button = new Button()
                {
                    TextTransform = "none",
                    FontSize = ".75rem",
                },
                Input = new Input()
                {
                    FontSize = ".75rem",
                }
            }
        };
        return theme;
    }

}