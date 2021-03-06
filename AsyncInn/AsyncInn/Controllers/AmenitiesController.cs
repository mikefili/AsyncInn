﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;

namespace AsyncInn.Controllers
{
    public class AmenitiesController : Controller
    {
        private readonly IAmenityManager _context;

        public AmenitiesController(IAmenityManager context)
        {
            _context = context;
        }

        // GET: Amenities
        public async Task<IActionResult> Index(string searchString)
        {
            var amenities = await _context.GetAmenities();
            if (!String.IsNullOrEmpty(searchString))
            {
                amenities = amenities.Where(s => s.Name.Contains(searchString));
            }
            return View(await _context.GetAmenities());
        }

        // GET: Amenities/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var amenities = await _context.GetAmenity(id);
            if (amenities == null)
            {
                return NotFound();
            }
            return View(amenities);
        }

        // GET: Amenities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amenities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Amenities amenities)
        {
            if (ModelState.IsValid)
            {
                await _context.CreateAmenity(amenities);
                return RedirectToAction(nameof(Index));
            }
            return View(amenities);
        }

        // GET: Amenities/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var amenities = await _context.GetAmenity(id);
            if (amenities == null)
            {
                return NotFound();
            }
            return View(amenities);
        }

        // POST: Amenities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Amenities amenities)
        {
            if (id != amenities.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateAmenity(amenities);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmenitiesExists(amenities.ID))
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
            return View(amenities);
        }

        // GET: Amenities/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var amenities = await _context.GetAmenity(id);
            if (amenities == null)
            {
                return NotFound();
            }
            return View(amenities);
        }

        // POST: Amenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var amenities = await _context.GetAmenity(id);
            await _context.DeleteAmenity(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AmenitiesExists(int id)
        {
            if (_context.GetAmenity(id) != null)
            {
                return false;
            }
            return true;
        }
    }
}
