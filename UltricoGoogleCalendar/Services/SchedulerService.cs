using System;
using Hangfire;
using UltricoGoogleCalendar.DataLayer.Enums;
using UltricoGoogleCalendar.Jobs;
using UltricoGoogleCalendar.Model;

namespace UltricoGoogleCalendar.Services
{
    public class SchedulerService : ISchedulerService
    {
        private readonly IBackgroundJobClient backgroundJobClient;
        private readonly IRecurringJobManager recurringJobManager;
        private readonly ICronExpressionFactory cronExpressionFactory;

        public SchedulerService(
            IBackgroundJobClient backgroundJobClient, 
            IRecurringJobManager recurringJobManager, 
            ICronExpressionFactory cronExpressionFactory)
        {
            this.backgroundJobClient = backgroundJobClient;
            this.recurringJobManager = recurringJobManager;
            this.cronExpressionFactory = cronExpressionFactory;
        }

        public void Schedule(EventResource model)
        {
            var args = new EventScheduleArgs()
            {
                Email = "userEmail",
                Event = model
            };

            if (model.Schedule.ScheduleType == ScheduleTypeEnum.Daily)
            {
                backgroundJobClient.Schedule<EventScheduleJob>(job => job.Execute(args), model.Schedule.Daily.AtTime);

            } else { 
                var cronResult = cronExpressionFactory.Generate(model.Schedule);

                recurringJobManager.AddOrUpdate<EventScheduleJob>(
                    Guid.NewGuid().ToString(), 
                    job => job.Execute(args), 
                    cronResult.CronExpression);
            }
        }
    }
}