using UltricoGoogleCalendar.Model;

namespace UltricoGoogleCalendar.Services
{
    public interface IEventService
    {
        void Create(EventModel model);
        void Update(EventModel model);
    }
}