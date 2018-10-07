using AutoMapper;
using WeatherApp.Map;
using WeatherApp.Models.Weahter;

namespace WeatherApp.App_Start
{
    public class AutoMapperConfig
    {
        private static object _thisLock = new object();
        private static bool _initialized = false;

        public static void Init()
        {
            lock (_thisLock)
            {
                if (!_initialized)
                {
                    Mapper.Initialize(x =>
                    {
                        x.CreateMap<CityViewModel, WeatherResponse>();
                        x.AddProfile<WeatherProfile>();
                    });
                    _initialized = true;
                }
            }
        }
    }
}