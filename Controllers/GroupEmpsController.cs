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
    public class GroupEmpsController : Controller
    {
        private readonly PlnContext _context;

        public GroupEmpsController(PlnContext context)
        {
            _context = context;
        }

        // GET: GroupEmps
        public async Task<IActionResult> Index()
        {
            //var plnContext = _context.GroupEmp.Include(g => g.Employe).Include(g => g.GroupEmpCat);
            //await plnContext.ToListAsync()

            //Liste des groupes 
            var gp = await _context.GroupEmp.ToListAsync();

            var gpn = await _context.GroupEmpCat.ToListAsync();
            
            

            return View(gpn);
        }
        public IActionResult CreateGroup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGroup([Bind("Id,Name")] GroupEmpCat groupEmpCat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupEmpCat);
                await _context.SaveChangesAsync();
                return RedirectToAction("Gest", "GroupEmps", new { id = groupEmpCat.Id });
            }
            return View(groupEmpCat);
        }

        public async Task<IActionResult> EditGroup(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupEmpCat = await _context.GroupEmpCat.FindAsync(id);
            if (groupEmpCat == null)
            {
                return NotFound();
            }
            return View(groupEmpCat);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditGroup(int id, [Bind("Id,Name")] GroupEmpCat groupEmpCat)
        {
            if (id != groupEmpCat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupEmpCat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupEmpCatExists(groupEmpCat.Id))
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
            return View(groupEmpCat);
        }

        private bool GroupEmpCatExists(int id)
        {
            return _context.GroupEmpCat.Any(e => e.Id == id);
        }

        public async Task<IActionResult> DeleteGroup(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupEmpCat = await _context.GroupEmpCat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupEmpCat == null)
            {
                return NotFound();
            }

            return View(groupEmpCat);
        }

        [HttpPost, ActionName("DeleteGroup")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteGroupConfirmed(int id)
        {
            var groupEmpCat = await _context.GroupEmpCat.FindAsync(id);
            _context.GroupEmpCat.Remove(groupEmpCat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Gest(int id)
        {

            //Liste des inscrits
            var regEmpGroup = await _context.GroupEmp.Include(g => g.Employe).Include(g => g.GroupEmpCat).Where(g => g.GroupEmpCatId == id).ToListAsync() ;

            //Recuperer d'abord tous les groupes et le nom des groupes
            var GroupSelect = await _context.GroupEmp.Where(p=>p.GroupEmpCatId==id).ToListAsync();

            //employés présent dans la liste
            var uRegistered = from U in regEmpGroup
                              select U.Employe;

            //tous les employé
            var allU = _context.Employe.ToList();
            List<Employe> empListNot = new List<Employe>();

            foreach(var emp in allU)
            {
                if(!uRegistered.Contains(emp))
                {
                    empListNot.Add(emp);
                }
            }

            //Modele du Groupe
            var group = await _context.GroupEmpCat.FindAsync(id);

            ViewBag.Group = group;
            //ViewBag.NoReg = noReg;
            ViewBag.NoReg = empListNot;
            return View(regEmpGroup);
        }

        //Fonction ajout d'un employé dans un groupe

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmp(int IdEmp,int IdGroupEmp)
        {
            //Vérification Existance de l'enregistrement 
            var exist = _context.GroupEmp.Any(p=>p.EmployeId==IdEmp && p.GroupEmpCatId == IdGroupEmp);
            //si oui : enregistrer
            if(!exist)
            {
                await _context.GroupEmp.AddAsync(new GroupEmp {EmployeId=IdEmp,GroupEmpCatId=IdGroupEmp });
                await _context.SaveChangesAsync();
            }
            else
            {

            }

            //sinon: Renvoyer erreur



            return RedirectToAction("Gest","GroupEmps",new { id = IdGroupEmp });
        }
        //Fonction de retrait
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveEmp(int toRemove,int idGest)
        {
            //Vérification Existance de l'enregistrement 
            var gp = await _context.GroupEmp.FindAsync(toRemove);
            _context.RemoveRange(gp);
            await _context.SaveChangesAsync();

            //si oui : enregistrer

            //sinon: Renvoyer erreur
            return RedirectToAction("Gest", "GroupEmps", new { id = idGest });
        }
        // GET: GroupEmps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupEmp = await _context.GroupEmp
                .Include(g => g.Employe)
                .Include(g => g.GroupEmpCat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupEmp == null)
            {
                return NotFound();
            }

            return View(groupEmp);
        }

        // GET: GroupEmps/Create
        public IActionResult Create()
        {
            ViewData["EmployeId"] = new SelectList(_context.Employe, "Id", "Nom");
            ViewData["GroupEmpCatId"] = new SelectList(_context.Set<GroupEmpCat>(), "Id", "Name");
            return View();
        }

        // POST: GroupEmps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeId,GroupEmpCatId")] GroupEmp groupEmp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupEmp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeId"] = new SelectList(_context.Employe, "Id", "Id", groupEmp.EmployeId);
            ViewData["GroupEmpCatId"] = new SelectList(_context.Set<GroupEmpCat>(), "Id", "Id", groupEmp.GroupEmpCatId);
            return View(groupEmp);
        }

        // GET: GroupEmps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupEmp = await _context.GroupEmp.FindAsync(id);
            if (groupEmp == null)
            {
                return NotFound();
            }
            ViewData["EmployeId"] = new SelectList(_context.Employe, "Id", "Id", groupEmp.EmployeId);
            ViewData["GroupEmpCatId"] = new SelectList(_context.Set<GroupEmpCat>(), "Id", "Id", groupEmp.GroupEmpCatId);
            return View(groupEmp);
        }

        // POST: GroupEmps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeId,GroupEmpCatId")] GroupEmp groupEmp)
        {
            if (id != groupEmp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupEmp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupEmpExists(groupEmp.Id))
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
            ViewData["EmployeId"] = new SelectList(_context.Employe, "Id", "Id", groupEmp.EmployeId);
            ViewData["GroupEmpCatId"] = new SelectList(_context.Set<GroupEmpCat>(), "Id", "Id", groupEmp.GroupEmpCatId);
            return View(groupEmp);
        }

        // GET: GroupEmps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupEmp = await _context.GroupEmp
                .Include(g => g.Employe)
                .Include(g => g.GroupEmpCat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupEmp == null)
            {
                return NotFound();
            }

            return View(groupEmp);
        }

        // POST: GroupEmps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupEmp = await _context.GroupEmp.FindAsync(id);
            _context.GroupEmp.Remove(groupEmp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupEmpExists(int id)
        {
            return _context.GroupEmp.Any(e => e.Id == id);
        }
    }
}
