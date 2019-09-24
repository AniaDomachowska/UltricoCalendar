using AutoMapper;
using UltricoGoogleCalendar.DataLayer.Model;
using UltricoGoogleCalendar.DataLayer.Repositories;
using UltricoGoogleCalendar.Model;

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
    }
}