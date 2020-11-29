using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LastTime.Core.Models;

namespace LastTime.Core.Services
{
    public static class EventsDataService
    {
        private static IEnumerable<LastTimeEvent> _allEvents;

        private static IEnumerable<LastTimeEvent> AllEvents()
        {
            var events = new List<LastTimeEvent>
            {
                new LastTimeEvent
                {
                    Name="Bath",
                    Description="Take a bath",
                    LastTimes=new ObservableCollection<DateTime>
                    {
                        DateTime.Today,
                    }
                },
                new LastTimeEvent
                {
                    Name="Charge",
                    Description="Charge the wireless mouse",
                    LastTimes=new ObservableCollection<DateTime>
                    {
                        new DateTime(year:2020, month:11,day:4),
                    }
                },
                new LastTimeEvent
                {
                    Name="Learn",
                    Description="Learn linear algebra",
                    LastTimes=new ObservableCollection<DateTime>
                    {
                        new DateTime(year:2020, month:10,day:7),
                    }
                },
            };

            return events;
        }

        public static async Task<IEnumerable<LastTimeEvent>> GetContentGridDataAsync()
        {
            _allEvents ??= AllEvents();

            await Task.CompletedTask;
            return _allEvents.OrderByDescending(e => e.LastTimes.First());
        }
    }
}

