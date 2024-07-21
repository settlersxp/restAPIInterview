using System.Net.Mime;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace api.Models
{
    public class WeatherLocation
    {
        public int Id { get; set; }
        public string Date { get; set; } = string.Empty;

        [Column(TypeName = "decimal(3, 2)")]
        public decimal TemperatureC { get; set; } = 0;

        public WeatherSummaries? Summary { get; set; }

        [Column(TypeName = "decimal(3, 2)")]
        public decimal TemperatureF { get; set; } = 0;
    }
}