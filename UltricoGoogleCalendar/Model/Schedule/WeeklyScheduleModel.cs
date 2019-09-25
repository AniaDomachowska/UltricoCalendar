using System;
using System.Collections.Generic;

namespace UltricoGoogleCalendar.Model.Schedule
{
    public class WeeklyScheduleModel
    {
        public bool RepeatNumberOfWeeks { get; set; }
        public List<int> RepeatOn { get; set; }
        public DateTime StartDateTime { get; set; }
        public int EndsAfterNoOfOccurrences { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}