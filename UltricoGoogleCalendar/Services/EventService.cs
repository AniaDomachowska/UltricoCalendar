using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UltricoGoogleCalendar.DataLayer.Model;
using UltricoGoogleCalendar.DataLayer.Repositories;
using UltricoGoogleCalendar.Model;

namespace UltricoGoogleCalendar.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository eventRepository;
        private readonly IMapper mapper;
        private readonly ISchedulerService schedulerService;

        public EventService(IEventRepository eventRepository, IMapper mapper, ISchedulerService schedulerService)
        {
            this.eventRepository = eventRepository;
            this.mapper = mapper;
            this.schedulerService = schedulerService;
        }

        public void Create([FromBody]EventCreateModel createModel)
        {
            var eventEntity = mapper.Map<Event>(createModel);
            eventRepository.Add(eventEntity);
            eventRepository.Commit();

            // schedulerService.Schedule(mapper.Map<EventResource>(createModel));
        }

        [Route("{id}")]
        public void Update(int id, EventUpdateModel updateModel)
        {
            var eventFromDb = eventRepository.GetOne(id, updateModel.OccurenceId);
            mapper.Map(updateModel, eventFromDb);
            eventRepository.Save(eventFromDb);
            eventRepository.Commit();
        }

        public IEnumerable<EventResource> GetAll()
        {
            return eventRepository
                .GetAll()
                .Select(mapper.Map<EventResource>);
        }

        public EventResource GetOne(int id, Guid? occurenceId)
        {
            var eventFromDb = eventRepository.GetOne(id, occurenceId);
            return mapper.Map<EventResource>(eventFromDb);
        }

        public Guid? CreateOccurence(int id, EventUpdateModel model)
        {
            var eventFromDb = eventRepository.GetOne(id, model.OccurenceId);
            mapper.Map(model, eventFromDb);

            // Create new occurence of event.
            eventFromDb.Id = 0;
            eventFromDb.OccurenceId = Guid.NewGuid();
            eventFromDb.ParentEvent = eventFromDb;

            eventRepository.Add(eventFromDb);
            eventRepository.Commit();

            return eventFromDb.OccurenceId;
        }
    }
}