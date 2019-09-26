using System;
using System.Collections.Generic;
using UltricoGoogleCalendar.Model;

namespace UltricoGoogleCalendar.Services.OccurenceGenerator
{
    public interface IEventOccurenceGenerator
    {
        List<EventOccurenceResource> Generate(DateTime startDate, DateTime endDate);
    }
}