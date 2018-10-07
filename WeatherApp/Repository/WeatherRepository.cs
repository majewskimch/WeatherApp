using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Models.Weahter;

namespace WeatherApp.Repository
{
    public class WeatherRepository : IWeatherRepository
    {
        public async Task<WeatherResponse> GetWeatherForecastAsync(string city, string country)
        {
            string apiId = System.Configuration.ConfigurationManager.AppSettings["APIKey"];
            string apiUrl = System.Configuration.ConfigurationManager.AppSettings["APIUrl"];
            string apiUnits = System.Configuration.ConfigurationManager.AppSettings["APIUnits"];

            string apiRequest =
                $"{apiUrl}/weather?q={city},{country}&units={apiUnits}&appid={apiId}";

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(apiRequest))
            using (HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeatherResponse>(result);
            }
        }
    }
}