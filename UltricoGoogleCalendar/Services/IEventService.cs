using System;
using System.Collections.Generic;
using UltricoGoogleCalendar.Model;

namespace UltricoGoogleCalendar.Services
{
    public interface IEventService
    {
        void Create(EventCreateModel createModel);
        void Update(int id, EventUpdateModel updateModel);
        IEnumerable<EventResource> GetAll();
        EventResource GetOne(int id, Guid? occurenceId);
        Guid? CreateOccurence(int id, EventUpdateModel model);
    }
}