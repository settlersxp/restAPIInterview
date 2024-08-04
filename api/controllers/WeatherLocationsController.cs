using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.DTOs.WeatherLocations;
using api.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace api.controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class WeatherLocationsController(IWeatherLocationsRepository weatherRepo) : ControllerBase
    {
        private readonly IWeatherLocationsRepository _weatherRepo = weatherRepo;

        [HttpGet(Name = "Get all weather entries")]
        public async Task<ActionResult<List<SmallerDto>>> GetAll()
        {
            var existingLocations = await _weatherRepo.GetAllAsync();

            return Ok(existingLocations);
        }


        [HttpGet("{id}", Name = "Get weather entry")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var weatherLocation = await _weatherRepo.GetByIdAsync(id);
            if (weatherLocation == null)
            {
                return NotFound("Weather entry not found");
            }

            return Ok(weatherLocation);
        }


        // POST: WeatherLocations/Create
        [HttpPost(Name = "Create a new weather location")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateWithoutId weatherLocation, IWeatherLocationsRepository _weatherRepo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid weather model");
            }

            SmallerDto? newLocation = await _weatherRepo.CreateAsync(weatherLocation);
            if (newLocation == null)
            {
                return BadRequest("Could not save the location");
            }

            return Ok(newLocation);
        }


        [HttpPatch("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [Bind("Id,Date,TemperatureC,Summary,TemperatureF")] AllColumns weatherLocation)
        {
            if (id != weatherLocation.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid weather model");
            }

            SmallerDto? updatedLocation = await _weatherRepo.UpdateAsync(id, weatherLocation);

            if (updatedLocation == null)
            {
                return NotFound("Weather entry not found");
            }

            return Ok(updatedLocation);
        }

        // GET: WeatherLocations/Delete/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherLocation = await _weatherRepo.DeleteAsync(id.Value);
            if (weatherLocation == null)
            {
                return NotFound();
            }

            return Ok(weatherLocation);
        }
    }
}
