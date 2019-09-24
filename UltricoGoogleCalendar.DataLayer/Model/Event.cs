namespace UltricoGoogleCalendar.Model
{
    public class Event
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ScheduleBase Schedule { get; set; }
    }
}