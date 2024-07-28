using api.Data;
using api.DTOs.WeatherLocations;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class WeatherLocationsRepository : IWeatherLocationsRepository
    {
        private readonly apiContext _context;

        public WeatherLocationsRepository(apiContext context)
        {
            _context = context;
        }


        public Task<List<WeatherLocation>> GetAllAsync()
        {
            return _context.WeatherLocation.ToListAsync();
        }

        public async Task<WeatherLocation?> GetByIdAsync(int id)
        {
            return await _context.WeatherLocation.FindAsync(id);
        }

        public async Task<SmallerDto?> CreateAsync(CreateWithoutId weatherLocations)
        {
            var newWeatherLocation = weatherLocations.ToModelWithSummary();
            await _context.AddAsync(newWeatherLocation);
            await _context.SaveChangesAsync();
            return newWeatherLocation.ToSmallerDto();
        }

        public async Task<SmallerDto?> UpdateAsync(int id, AllColumns weatherLocations)
        {
            var existingWeatherLocation = await _context.WeatherLocation.FirstOrDefaultAsync(x => x.Id == id);

            if(existingWeatherLocation == null)
            {
                return null;
            }

            existingWeatherLocation.Date = weatherLocations.Date;
            existingWeatherLocation.TemperatureC = weatherLocations.TemperatureC;
            existingWeatherLocation.Summary = weatherLocations.Summary;
            existingWeatherLocation.TemperatureF = weatherLocations.TemperatureF;


            await _context.SaveChangesAsync();

            return existingWeatherLocation.ToSmallerDto();
        }

        public async Task<WeatherLocation?> DeleteAsync(int id)
        {
            var weatherLocation = await _context.WeatherLocation.FirstOrDefaultAsync(x => x.Id == id);

            if (weatherLocation == null)
            {
                return null;
            }
            
            // not async
            _context.WeatherLocation.Remove(weatherLocation);
            await _context.SaveChangesAsync();
            return weatherLocation;
        }
    }
}
