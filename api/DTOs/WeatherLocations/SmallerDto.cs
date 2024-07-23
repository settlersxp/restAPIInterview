using System.ComponentModel.DataAnnotations.Schema;
using api.Models;

namespace api.DTOs.WeatherLocations
{
    public class SmallerDto
    {
        public int Id { get; set; }
        public string? Date { get; set; }
        public decimal TemperatureC { get; set; }
        public decimal TemperatureF { get; set; }
    }
}
