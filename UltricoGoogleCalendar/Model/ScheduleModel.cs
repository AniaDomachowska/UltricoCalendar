namespace UltricoGoogleCalendar.Model
{
    public class ScheduleModel
    {
        public ScheduleTypeEnum ScheduleType { get; set; }
        public WeeklyScheduleModel Weekly { get; set; }
        public MonthlyScheduleModel Monthly { get; set; }
        public AnnuallyScheduleModel Annually { get; set; }
    }
}
