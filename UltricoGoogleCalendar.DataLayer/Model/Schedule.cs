using System;
using System.Collections.Generic;
using UltricoGoogleCalendar.DataLayer.Enums;

namespace UltricoGoogleCalendar.DataLayer.Model
{
    public class Schedule
    {
        public ScheduleTypeEnum ScheduleType { get; set; }
        public DateTime DailyAtTime { get; set; }
        public int AnnualRepeatOnDay { get; set; }
        public int AnnualRepeatOnMonth { get; set; }
        public int MonthlyRepeatOnDay { get; set; }
        public bool RepeatNumberOfWeeks { get; set; }
        public List<int> WeeklyRepeatOn { get; set; }
        public DateTime WeeklyStartDateTime { get; set; }
        public int WeeklyEndsAfterNoOfOccurrences { get; set; }
        public DateTime WeeklyEndDateTime { get; set; }
    }
}
