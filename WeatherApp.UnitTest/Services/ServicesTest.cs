using NSubstitute;
using System.Threading.Tasks;
using WeatherApp.App_Start;
using WeatherApp.Models.Weahter;
using WeatherApp.Repository;
using WeatherApp.Services;
using Xunit;

namespace WeatherApp.UnitTest.Services
{
    public class ServicesTest 
    {
        private readonly WeatherService weatherService;

        public ServicesTest()
        {
            AutoMapperConfig.Init();
            var weatherRepository = Substitute.For<IWeatherRepository>();

            weatherRepository.GetWeatherForecastAsync("City", "Country").Returns(
                new WeatherResponse()
                {
                    Main = new Models.Main
                    {
                        Humidity = 34,
                        Temp = 67
                    },
                    Name = "Name",
                    Sys = new Models.Sys
                    {
                        Country = "Code"
                    }
                });
            this.weatherService = new WeatherService(weatherRepository);
        }

        [Fact]
        public async Task GetWeatherCityViewModel_ReturnProperCityViewModel()
        {
            // Act
            var results = await this.weatherService.GetWeatherCityViewModel("City", "Country");

            // Assert
            Assert.Equal(typeof(CityViewModel), results.GetType());
            Assert.Equal(results.City, "Name");
            Assert.Equal(results.Country, "Code");
            Assert.Equal(results.Temperature, "67");
            Assert.Equal(results.Humidity, "34");
        }
    }
}
