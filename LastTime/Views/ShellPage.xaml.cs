using System;
using LastTime.Core.Services;
using LastTime.Services;
using LastTime.ViewModels;
using Windows.ApplicationModel.Core;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using WinUI = Microsoft.UI.Xaml.Controls;

namespace LastTime.Views
{
    public sealed partial class ShellPage : Page
    {
        public ShellViewModel ViewModel { get; } = new ShellViewModel();

        public ShellPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel.Initialize(shellFrame, navigationView, KeyboardAccelerators);

            // Update title bar
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            ThemeSelectorService.ApplyThemeForTitleBarButtons(ElementTheme.Default, titleBar);
        }

        // TODO: MVVM here for keyboard accelerator.
        private void CtrlF_Invoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
            => searchBox.Focus(FocusState.Programmatic);

        // TODO: MVVM here for Header CommandBar.
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            // ! Bad experience.
        }
    }
}
