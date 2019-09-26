using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UltricoGoogleCalendar.DataLayer.Migrations
{
    public partial class Initial : Migration
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
                    WeeklyRepeatOn = table.Column<string>(nullable: true),
                    WeeklyStartDateTime = table.Column<DateTime>(nullable: false),
                    WeeklyEndsAfterNoOfOccurrences = table.Column<int>(nullable: false),
                    WeeklyEndDateTime = table.Column<DateTime>(nullable: false)
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
                    ScheduleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
