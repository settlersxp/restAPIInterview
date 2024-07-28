namespace api.DTOs.WeatherLocations
{
    public class CreateWithoutId
    {
        public string? Date { get; set; }
        public decimal TemperatureC { get; set; }
        public decimal TemperatureF { get; set; }
    }
}
