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
    public class TypeEmpsController : Controller
    {
        private readonly PlnContext _context;

        public TypeEmpsController(PlnContext context)
        {
            _context = context;
        }

        // GET: TypeEmps
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeEmp.ToListAsync());
        }

        // GET: TypeEmps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeEmp = await _context.TypeEmp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeEmp == null)
            {
                return NotFound();
            }

            return View(typeEmp);
        }

        // GET: TypeEmps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeEmps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,NbHeure,Half")] TypeEmp typeEmp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeEmp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeEmp);
        }

        // GET: TypeEmps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeEmp = await _context.TypeEmp.FindAsync(id);
            if (typeEmp == null)
            {
                return NotFound();
            }
            return View(typeEmp);
        }

        // POST: TypeEmps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,NbHeure,Half")] TypeEmp typeEmp)
        {
            if (id != typeEmp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeEmp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeEmpExists(typeEmp.Id))
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
            return View(typeEmp);
        }

        // GET: TypeEmps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeEmp = await _context.TypeEmp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeEmp == null)
            {
                return NotFound();
            }

            return View(typeEmp);
        }

        // POST: TypeEmps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeEmp = await _context.TypeEmp.FindAsync(id);
            _context.TypeEmp.Remove(typeEmp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeEmpExists(int id)
        {
            return _context.TypeEmp.Any(e => e.Id == id);
        }
    }
}
