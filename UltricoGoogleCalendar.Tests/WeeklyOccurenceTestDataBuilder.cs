using System;
using UltricoGoogleCalendar.DataLayer.Model;

namespace UltricoGoogleCalendar.Tests
{
    public class WeeklyOccurenceTestDataBuilder
    {
        private Event eventEntity;
        public WeeklyOccurenceTestDataBuilder()
        {
            eventEntity = new Event();
        }

        public WeeklyOccurenceTestDataBuilder ForNoDays()
        {
            eventEntity.Schedule.WeeklyRepeatOnMonday = false;
            eventEntity.Schedule.WeeklyRepeatOnTuesday = false;
            eventEntity.Schedule.WeeklyRepeatOnWednesday = false;
            eventEntity.Schedule.WeeklyRepeatOnThursday = false;
            eventEntity.Schedule.WeeklyRepeatOnFriday = false;
            eventEntity.Schedule.WeeklyRepeatOnSaturday = false;
            eventEntity.Schedule.WeeklyRepeatOnSunday = false;

            return this;
        }

        public WeeklyOccurenceTestDataBuilder ForAllDays()
        {
            ForMonday();
            ForTuesday();
            ForWednesday();
            ForThursday();
            ForFriday();
            ForSaturday();
            ForSunday();

            return this;
        }

        public WeeklyOccurenceTestDataBuilder ForSunday()
        {
            eventEntity.Schedule.WeeklyRepeatOnSunday = true;
            return this;
        }

        public WeeklyOccurenceTestDataBuilder ForSaturday()
        {
            eventEntity.Schedule.WeeklyRepeatOnSaturday = true;
            return this;
        }

        public WeeklyOccurenceTestDataBuilder ForFriday()
        {
            eventEntity.Schedule.WeeklyRepeatOnFriday = true;
            return this;
        }

        public WeeklyOccurenceTestDataBuilder ForThursday()
        {
            eventEntity.Schedule.WeeklyRepeatOnThursday = true;
            return this;
        }

        public WeeklyOccurenceTestDataBuilder ForWednesday()
        {
            eventEntity.Schedule.WeeklyRepeatOnWednesday = true;
            return this;
        }

        public WeeklyOccurenceTestDataBuilder ForTuesday()
        {
            eventEntity.Schedule.WeeklyRepeatOnTuesday = true;
            return this;
        }

        public WeeklyOccurenceTestDataBuilder ForMonday()
        {
            eventEntity.Schedule.WeeklyRepeatOnMonday = true;
            return this;
        }

        public WeeklyOccurenceTestDataBuilder ForPeriod(DateTime startDate, DateTime endDate)
        {
            eventEntity.Schedule.StartDateTime = startDate;
            eventEntity.Schedule.EndDateTime = endDate;
            return this;
        }

        public Event Build()
        {
            return eventEntity;
        }
    }
}