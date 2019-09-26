using UltricoGoogleCalendar.Model;

namespace UltricoGoogleCalendar.Services
{
    public interface ICronExpressionFactory
    {
        CronResult Generate(ScheduleModel schedule);
    }

    public class CronExpressionFactory : ICronExpressionFactory
    {
        public CronResult Generate(ScheduleModel schedule)
        {
            // TODO: Implement cron expressions.
            return new CronResult();
        }
    }
}