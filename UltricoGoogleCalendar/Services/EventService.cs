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

        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            this.eventRepository = eventRepository;
            this.mapper = mapper;
        }

        public void Create([FromBody]EventCreateModel createModel)
        {
            var eventEntity = mapper.Map<Event>(createModel);
            eventRepository.Add(eventEntity);
            eventRepository.Commit();
        }

        public void Update([FromBody]EventUpdateModel updateModel)
        {
            var eventEntity = mapper.Map<Event>(updateModel);
            eventRepository.Save(eventEntity);
            eventRepository.Commit();
        }

        public IEnumerable<EventResource> GetAll()
        {
            return eventRepository
                .GetAll()
                .Select(mapper.Map<EventResource>);
        }
    }
}