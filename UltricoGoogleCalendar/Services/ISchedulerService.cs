using UltricoGoogleCalendar.Model;

namespace UltricoGoogleCalendar.Services
{
    public interface ISchedulerService
    {
        void Schedule(EventResource model);
    }
}