namespace UltricoGoogleCalendar.Model
{
    public class EventCreateModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool WholeDayEvent { get; set; }

        public ScheduleModel Schedule { get; set; }
    }
}