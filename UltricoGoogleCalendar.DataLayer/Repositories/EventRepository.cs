using System;
using System.Collections.Generic;
using System.Linq;
using UltricoGoogleCalendar.DataLayer.Model;

namespace UltricoGoogleCalendar.DataLayer.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly DatabaseContext dbContext;

        public EventRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Event entity)
        {
            dbContext.Events.Add(entity);
        }

        public void Save(Event entity)
        {
            dbContext.Events.Update(entity);
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public Event GetOne(int id, Guid? occurenceId)
        {
            return dbContext.Events.FirstOrDefault(element =>
                element.Id == id && (occurenceId == null ||
                                     element.OccurenceId == occurenceId));
        }

        public IEnumerable<Event> GetAll()
        {
            return dbContext.Events.ToList();
        }
    }
}