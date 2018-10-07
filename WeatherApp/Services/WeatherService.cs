using AutoMapper;
using System.Threading.Tasks;
using WeatherApp.Models.Weahter;
using WeatherApp.Repository;

namespace WeatherApp.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _wRepository;

        public WeatherService(IWeatherRepository weatherRepository)
        {
            this._wRepository = weatherRepository;
        }

        public async Task<CityViewModel> GetWeatherCityViewModel(string city, string country)
        {
            var results = await this._wRepository.GetWeatherForecastAsync(city, country);
            var model = Mapper.Map<CityViewModel>(results);
            return model;
        }
    }
}