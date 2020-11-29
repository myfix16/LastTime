using System;

using LastTime.Services;
using LastTime.ViewModels;

using Microsoft.Toolkit.Uwp.UI.Animations;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace LastTime.Views
{
    public sealed partial class EventsDetailPage : Page
    {
        public EventsDetailViewModel ViewModel { get; } = new EventsDetailViewModel();

        public EventsDetailPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.RegisterElementForConnectedAnimation("animationKeyEvents", itemHero);
            if (e.Parameter is string eventID)
            {
                await ViewModel.InitializeAsync(eventID);
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (e.NavigationMode == NavigationMode.Back)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnimation(ViewModel.Item);
            }
        }
    }
}
