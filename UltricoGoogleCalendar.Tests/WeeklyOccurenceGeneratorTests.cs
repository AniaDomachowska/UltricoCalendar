using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using UltricoGoogleCalendar.Model;
using UltricoGoogleCalendar.Services.OccurenceGenerator;

namespace UltricoGoogleCalendar.Tests
{
    public class WeeklyOccurenceGeneratorTests
    {
        [Test]
        public void Generate_For_Whole_Week_Returns_Occurence_For_Every_Day()
        {
            // Arrange
            var sut = new WeeklyOccurenceFactory();
            var eventEntity = new WeeklyOccurenceTestDataBuilder()
                .ForAllDays()
                .Build();

            var occurenceFactoryParams = CreateFactoryParams();

            // Act
            var result = sut.Create(eventEntity, occurenceFactoryParams);

            // Assert
            result.Should().HaveCount((occurenceFactoryParams.EndDate - occurenceFactoryParams.StartDate).Days);

            foreach (var dayOfWeek in new[]
            {
                DayOfWeek.Monday,
                DayOfWeek.Tuesday,
                DayOfWeek.Wednesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
                DayOfWeek.Saturday,
                DayOfWeek.Sunday
            })
            {
                ValidateForDay(occurenceFactoryParams, result, dayOfWeek);
            }
        }

        [Test]
        public void Generate_For_Event_That_Has_Start_And_End_Date_Returns_Every_Day_Occurence()
        {
            // Arrange
            var sut = new WeeklyOccurenceFactory();
            var eventEntity = new WeeklyOccurenceTestDataBuilder()
                .ForAllDays()
                .ForPeriod(new DateTime(2001, 1, 10), new DateTime(2001, 1, 20))
                .Build();

            var occurenceFactoryParams = CreateFactoryParams(new DateTime(2001, 1, 1), new DateTime(2001,3,1));

            // Act
            var result = sut.Create(eventEntity, occurenceFactoryParams);

            // Assert
            result.Should().HaveCount((eventEntity.Schedule.EndDateTime- eventEntity.Schedule.StartDateTime).Value.Days + 1);

            result.Should().NotContain(element => element.Date < eventEntity.Schedule.StartDateTime
                                                  || element.Date > eventEntity.Schedule.EndDateTime);
        }

        [Test]
        public void Generate_For_Monday_Returns_Mondays()
        {
            // Arrange
            var sut = new WeeklyOccurenceFactory();
            var eventEntity = new WeeklyOccurenceTestDataBuilder()
                .ForMonday()
                .Build();
            
            var occurenceFactoryParams = CreateFactoryParams();

            // Act
            var result = sut.Create(eventEntity, occurenceFactoryParams);

            // Assert
            ValidateForDay(occurenceFactoryParams, result, DayOfWeek.Monday);
        }

        [Test]
        public void Generate_For_Monday_Returns_Tuesdays()
        {
            // Arrange
            var sut = new WeeklyOccurenceFactory();
            var eventEntity = new WeeklyOccurenceTestDataBuilder()
                .ForTuesday()
                .Build();

            var occurenceFactoryParams = CreateFactoryParams();

            // Act
            var result = sut.Create(eventEntity, occurenceFactoryParams);

            // Assert
            ValidateForDay(occurenceFactoryParams, result, DayOfWeek.Tuesday, true);
        }

        [Test]
        public void Generate_For_Monday_Returns_Wednesdays()
        {
            // Arrange
            var sut = new WeeklyOccurenceFactory();
            var eventEntity = new WeeklyOccurenceTestDataBuilder()
                .ForWednesday()
                .Build();

            var occurenceFactoryParams = CreateFactoryParams();

            // Act
            var result = sut.Create(eventEntity, occurenceFactoryParams);

            // Assert
            ValidateForDay(occurenceFactoryParams, result, DayOfWeek.Wednesday, true);
        }

        [Test]
        public void Generate_For_Monday_Returns_Thursdays()
        {
            // Arrange
            var sut = new WeeklyOccurenceFactory();
            var eventEntity = new WeeklyOccurenceTestDataBuilder()
                .ForThursday()
                .Build();

            var occurenceFactoryParams = CreateFactoryParams();

            // Act
            var result = sut.Create(eventEntity, occurenceFactoryParams);

            // Assert
            ValidateForDay(occurenceFactoryParams, result, DayOfWeek.Thursday, true);
        }

        [Test]
        public void Generate_For_Monday_Returns_Friday()
        {
            // Arrange
            var sut = new WeeklyOccurenceFactory();
            var eventEntity = new WeeklyOccurenceTestDataBuilder()
                .ForFriday()
                .Build();

            var occurenceFactoryParams = CreateFactoryParams();

            // Act
            var result = sut.Create(eventEntity, occurenceFactoryParams);

            // Assert
            ValidateForDay(occurenceFactoryParams, result, DayOfWeek.Friday, true);
        }

        [Test]
        public void Generate_For_Monday_Returns_Saturday()
        {
            // Arrange
            var sut = new WeeklyOccurenceFactory();
            var eventEntity = new WeeklyOccurenceTestDataBuilder()
                .ForSaturday()
                .Build();

            var occurenceFactoryParams = CreateFactoryParams();

            // Act
            var result = sut.Create(eventEntity, occurenceFactoryParams);

            // Assert
            ValidateForDay(occurenceFactoryParams, result, DayOfWeek.Saturday, true);
        }



        [Test]
        public void Generate_For_Empty_Schedule_Returns_NoOccurrences()
        {

        }

        [Test]
        public void Generate_For_Monday_Returns_Sunday()
        {
            // Arrange
            var sut = new WeeklyOccurenceFactory();
            var eventEntity = new WeeklyOccurenceTestDataBuilder()
                .ForSunday()
                .Build();

            var occurenceFactoryParams = CreateFactoryParams();

            // Act
            var result = sut.Create(eventEntity, occurenceFactoryParams);

            // Assert
            ValidateForDay(occurenceFactoryParams, result, DayOfWeek.Sunday, true);
        }

        [Test]
        public void Generate_For_Exceeded_Number_Of_Occurences_In_Event_Dont_Return_Anything()
        {

        }

        private static OccurenceFactoryParams CreateFactoryParams(
            DateTime? startDate = null, 
            DateTime? endDate = null)
        {
            var occurenceFactoryParams = new OccurenceFactoryParams()
            {
                StartDate = startDate ?? new DateTime(2001, 1, 1),
                EndDate = endDate ?? new DateTime(2001, 3, 1)
            };
            return occurenceFactoryParams;
        }

        private static void ValidateForDay(
            OccurenceFactoryParams occurenceFactoryParams, 
            IList<EventOccurenceResource> result,
            DayOfWeek dayOfWeek,
            bool excludeOtherDays = false)
        {
            for (var i = 0; i < (occurenceFactoryParams.EndDate - occurenceFactoryParams.StartDate).Days; i++)
            {
                var date = occurenceFactoryParams.StartDate.AddDays(i);
                if (date.DayOfWeek == dayOfWeek)
                {
                    result.Should().Contain(element => element.Date == date);
                }
                else if (excludeOtherDays)
                {
                    result.Should().NotContain(element => element.Date == date);
                }
            }
        }
    }
}
