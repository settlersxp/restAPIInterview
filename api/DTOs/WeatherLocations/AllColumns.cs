using api.Models;

namespace api.DTOs.WeatherLocations
{
    public class AllColumns
    {
        public int Id { get; set; }
        public string Date { get; set; } = string.Empty;

        public decimal TemperatureC { get; set; } = 0;

        public WeatherSummaries? Summary { get; set; }

        public decimal TemperatureF { get; set; } = 0;
    }
}
