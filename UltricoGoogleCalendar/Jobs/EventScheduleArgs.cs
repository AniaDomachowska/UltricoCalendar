using UltricoGoogleCalendar.Model;

namespace UltricoGoogleCalendar.Jobs
{
    public class EventScheduleArgs
    {
        public EventResource Event { get; set; }
        public string Email { get; set; }
    }
}