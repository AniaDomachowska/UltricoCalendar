using UltricoGoogleCalendar.DataLayer.Enums;
using UltricoGoogleCalendar.Model.Schedule;

namespace UltricoGoogleCalendar.Model
{
    public class ScheduleModel
    {
        public ScheduleTypeEnum ScheduleType { get; set; }
        public WeeklyScheduleModel Weekly { get; set; }
        public MonthlyScheduleModel Monthly { get; set; }
        public AnnualScheduleModel Annual { get; set; }
        public DailyScheduleModel Daily { get; set; }
    }
}
