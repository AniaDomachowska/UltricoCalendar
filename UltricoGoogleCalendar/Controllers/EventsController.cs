using System;
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

        [Route("{id}")]
        public EventResource GetById(int id, [FromQuery] Guid? occurenceId)
        {
            return eventService.GetOne(id, occurenceId);
        }

        [HttpPost]
        public OperationResult Create([FromBody] EventCreateModel model)
        {
            eventService.Create(model);

            return OperationResult.OkResult;
        }

        [HttpPut]
        [Route("{id}")]
        public OperationResult Update(int id, [FromBody] EventUpdateModel model)
        {
            int[] test = {1, 2, 3};

            var list = test as IList<int>;
            Guid? occurenceId = null;

            if (model.EditSingleEvent)
            {
                occurenceId = eventService.CreateOccurence(id, model);
            }
            else
            {
                eventService.Update(id, model);
            }

            return OperationResult.CreateOkResult(occurenceId);
        }
    }
}