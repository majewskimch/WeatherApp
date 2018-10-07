using System.Threading.Tasks;
using WeatherApp.Models.Weahter;

namespace WeatherApp.Services
{
    public interface IWeatherService
    {
        Task<CityViewModel> GetWeatherCityViewModel(string city, string country);
    }
}