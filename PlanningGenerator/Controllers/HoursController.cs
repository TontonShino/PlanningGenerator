using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlanningGenerator.Models.Pln;

namespace PlanningGenerator.Controllers
{
    public class HoursController : Controller
    {
        private readonly PlnContext _context;

        public HoursController(PlnContext context)
        {
            _context = context;
        }

       

        // GET: Hours
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hour.ToListAsync());
        }

        // GET: Hours/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hour = await _context.Hour
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hour == null)
            {
                return NotFound();
            }

            return View(hour);
        }

        // GET: Hours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,_hour,_minutes,_hms")] Hour hour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hour);
        }

        // GET: Hours/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hour = await _context.Hour.FindAsync(id);
            if (hour == null)
            {
                return NotFound();
            }
            return View(hour);
        }

        // POST: Hours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,_hour,_minutes,_hms")] Hour hour)
        {
            if (id != hour.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HourExists(hour.Id))
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
            return View(hour);
        }

        // GET: Hours/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hour = await _context.Hour
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hour == null)
            {
                return NotFound();
            }

            return View(hour);
        }

        // POST: Hours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var hour = await _context.Hour.FindAsync(id);
            _context.Hour.Remove(hour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HourExists(string id)
        {
            return _context.Hour.Any(e => e.Id == id);
        }
    }
}
