using api.DTOs.WeatherLocations;
using api.Models;
using System.Linq;

namespace api.Interfaces
{
    public interface IWeatherLocationsRepository
    {
        Task<List<WeatherLocation>> GetAllAsync();
        Task<WeatherLocation?> GetByIdAsync(int id);
        Task<SmallerDto?> CreateAsync(CreateWithoutId weatherLocations);
        Task<SmallerDto?> UpdateAsync(int id, AllColumns weatherLocations);
        Task<WeatherLocation?> DeleteAsync(int id);
    }
}
