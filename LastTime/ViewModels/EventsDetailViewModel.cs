using System;
using System.Linq;
using System.Threading.Tasks;

using LastTime.Core.Models;
using LastTime.Core.Services;
using LastTime.Helpers;

namespace LastTime.ViewModels
{
    public class EventsDetailViewModel : ViewModelBase
    {
        private LastTimeEvent _item;

        public LastTimeEvent Item
        {
            get { return _item; }
            set { Set(ref _item, value); }
        }

        public EventsDetailViewModel()
        {
        }

        public async Task InitializeAsync(string eventID)
        {
            var data = await EventsDataService.GetContentGridDataAsync();
            Item = data.First(i => i.ID == eventID);
        }
    }
}
