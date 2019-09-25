﻿using System.Collections.Generic;
using UltricoGoogleCalendar.Model;

namespace UltricoGoogleCalendar.Services
{
    public interface IEventService
    {
        void Create(EventCreateModel createModel);
        void Update(EventUpdateModel updateModel);
        IEnumerable<EventResource> GetAll();
    }
}