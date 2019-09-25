namespace UltricoGoogleCalendar.Model
{
    public class EventResource
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public ScheduleModel Schedule { get; set; }
    }
}