using System.Threading.Tasks;
using System.Web.Http;
using WeatherApp.Models.Weahter;
using WeatherApp.Models.Weather;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    [RoutePrefix("api")]
    public class WeatherController : ApiController
    {
        private readonly IWeatherService _wService;

        public WeatherController(IWeatherService weatherService)
        {
            _wService = weatherService;
        }

        [HttpGet]
        [Route("weather/{city}/{country}")]
        public async Task<CityViewModel> GetWeather(string city, string country)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(country))
            {
                var wForecast = await _wService.GetWeatherCityViewModel(city, country);
                return wForecast;
            }

            return new CityViewModel();
        }
    }
}