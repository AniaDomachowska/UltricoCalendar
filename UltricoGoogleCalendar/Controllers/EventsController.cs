using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UltricoGoogleCalendar.Model;
using UltricoGoogleCalendar.Services;

namespace UltricoGoogleCalendar.Controllers
{
    [Route("/api/events")]
    public class EventsController : Controller
    {
        private readonly IEventService eventService;

        public EventsController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        public IEnumerable<EventResource> Get()
        {
            return eventService.GetAll();
        }

        [HttpPost]
        public OperationResult Create([FromBody]EventCreateModel model)
        {
            eventService.Create(model);

            return OperationResult.OkResult;
        }

        [HttpPut]
        public OperationResult Update(EventUpdateModel model)
        {
            eventService.Update(model);

            return OperationResult.OkResult;
        }
    }
}