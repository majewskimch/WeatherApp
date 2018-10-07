using WeatherApp.App_Start;
using WeatherApp.Models.Weahter;
using Xunit;

namespace WeatherApp.UnitTest.Mapper
{
    public class MapperTest 
    {
        public MapperTest()
        {
            AutoMapperConfig.Init();
        }

        [Fact]
        public void MapResponse_ExpectedNullCity_WhenWeatherResponseIsNull()
        {
            // Arrange
            var weatherResponse = new WeatherResponse();

            // Act
            var result = AutoMapper.Mapper.Map<CityViewModel>(weatherResponse);

            // Assert
            Assert.Equal(result.City, null);
        }

        [Fact]
        public void MapResponse_ExpectedCityViewModel_WhenWeatherResponseIsProper()
        {
            // Arrange
            var weatherResponse =
                new WeatherResponse()
                {
                    Main = new Models.Main
                    {
                        Humidity = 88,
                        Temp = 99
                    },
                    Name = "CityName",
                    Sys = new Models.Sys
                    {
                        Country = "CityCode"
                    }
                };

            // Act
            var results = AutoMapper.Mapper.Map<CityViewModel>(weatherResponse);

            // Assert
            Assert.Equal(typeof(CityViewModel), results.GetType());
            Assert.Equal(results.City, "CityName");
            Assert.Equal(results.Country, "CityCode");
            Assert.Equal(results.Temperature, "99");
            Assert.Equal(results.Humidity, "88");
        }
    }
}
