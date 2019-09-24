using AutoMapper;
using UltricoGoogleCalendar.DataLayer.Repositories;
using UltricoGoogleCalendar.Model;
using Model_Event = UltricoGoogleCalendar.Model.EventModel;

namespace UltricoGoogleCalendar.Services
{
    public class EventService : IEventService
    {
        private readonly EventRepository eventRepository;
        private readonly IMapper mapper;

        public EventService(EventRepository eventRepository, IMapper mapper)
        {
            this.eventRepository = eventRepository;
            this.mapper = mapper;
        }

        public void Create(Model_Event model)
        {
            var eventEntity = mapper.Map<Event>(model);
            eventRepository.Add(eventEntity);
        }

        public void Update(Model_Event model)
        {
            var eventEntity = mapper.Map<Event>(model);
            eventRepository.Save(eventEntity);
        }
    }
}