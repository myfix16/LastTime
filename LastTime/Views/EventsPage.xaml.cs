using System;

using LastTime.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace LastTime.Views
{
    public sealed partial class EventsPage : Page
    {
        public EventsViewModel ViewModel { get; } = new EventsViewModel();

        public EventsPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await ViewModel.LoadDataAsync();
        }
    }
}
