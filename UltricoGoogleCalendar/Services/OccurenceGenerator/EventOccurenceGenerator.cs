using System;
using System.Collections.Generic;
using UltricoGoogleCalendar.DataLayer.Enums;
using UltricoGoogleCalendar.DataLayer.Repositories;
using UltricoGoogleCalendar.Model;

namespace UltricoGoogleCalendar.Services.OccurenceGenerator
{
    public partial class EventOccurenceGenerator : IEventOccurenceGenerator
    {
        private readonly IEventRepository eventRepository;
        private readonly Dictionary<ScheduleTypeEnum, IOccurenceFactory> occurenceFactories = 
            new Dictionary<ScheduleTypeEnum, IOccurenceFactory>()
        {
            { ScheduleTypeEnum.Weekly, new WeeklyOccurenceFactory() },
            { ScheduleTypeEnum.Daily, new DailyOccurenceFactory() }
        };

        public EventOccurenceGenerator(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public List<EventOccurenceResource> Generate(DateTime startDate, DateTime endDate)
        {
            var result = new List<EventOccurenceResource>();
            var events = eventRepository.GetAll();

            foreach (var eventEntity in events)
            {
                var schedule = eventEntity.Schedule;

                var occurenceResources = occurenceFactories[schedule.ScheduleType]
                    .Create(eventEntity, new OccurenceFactoryParams()
                {
                    StartDate = startDate,
                    EndDate = endDate
                });

                result.AddRange(occurenceResources);
            }

            return result;
        }
    }

    public class OccurenceFactoryParams
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}