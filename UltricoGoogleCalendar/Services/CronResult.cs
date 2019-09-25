using System;

namespace UltricoGoogleCalendar.Services
{
    public class CronResult
    {
        public string CronExpression { get; set; }
        public DateTime Starts { get; set; }
        public DateTime Ends { get; set; }
    }
}