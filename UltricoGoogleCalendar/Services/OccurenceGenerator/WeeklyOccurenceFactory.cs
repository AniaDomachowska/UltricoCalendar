using System;
using System.Collections.Generic;
using UltricoGoogleCalendar.DataLayer.Model;
using UltricoGoogleCalendar.Model;

namespace UltricoGoogleCalendar.Services.OccurenceGenerator
{
    public class WeeklyOccurenceFactory : IOccurenceFactory
    {

        public IList<EventOccurenceResource> Create(Event eventResource, OccurenceFactoryParams parameters)
        {
            var result = new List<EventOccurenceResource>();
            var schedule = eventResource.Schedule;

            for (var day = 0; day < (parameters.EndDate - parameters.StartDate).Days; day++)
            {
                var date = parameters.StartDate.AddDays(day);
                if (schedule.StartDateTime != null && date < schedule.StartDateTime || 
                    schedule.EndDateTime != null && date > schedule.EndDateTime)
                {
                    continue;
                }

                if (schedule.WeeklyEndsAfterNoOfOccurrences == 0)
                {
                    // TODO: Implement stopping if number of occurrences exceeded
                }

                var dayOfWeek = date.DayOfWeek;

                if (dayOfWeek == DayOfWeek.Monday && schedule.WeeklyRepeatOnMonday
                    || dayOfWeek == DayOfWeek.Tuesday && schedule.WeeklyRepeatOnTuesday
                    || dayOfWeek == DayOfWeek.Wednesday && schedule.WeeklyRepeatOnWednesday
                    || dayOfWeek == DayOfWeek.Thursday && schedule.WeeklyRepeatOnThursday
                    || dayOfWeek == DayOfWeek.Friday && schedule.WeeklyRepeatOnFriday
                    || dayOfWeek == DayOfWeek.Saturday && schedule.WeeklyRepeatOnSaturday
                    || dayOfWeek == DayOfWeek.Sunday && schedule.WeeklyRepeatOnSunday)
                {
                    result.Add(new EventOccurenceResource()
                    {
                        Date = date
                    });
                }
            }

            return result;
        }
    }
}