using System;

using LastTime.ViewModels;

using Windows.UI.Xaml.Controls;

namespace LastTime.Views
{
    public sealed partial class CalendarPage : Page
    {
        public CalendarViewModel ViewModel { get; } = new CalendarViewModel();

        public CalendarPage()
        {
            InitializeComponent();
        }
    }
}
