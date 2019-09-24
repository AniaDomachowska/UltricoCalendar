using System;
using System.Collections.Generic;

namespace UltricoGoogleCalendar.Model
{
    public class WeeklyScheduleModel
    {
        public bool NumberOfWeeks { get; set; }
        public List<int> RepeatOn { get; set; }
        public DateTime StartDateTime { get; set; }
        public int EndsAfterNoOfOccurrences { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}