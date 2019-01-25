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
    public class EmployesController : Controller
    {
        private readonly PlnContext _context;

        public EmployesController(PlnContext context)
        {
            _context = context;
        }

        // GET: Employes
        public async Task<IActionResult> Index()
        {
            List<TypeEmp> t = await _context.TypeEmp.ToListAsync();
            List<Employe> emp = await _context.Employe.ToListAsync();
            

            return View(emp);
        }

        // GET: Employes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employe = await _context.Employe
                .FirstOrDefaultAsync(m => m.Id == id);
            //Employe emp = await _context.Employe.FindAsync(id);
            TypeEmp typemp = await _context.TypeEmp.FindAsync(employe.TypeEmpId);
            //emp.TypeEmp = typemp;
            if (employe == null)
            {
                return NotFound();
            }

            return View(employe);
        }

        // GET: Employes/Create
        public IActionResult Create()
        {
            var t = _context.TypeEmp.ToList();
            ViewBag.ListOfTypeEmp = t;
            return View();
        }

        // POST: Employes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,TypeEmpId")] Employe employe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employe);
        }

        // GET: Employes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employe = await _context.Employe.FindAsync(id);
            var type = await _context.TypeEmp.ToListAsync();
            ViewBag.TypeEmp = new SelectList(_context.TypeEmp, "Id", "Nom");
            
            if (employe == null)
            {
                return NotFound();
            }
            return View(employe);
        }

        // POST: Employes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,TypeEmpId")] Employe employe)
        {
            if (id != employe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeExists(employe.Id))
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
            return View(employe);
        }

        // GET: Employes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employe = await _context.Employe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employe == null)
            {
                return NotFound();
            }

            return View(employe);
        }

        // POST: Employes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employe = await _context.Employe.FindAsync(id);
            _context.Employe.Remove(employe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeExists(int id)
        {
            return _context.Employe.Any(e => e.Id == id);
        }
    }
}
