using AutoMapper;
using UltricoGoogleCalendar.DataLayer.Model;
using UltricoGoogleCalendar.Model;

namespace UltricoGoogleCalendar
{
    public class AutoMapperConfig
    {
        public static IMapper Create()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EventCreateModel, Event>()
                    .ForMember(dest => dest.Schedule, opt => opt.MapFrom(src => src.Schedule))
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

                cfg.CreateMap<EventUpdateModel, Event>()
                    .ForMember(dest => dest.Schedule, opt => opt.MapFrom(src => src.Schedule))
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.OccurenceId, opt => opt.MapFrom(src => src.OccurenceId));

                cfg.CreateMap<Event, EventResource>()
                    .ForMember(dest => dest.Schedule, opt => opt.MapFrom(src => src.Schedule))
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.OccurenceId, opt => opt.MapFrom(src => src.OccurenceId));

                cfg.CreateMap<ScheduleModel, Schedule>().ReverseMap();
            });

            return config.CreateMapper(); 
        }
    }
}