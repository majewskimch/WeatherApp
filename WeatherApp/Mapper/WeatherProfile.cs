using AutoMapper;
using WeatherApp.Models.Weahter;

namespace WeatherApp.Map
{
    public class WeatherProfile : Profile
    {
        public WeatherProfile()
        {
            CreateMap<WeatherResponse, CityViewModel>()
                .ForMember(d => d.Temperature, o => o.MapFrom(source => source.Main.Temp))
                .ForMember(d => d.Humidity, o => o.MapFrom(source => source.Main.Humidity))
                .ForMember(d => d.City, o => o.MapFrom(source => source.Name))
                .ForMember(d => d.Country, o => o.MapFrom(source => source.Sys.Country));
        }
    }
}