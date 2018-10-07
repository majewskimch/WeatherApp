using NSubstitute;
using Xunit;
using WeatherApp.Services;
using WeatherApp.Models.Weahter;
using WeatherApp.Controllers;
using System.Threading.Tasks;

namespace WeatherApp.UnitTest
{
    public class ControllersTest
    {
        WeatherController weatherController;

        public ControllersTest()
        {
            var weatherService = Substitute.For<IWeatherService>();
            weatherService.GetWeatherCityViewModel("Berlin", "Germany").Returns(
                new CityViewModel()
                {
                    City = "Berlin",
                    Country = "Germany",
                    Temperature = "11",
                    Humidity = "44"
                });

            this.weatherController = new WeatherController(weatherService);
        }

        [Fact]
        public async Task GetWeather_ReturnProperCityViewModel()
        {
            // Act
            var results = await this.weatherController.GetWeather("Berlin", "Germany");

            // Assert
            Assert.Equal(typeof(CityViewModel), results.GetType());
            Assert.Equal(results.City, "Berlin");
            Assert.Equal(results.Country, "Germany");
            Assert.Equal(results.Temperature, "11");
            Assert.Equal(results.Humidity, "44");
        }
    }
}
