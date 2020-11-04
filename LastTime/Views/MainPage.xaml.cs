using System;

using LastTime.ViewModels;

using Windows.UI.Xaml.Controls;

namespace LastTime.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
