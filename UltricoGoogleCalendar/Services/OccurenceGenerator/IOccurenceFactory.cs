using System.Collections.Generic;
using UltricoGoogleCalendar.DataLayer.Model;
using UltricoGoogleCalendar.Model;

namespace UltricoGoogleCalendar.Services.OccurenceGenerator
{
    public interface IOccurenceFactory
    {
        IList<EventOccurenceResource> Create(Event eventResource, OccurenceFactoryParams parameters);
    }
}