using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;

namespace api.controllers
{
    public class WeatherLocationsController : Controller
    {
        private readonly apiContext _context;

        public WeatherLocationsController(apiContext context)
        {
            _context = context;
        }

        // GET: WeatherLocations
        public async Task<IActionResult> Index()
        {
            return View(await _context.WeatherLocation.ToListAsync());
        }

        // GET: WeatherLocations/Details/5
        public async Task<IActionResult> Details(int? id)
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

            return View(weatherLocation);
        }

        // GET: WeatherLocations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WeatherLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,TemperatureC,Summary,TemperatureF")] WeatherLocation weatherLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weatherLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(weatherLocation);
        }

        // GET: WeatherLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherLocation = await _context.WeatherLocation.FindAsync(id);
            if (weatherLocation == null)
            {
                return NotFound();
            }
            return View(weatherLocation);
        }

        // POST: WeatherLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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

            return View(weatherLocation);
        }

        // POST: WeatherLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weatherLocation = await _context.WeatherLocation.FindAsync(id);
            if (weatherLocation != null)
            {
                _context.WeatherLocation.Remove(weatherLocation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeatherLocationExists(int id)
        {
            return _context.WeatherLocation.Any(e => e.Id == id);
        }
    }
}
