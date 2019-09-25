using UltricoGoogleCalendar.DataLayer.Enums;

namespace UltricoGoogleCalendar.Model
{
    public class ScheduleModel
    {
        public ScheduleTypeEnum ScheduleType { get; set; }
        public WeeklyScheduleModel Weekly { get; set; }
        public MonthlyScheduleModel Monthly { get; set; }
        public AnnualScheduleModel Annually { get; set; }
        public DailyScheduleModel Daily { get; set; }
    }
}
