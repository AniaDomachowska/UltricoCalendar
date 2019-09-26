using System;

namespace UltricoGoogleCalendar.Model
{
    public class EventResource
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid? OccurenceId { get; set; }

        public ScheduleModel Schedule { get; set; }
    }
}