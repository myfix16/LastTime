using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using LastTime.Core.Models;
using LastTime.Core.Services;
using LastTime.Helpers;
using Windows.UI.Xaml.Controls;

namespace LastTime.ViewModels
{
    public class EventsDetailViewModel : ViewModelBase
    {
        private LastTimeEvent _item;
        private ICommand _itemDeletedCommand;

        public LastTimeEvent Item
        {
            get { return _item; }
            set { Set(ref _item, value); }
        }

        public ICommand ItemDeletedCommand => _itemDeletedCommand ??= new RelayCommand(OnItemDeleted);

        public EventsDetailViewModel()
        {
        }

        public ObservableCollection<AppBarButton> AppBarButtonList { get; }
            = new ObservableCollection<AppBarButton>
            {
                new AppBarButton { Icon = new SymbolIcon(Symbol.Add), Label="Add" },
                new AppBarButton { Icon = new SymbolIcon(Symbol.Delete), Label="Delete" },
            };

        public async Task InitializeAsync(string eventID)
        {
            var data = await EventsDataService.GetContentGridDataAsync();
            Item = data.First(i => i.ID == eventID);
        }

        private void OnItemDeleted()
        {
            throw new NotImplementedException();
            // TODO: 1. delete the item from the list
            // TODO: 2. Refresh the GridView
            // TODO: 3. navigate to the EventPage
        }
    }
}
