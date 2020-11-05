using System;
using System.Linq;
using System.Threading.Tasks;

using LastTime.Core.Models;
using LastTime.Core.Services;
using LastTime.Helpers;

namespace LastTime.ViewModels
{
    public class EventsDetailViewModel : Observable
    {
        private SampleOrder _item;

        public SampleOrder Item
        {
            get { return _item; }
            set { Set(ref _item, value); }
        }

        public EventsDetailViewModel()
        {
        }

        public async Task InitializeAsync(long orderID)
        {
            var data = await SampleDataService.GetContentGridDataAsync();
            Item = data.First(i => i.OrderID == orderID);
        }
    }
}
