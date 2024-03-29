﻿using System;
using System.Collections.Generic;
using UltricoGoogleCalendar.DataLayer.Model;

namespace UltricoGoogleCalendar.DataLayer.Repositories
{
    public interface IEventRepository
    {
        void Add(Event entity);
        void Save(Event entity);
        IEnumerable<Event> GetAll();
        void Commit();
        Event GetOne(int id, Guid? occurenceId);
    }
}