using System;
using System.Collections.ObjectModel;
using LastTime.Helpers;
using Windows.UI.Xaml.Controls;

namespace LastTime.ViewModels
{
    public class CalendarViewModel : Observable
    {
        public CalendarViewModel()
        {
        }

        public ObservableCollection<AppBarButton> AppBarButtonList { get; }
            = new ObservableCollection<AppBarButton>
            {
                new AppBarButton { Icon = new SymbolIcon(Symbol.Refresh), Label = "Refresh" }
            };
    }
}
