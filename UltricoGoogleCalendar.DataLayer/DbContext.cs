using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using UltricoGoogleCalendar.DataLayer.Model;

namespace UltricoGoogleCalendar.DataLayer
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Events.db;");
        }

        public DbSet<Event> Events { get; set; }
    }
}
