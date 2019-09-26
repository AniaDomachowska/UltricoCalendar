using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UltricoGoogleCalendar.DataLayer;
using UltricoGoogleCalendar.DataLayer.Repositories;
using UltricoGoogleCalendar.Services;

namespace UltricoGoogleCalendar
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton(AutoMapperConfig.Create());
            services.AddHangfire(configuration => { configuration.UseMemoryStorage(); });
            services.AddHangfireServer();
            services.AddTransient<IEventService, EventService>();
            var databaseContext = new DatabaseContext();

            databaseContext.Database.Migrate();
            services.AddSingleton<IEventRepository>(new EventRepository(databaseContext));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}