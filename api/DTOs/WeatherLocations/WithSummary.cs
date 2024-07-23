using api.Models;

namespace api.DTOs.WeatherLocations
{
    public class WithSummary
    {
        public string? Date { get; set; }
        public decimal TemperatureC { get; set; }
        public WeatherSummaries? Summary { get; set; }
        public decimal TemperatureF { get; set; }
    }
}
