using Microsoft.AspNetCore.Mvc;
using UltricoGoogleCalendar.Model;
using UltricoGoogleCalendar.Services;

namespace UltricoGoogleCalendar.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService eventService;

        public EventsController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public OperationResult Create(EventCreateModel model)
        {
            eventService.Create(model);

            return OperationResult.OkResult;
        }

        public OperationResult Update(EventUpdateModel model)
        {
            eventService.Update(model);

            return OperationResult.OkResult;
        }
    }
}