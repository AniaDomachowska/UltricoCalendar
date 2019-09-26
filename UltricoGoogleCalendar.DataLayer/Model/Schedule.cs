using System;
using System.Collections.Generic;
using UltricoGoogleCalendar.DataLayer.Enums;

namespace UltricoGoogleCalendar.DataLayer.Model
{
    public class Schedule : EntityBase
    {
        public ScheduleTypeEnum ScheduleType { get; set; }
        public DateTime DailyAtTime { get; set; }
        public int AnnualRepeatOnDay { get; set; }
        public int AnnualRepeatOnMonth { get; set; }
        public int MonthlyRepeatOnDay { get; set; }
        public bool WeeklyRepeatNumberOfWeeks { get; set; }

        // Split the repeating flag into week days for query performance.
        // (instead keeping it in string or other form that needs parsing)
        public bool WeeklyRepeatOnMonday { get; set; }
        public bool WeeklyRepeatOnTuesday { get; set; }
        public bool WeeklyRepeatOnWednesday { get; set; }
        public bool WeeklyRepeatOnThursday { get; set; }
        public bool WeeklyRepeatOnFriday { get; set; }
        public bool WeeklyRepeatOnSaturday { get; set; }
        public bool WeeklyRepeatOnSunday { get; set; }

        public int WeeklyEndsAfterNoOfOccurrences { get; set; }
        public DateTime? EndDateTime { get; set; }
        public DateTime? StartDateTime { get; set; }
    }
}
