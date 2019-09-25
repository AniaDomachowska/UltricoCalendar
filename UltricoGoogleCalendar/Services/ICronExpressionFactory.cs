using UltricoGoogleCalendar.Model;

namespace UltricoGoogleCalendar.Services
{
    public interface ICronExpressionFactory
    {
        CronResult Generate(ScheduleModel schedule);
    }
}