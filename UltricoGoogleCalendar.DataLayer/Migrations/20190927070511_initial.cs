using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UltricoGoogleCalendar.DataLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    ScheduleType = table.Column<int>(nullable: false),
                    DailyAtTime = table.Column<DateTime>(nullable: false),
                    AnnualRepeatOnDay = table.Column<int>(nullable: false),
                    AnnualRepeatOnMonth = table.Column<int>(nullable: false),
                    MonthlyRepeatOnDay = table.Column<int>(nullable: false),
                    WeeklyRepeatNumberOfWeeks = table.Column<bool>(nullable: false),
                    WeeklyRepeatOnMonday = table.Column<bool>(nullable: false),
                    WeeklyRepeatOnTuesday = table.Column<bool>(nullable: false),
                    WeeklyRepeatOnWednesday = table.Column<bool>(nullable: false),
                    WeeklyRepeatOnThursday = table.Column<bool>(nullable: false),
                    WeeklyRepeatOnFriday = table.Column<bool>(nullable: false),
                    WeeklyRepeatOnSaturday = table.Column<bool>(nullable: false),
                    WeeklyRepeatOnSunday = table.Column<bool>(nullable: false),
                    WeeklyEndsAfterNoOfOccurrences = table.Column<int>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: true),
                    StartDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    WholeDayEvent = table.Column<bool>(nullable: false),
                    ScheduleId = table.Column<int>(nullable: true),
                    ParentEventId = table.Column<int>(nullable: true),
                    OccurenceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Events_ParentEventId",
                        column: x => x.ParentEventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_ParentEventId",
                table: "Events",
                column: "ParentEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ScheduleId",
                table: "Events",
                column: "ScheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Schedule");
        }
    }
}
