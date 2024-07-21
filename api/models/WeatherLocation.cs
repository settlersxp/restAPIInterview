namespace api.Models
{
    public class WeatherLocation
    {
        public int Id { get; set; }
        public string Date { get; set; } = string.Empty;
        public int TemperatureC { get; set; } = 0;
        public WeatherSummaries Summary { get; set; } = WeatherSummaries.Warm;
        public int TemperatureF { get; set; } = 0;
    }
}