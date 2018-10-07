using System.Threading.Tasks;
using WeatherApp.Models.Weahter;

namespace WeatherApp.Repository
{
    public interface IWeatherRepository
    {
        Task<WeatherResponse> GetWeatherForecastAsync(string city, string country);
    }
}