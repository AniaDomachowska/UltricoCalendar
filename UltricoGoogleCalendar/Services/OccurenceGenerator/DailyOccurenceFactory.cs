using System.Collections.Generic;
using UltricoGoogleCalendar.DataLayer.Model;
using UltricoGoogleCalendar.Model;

namespace UltricoGoogleCalendar.Services.OccurenceGenerator
{
    public class DailyOccurenceFactory : IOccurenceFactory
    {
        public IList<EventOccurenceResource> Create(Event eventResource, OccurenceFactoryParams parameters)
        {
            var result = new List<EventOccurenceResource>();

            for (int day = 0; day < (parameters.EndDate - parameters.StartDate).Days; day++)
            {
                result.Add(new EventOccurenceResource()
                {
                    Date = parameters.StartDate.AddDays(day)
                });
            }

            return result;
        }
    }
}