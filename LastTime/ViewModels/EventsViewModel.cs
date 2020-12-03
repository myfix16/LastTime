using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

using LastTime.Core.Models;
using LastTime.Core.Services;
using LastTime.Helpers;
using LastTime.Services;
using LastTime.Views;

using Microsoft.Toolkit.Uwp.UI.Animations;
using Windows.UI.Xaml.Controls;

namespace LastTime.ViewModels
{
    public class EventsViewModel : ViewModelBase
    {
        private ICommand _itemClickCommand;

        public ICommand ItemClickCommand => _itemClickCommand ??= new RelayCommand<LastTimeEvent>(OnItemClick);

        public ObservableCollection<LastTimeEvent> Source { get; } = new ObservableCollection<LastTimeEvent>();

        public ObservableCollection<AppBarButton> AppBarButtonList { get; }
            = new ObservableCollection<AppBarButton>
            {
                new AppBarButton { Icon = new SymbolIcon(Symbol.Accept), Label="Accept" },
                new AppBarButton { Icon = new SymbolIcon(Symbol.Add), Label="Add" }
            };

        public EventsViewModel()
        {
        }

        public async Task LoadDataAsync()
        {
            Source.Clear();

            var data = await EventsDataService.GetContentGridDataAsync();
            foreach (var item in data)
            {
                Source.Add(item);
            }
        }

        public void AddTerm(LastTimeEvent lastTimeEvent)
        {
            Source.Add(lastTimeEvent);
        }

        private void OnItemClick(LastTimeEvent clickedItem)
        {
            if (clickedItem != null)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnimation(clickedItem);
                NavigationService.Navigate<EventsDetailPage>(clickedItem.ID);
            }
        }
    }
}
