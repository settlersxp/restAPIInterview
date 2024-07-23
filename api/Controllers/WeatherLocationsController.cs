using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;
using api.DTOs.WeatherLocations;
using api.Mappers;

namespace api.controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class WeatherLocationsController : Controller
    {
        private readonly apiContext _context;

        public WeatherLocationsController(apiContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "Get all weather entries")]
        public async Task<ActionResult<List<SmallerDto>>> GetAll()
        {
            var existingLocations = _context.WeatherLocation.ToList().Select(s=> s.ToSmallerDto());

            return Ok(existingLocations);
        }


        [HttpGet("{id}", Name = "Get weather entry")]
        public async Task<ActionResult<WeatherLocation>> Get([FromRoute] int id)
        {
            var weatherLocation = await _context.WeatherLocation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weatherLocation == null)
            {
                return NotFound("Weather entry not found");
            }

            return Ok(weatherLocation);
        }


        // POST: WeatherLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost(Name = "Create a new weather location")]
        public async Task<ActionResult<SmallerDto>> Create([FromBody] SmallerDto weatherLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid weather model");
            }

            var newWeatherLocation = weatherLocation.ToModelWithSummary();

             _context.WeatherLocation.Add(newWeatherLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = newWeatherLocation.Id }, newWeatherLocation.ToSmallerDto());
        }

        // POST: WeatherLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPatch("{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,TemperatureC,Summary,TemperatureF")] WeatherLocation weatherLocation)
        {
            if (id != weatherLocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weatherLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeatherLocationExists(weatherLocation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(weatherLocation);
        }

        // GET: WeatherLocations/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherLocation = await _context.WeatherLocation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weatherLocation == null)
            {
                return NotFound();
            }

            _context.WeatherLocation.Remove(weatherLocation);
            await _context.SaveChangesAsync();

            return Ok(weatherLocation);
        }


        private bool WeatherLocationExists(int id)
        {
            return _context.WeatherLocation.Any(e => e.Id == id);
        }
    }
}
