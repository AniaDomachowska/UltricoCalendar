using System;

namespace UltricoGoogleCalendar.Model
{
    public class EventUpdateModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ScheduleModel Schedule { get; set; }

        public bool EditSingleEvent { get; set; }
        public Guid? OccurenceId { get; set; }
    }
}