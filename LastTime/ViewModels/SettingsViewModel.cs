using System;
using System.Threading.Tasks;
using System.Windows.Input;

using LastTime.Helpers;
using LastTime.Services;

using Windows.ApplicationModel;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace LastTime.ViewModels
{
    // TODO WTS: Add other settings as necessary. For help see https://github.com/Microsoft/WindowsTemplateStudio/blob/release/docs/UWP/pages/settings.md
    public class SettingsViewModel : Observable
    {
        private ElementTheme _elementTheme = ThemeSelectorService.Theme;

        public ElementTheme ElementTheme
        {
            get { return _elementTheme; }

            set { Set(ref _elementTheme, value); }
        }

        private string _versionDescription;

        public string VersionDescription
        {
            get { return _versionDescription; }

            set { Set(ref _versionDescription, value); }
        }

        private string _appDescription;

        public string AppDescription
        {
            get { return _appDescription; }
            set { Set(ref _appDescription, value); }
        }


        private ICommand _switchThemeCommand;

        public ICommand SwitchThemeCommand
        {
            get
            {
                if (_switchThemeCommand == null)
                {
                    _switchThemeCommand = new RelayCommand<ElementTheme>(
                        async (param) =>
                        {
                            ElementTheme = param;
                            await ThemeSelectorService.SetThemeAsync(param);

                            UpdateSystemCaptionButtonColors(param);
                        });
                }

                return _switchThemeCommand;
            }
        }

        public SettingsViewModel()
        {
        }

        public async Task InitializeAsync()
        {
            VersionDescription = GetVersionDescription();
            AppDescription = GetAppDescription();
            await Task.CompletedTask;
        }

        private string GetVersionDescription()
        {
            var appName = "AppDisplayName".GetLocalized();
            var package = Package.Current;
            var packageId = package.Id;
            var version = packageId.Version;

            return $"{appName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }

        private string GetAppDescription()
            => "\"When did I do last time?\" \"How long haven't I done this thing?\" " +
               "--This app will help you. It can record the last-done-time of one event " +
               "so that you can remember the last time soon.";

        public static void UpdateSystemCaptionButtonColors(ElementTheme param)
        {
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;

#pragma warning disable CS8509 // switch 表达式不会处理属于其输入类型的所有可能值(它并非详尽无遗)。
            titleBar.ButtonForegroundColor = param switch
            {
                ElementTheme.Light => Colors.Black,
                ElementTheme.Dark => Colors.White,
                ElementTheme.Default =>
                    (Application.Current.RequestedTheme == ApplicationTheme.Dark)
                        ? Colors.White : Colors.Black,
            };
#pragma warning restore CS8509 // switch 表达式不会处理属于其输入类型的所有可能值(它并非详尽无遗)。
        }
    }
}
