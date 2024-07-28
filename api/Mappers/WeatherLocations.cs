namespace api.Mappers
{
    public static class WeatherLocations
    {
        public static DTOs.WeatherLocations.SmallerDto ToSmallerDto(this Models.WeatherLocation weatherLocation)
        {
            return new DTOs.WeatherLocations.SmallerDto
            {
                Id = weatherLocation.Id,
                Date = weatherLocation.Date,
                TemperatureC = weatherLocation.TemperatureC,
                TemperatureF = weatherLocation.TemperatureF
            };
        }

        public static Models.WeatherLocation ToModelWithSummary(this DTOs.WeatherLocations.CreateWithoutId weatherLocation)
        {
            // do some logic in here
            if(weatherLocation.TemperatureC == 0 && weatherLocation.TemperatureF == 0)
            {
                weatherLocation.TemperatureF = weatherLocation.TemperatureC * 9 / 5 + 32;
            }

            var futureWeatherLocation = new Models.WeatherLocation
            {
                Date = weatherLocation.Date,
                TemperatureC = weatherLocation.TemperatureC,
                TemperatureF = weatherLocation.TemperatureF
            };

            futureWeatherLocation.Summary = weatherLocation.TemperatureC switch
            {
                < -10 => Models.WeatherSummaries.Freezing,
                < 0 => Models.WeatherSummaries.Chilly,
                < 10 => Models.WeatherSummaries.Mild,
                < 20 => Models.WeatherSummaries.Warm,
                < 30 => Models.WeatherSummaries.Balmy,
                _ => Models.WeatherSummaries.Hot
            };

            return futureWeatherLocation;
        }
    }
}
