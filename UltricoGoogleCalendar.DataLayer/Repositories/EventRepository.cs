using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UltricoGoogleCalendar.DataLayer.Model;

namespace UltricoGoogleCalendar.DataLayer.Repositories
{
    public class EventRepository : IEventRepository
    {
        List<Event> eventList = new List<Event>();

        public void Add(Event entity)
        {
            eventList.Add(entity);
        }

        public void Save(Event entity)
        {
        }

        public IEnumerable<Event> GetAll()
        {
            return eventList;
        }
    }
}