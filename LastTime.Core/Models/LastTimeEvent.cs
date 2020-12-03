using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LastTime.Core.Models
{
    public class LastTimeEvent
    {
        /// <summary>
        /// The unique ID of an event.
        /// </summary>
        public string ID { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// Name of the event.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The description of the event.
        /// </summary>
        public string Description { get; set; }
        public int SymbolCode { get; set; } = 57643;
        public char Symbol => (char)SymbolCode;
        public string DayDifference { get => $"{GetDayDifference(LastTimes[0])} days ago"; }
        /// <summary>
        /// A list of all last-done date in sequential order.
        /// </summary>
        public ObservableCollection<DateTime> LastTimes { get; set; }

        /// <summary>
        /// Get the day different between given date and today.
        /// </summary>
        /// <param name="date">The date to compare with today.</param>
        /// <returns>The day difference.</returns>
        public static int GetDayDifference(DateTime dateCreated)
            => (DateTime.Today - dateCreated).Days;
    }
}
