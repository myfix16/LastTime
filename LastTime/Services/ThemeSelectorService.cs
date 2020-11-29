using System;
using System.Threading.Tasks;

using LastTime.Helpers;

using Windows.ApplicationModel.Core;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace LastTime.Services
{
    public static class ThemeSelectorService
    {
        private const string SettingsKey = "AppBackgroundRequestedTheme";

        public static ElementTheme Theme { get; set; } = ElementTheme.Default;

        public static async Task InitializeAsync()
        {
            Theme = await LoadThemeFromSettingsAsync();
        }

        public static async Task SetThemeAsync(ElementTheme theme)
        {
            Theme = theme;

            await SetRequestedThemeAsync();
            await SaveThemeInSettingsAsync(Theme);
            //ApplyThemeForTitleBarButtons(theme);
        }

        public static async Task SetRequestedThemeAsync()
        {
            foreach (var view in CoreApplication.Views)
            {
                await view.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    if (Window.Current.Content is FrameworkElement frameworkElement)
                    {
                        frameworkElement.RequestedTheme = Theme;
                    }
                });
            }
        }

        private static async Task<ElementTheme> LoadThemeFromSettingsAsync()
        {
            ElementTheme cacheTheme = ElementTheme.Default;
            string themeName = await ApplicationData.Current.LocalSettings.ReadAsync<string>(SettingsKey);

            if (!string.IsNullOrEmpty(themeName))
            {
                Enum.TryParse(themeName, out cacheTheme);
            }

            return cacheTheme;
        }

        private static async Task SaveThemeInSettingsAsync(ElementTheme theme)
        {
            await ApplicationData.Current.LocalSettings.SaveAsync(SettingsKey, theme.ToString());
        }

        public static void ApplyThemeForTitleBarButtons(ElementTheme theme, ApplicationViewTitleBar titleBar = null)
        {
            titleBar ??= ApplicationView.GetForCurrentView().TitleBar;
            if (theme == ElementTheme.Default)
            {
                theme = (Application.Current.RequestedTheme == ApplicationTheme.Dark)
                        ? ElementTheme.Dark : ElementTheme.Light;
            }
            if (theme == ElementTheme.Dark)
            {
                // Set active window colors
                //titleBar.ButtonForegroundColor = Colors.White;
                //titleBar.ButtonHoverForegroundColor = Colors.White;
                //titleBar.ButtonHoverBackgroundColor = Color.FromArgb(255, 90, 90, 90);
                //titleBar.ButtonPressedForegroundColor = Colors.White;
                //titleBar.ButtonPressedBackgroundColor = Color.FromArgb(255, 120, 120, 120);

                //// Set inactive window colors
                //titleBar.InactiveForegroundColor = Colors.Gray;
                //titleBar.InactiveBackgroundColor = Colors.Transparent;
                //titleBar.ButtonInactiveForegroundColor = Colors.Gray;
                //titleBar.BackgroundColor = Color.FromArgb(255, 45, 45, 45);
                // Reset to use default colors.
                titleBar.ButtonBackgroundColor = null;
                titleBar.ButtonForegroundColor = null;
                titleBar.ButtonInactiveBackgroundColor = null;
                titleBar.ButtonInactiveForegroundColor = null;
                titleBar.ButtonHoverBackgroundColor = null;
                titleBar.ButtonHoverForegroundColor = null;
                titleBar.ButtonPressedBackgroundColor = null;
                titleBar.ButtonPressedForegroundColor = null;
            }
            else if (theme == ElementTheme.Light)
            {
                //// Set active window colors
                //titleBar.ButtonForegroundColor = Colors.Black;
                //titleBar.ButtonHoverForegroundColor = Colors.Black;
                //titleBar.ButtonHoverBackgroundColor = Color.FromArgb(255, 180, 180, 180);
                //titleBar.ButtonPressedForegroundColor = Colors.Black;
                //titleBar.ButtonPressedBackgroundColor = Color.FromArgb(255, 150, 150, 150);

                //// Set inactive window colors
                //titleBar.InactiveForegroundColor = Colors.DimGray;
                //titleBar.InactiveBackgroundColor = Colors.Transparent;
                //titleBar.ButtonInactiveForegroundColor = Colors.DimGray;
                //titleBar.BackgroundColor = Color.FromArgb(255, 210, 210, 210);
                // Reset to use default colors.
                titleBar.ButtonBackgroundColor = null;
                titleBar.ButtonForegroundColor = null;
                titleBar.ButtonInactiveBackgroundColor = null;
                titleBar.ButtonInactiveForegroundColor = null;
                titleBar.ButtonHoverBackgroundColor = null;
                titleBar.ButtonHoverForegroundColor = null;
                titleBar.ButtonPressedBackgroundColor = null;
                titleBar.ButtonPressedForegroundColor = null;
            }
        }
    }
}
