﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UltricoGoogleCalendar.DataLayer;

namespace UltricoGoogleCalendar.DataLayer.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("UltricoGoogleCalendar.DataLayer.Model.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<Guid>("OccurenceId");

                    b.Property<int?>("ParentEventId");

                    b.Property<int?>("ScheduleId");

                    b.Property<string>("Title");

                    b.Property<DateTime>("Updated");

                    b.HasKey("Id");

                    b.HasIndex("ParentEventId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("UltricoGoogleCalendar.DataLayer.Model.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnnualRepeatOnDay");

                    b.Property<int>("AnnualRepeatOnMonth");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("DailyAtTime");

                    b.Property<int>("MonthlyRepeatOnDay");

                    b.Property<int>("ScheduleType");

                    b.Property<DateTime>("Updated");

                    b.Property<DateTime>("WeeklyEndDateTime");

                    b.Property<int>("WeeklyEndsAfterNoOfOccurrences");

                    b.Property<bool>("WeeklyRepeatNumberOfWeeks");

                    b.Property<string>("WeeklyRepeatOn");

                    b.Property<DateTime>("WeeklyStartDateTime");

                    b.HasKey("Id");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("UltricoGoogleCalendar.DataLayer.Model.Event", b =>
                {
                    b.HasOne("UltricoGoogleCalendar.DataLayer.Model.Event", "ParentEvent")
                        .WithMany()
                        .HasForeignKey("ParentEventId");

                    b.HasOne("UltricoGoogleCalendar.DataLayer.Model.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleId");
                });
#pragma warning restore 612, 618
        }
    }
}
