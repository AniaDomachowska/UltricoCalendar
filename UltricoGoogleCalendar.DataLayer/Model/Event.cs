using System;

namespace UltricoGoogleCalendar.DataLayer.Model
{
    public class Event: EntityBase
    {
        public Event()
        {
            Schedule = new Schedule();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public bool WholeDayEvent { get; set; }
        public Schedule Schedule { get; set; }
        public Event ParentEvent { get; set; }
        public Guid OccurenceId { get; set; }
    }
}