using System;

using LastTime.ViewModels;
using Windows.ApplicationModel.Core;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using WinUI = Microsoft.UI.Xaml.Controls;

namespace LastTime.Views
{
    // TODO WTS: Change the icons and titles for all NavigationViewItems in ShellPage.xaml.
    public sealed partial class ShellPage : Page
    {
        public ShellViewModel ViewModel { get; } = new ShellViewModel();

        public ShellPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel.Initialize(shellFrame, navigationView, KeyboardAccelerators);

            // Extend NavigationView into title bar.
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;

            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;

            Window.Current.SetTitleBar(AppTitleBar);
            //CoreApplication.GetCurrentView().TitleBar.LayoutMetricsChanged += (s, e) => UpdateAppTitle(s);

            RegisterMessages();
        }

        private void RegisterMessages()
        {
            ViewModel.MsgManager.Register(
                this,
                "PaneChangedMessage",
                () => UpdateAppTitleMargin(),
                "");
            ViewModel.MsgManager.Register(
                this,
                "DisplayModeChangedMessage",
                () => NavigationView_DisplayModeChanged(),
                "");
        }

        /// <summary>
        /// Change the margin of title bar and header when display mode of navigation view is changed.
        /// </summary>
        private void NavigationView_DisplayModeChanged()
        {
            Thickness currMargin = AppTitleBar.Margin;

            AppTitleBar.Margin = navigationView.DisplayMode switch
            {
                WinUI.NavigationViewDisplayMode.Minimal
                    => new Thickness((navigationView.CompactPaneLength * 2), currMargin.Top, currMargin.Right, currMargin.Bottom),
                _ => new Thickness(navigationView.CompactPaneLength, currMargin.Top, currMargin.Right, currMargin.Bottom),
            };

            UpdateAppTitleMargin();
            //UpdateHeaderMargin(navigationView);
        }

        private void UpdateAppTitleMargin()
        {
            const int smallLeftIndent = 4, largeLeftIndent = 24;

            if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7))
            {
                AppTitle.TranslationTransition = new Vector3Transition();

                if ((navigationView.DisplayMode == WinUI.NavigationViewDisplayMode.Expanded && navigationView.IsPaneOpen) ||
                         navigationView.DisplayMode == WinUI.NavigationViewDisplayMode.Minimal)
                {
                    AppTitle.Translation = new System.Numerics.Vector3(smallLeftIndent, 0, 0);
                }
                else
                {
                    AppTitle.Translation = new System.Numerics.Vector3(largeLeftIndent, 0, 0);
                }
            }
            else
            {
                Thickness currMargin = AppTitle.Margin;

                if ((navigationView.DisplayMode == WinUI.NavigationViewDisplayMode.Expanded && navigationView.IsPaneOpen) ||
                         navigationView.DisplayMode == WinUI.NavigationViewDisplayMode.Minimal)
                {
                    AppTitle.Margin = new Thickness(smallLeftIndent, currMargin.Top, currMargin.Right, currMargin.Bottom);
                }
                else
                {
                    AppTitle.Margin = new Thickness(largeLeftIndent, currMargin.Top, currMargin.Right, currMargin.Bottom);
                }
            }
        }

        //private void UpdateHeaderMargin(Microsoft.UI.Xaml.Controls.NavigationView sender)
        //{
        //    if (PageHeader != null)
        //    {
        //        if (sender.DisplayMode == Microsoft.UI.Xaml.Controls.NavigationViewDisplayMode.Minimal)
        //        {
        //            Current.PageHeader.HeaderPadding = (Thickness)App.Current.Resources["PageHeaderMinimalPadding"];
        //        }
        //        else
        //        {
        //            Current.PageHeader.HeaderPadding = (Thickness)App.Current.Resources["PageHeaderDefaultPadding"];
        //        }
        //    }
        //}
    }
}
