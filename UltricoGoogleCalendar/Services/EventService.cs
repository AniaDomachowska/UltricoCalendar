using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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

        public void Create(EventCreateModel createModel)
        {
            var eventEntity = mapper.Map<Event>(createModel);
            eventRepository.Add(eventEntity);
        }

        public void Update(EventUpdateModel createModel)
        {
            var eventEntity = mapper.Map<Event>(createModel);
            eventRepository.Save(eventEntity);
        }

        public IEnumerable<EventResource> GetAll()
        {
            return eventRepository
                .GetAll()
                .Select(mapper.Map<EventResource>);
        }
    }
}