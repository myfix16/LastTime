using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LastTime.Core.Models
{
    class LastTimeEvent
    {
        /// <summary>
        /// Name of the event.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The description of the event.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// A list of all last-done date in sequential order.
        /// </summary>
        public ObservableCollection<DateTime> LastTimes { get; set; }

        /// <summary>
        /// Get the day different between given date and today.
        /// </summary>
        /// <param name="date">The date to compare with today.</param>
        /// <returns>The day difference.</returns>
        public static int GetDayDifference(DateTime dateCreated, DateTime dateChecked) 
            => (dateChecked-dateCreated).Days;
    }
}
