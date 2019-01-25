using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlanningGenerator.Models.Pln;
using PlanningGenerator.Models;

namespace PlanningGenerator.Controllers
{
    public class PlanningsController : Controller
    {
        private readonly PlnContext _context;

        public PlanningsController(PlnContext context)
        {
            _context = context;
        }


        //Todo: Modifier  
        public IActionResult Create()
        {
            //Liste du groupe de poste ViewBag.GroupPostCatId
            ViewBag.GroupPostCatId = new SelectList(_context.GroupPostCat,"Id","Name");

            //Liste du groupe d'employé ViewBag.GroupEmpCatId
            ViewBag.GroupEmpCatId = new SelectList(_context.GroupEmpCat,"Id","Name");

            //Liste des jours starting/ending
            ViewBag.Days = new SelectList(_context.Day, "Id", "Fr");

            //Liste des heures ViewBag.Hours
            ViewBag.Hours = new SelectList(_context.Hour, "Id","Id");

            return View();
        }

        public async Task<IActionResult> Generate(int id)
        {
            //Avoir l'id du groupe poste (paramètres deu planning)
            var pParams = await _context.Planning.FindAsync(id);

            //Avoir l'id du groupe emp

            //Liste des enregistrements : employés + nombre de plots
            var RegisEmp = GetRegisteredEmp(pParams.GroupEmpCatId);

            var RegisPost = GetPostRegistered(pParams.GroupPostCatId);

            List<PostRegisterd> postRegisterd = new List<PostRegisterd>();
            List<EmpRegisterd> SettedEmp = SetEmpRegistered(RegisEmp);

            var days = _context.Day.ToList();
            var hours = _context.Hour.ToList();

            string min = pParams.StartingHourId;
            string max = pParams.EndingHourId;

            //Liste des enregistrements : postes
            List<Dhe> dhes = new List<Dhe>();


            List<Day> selectedDays = new List<Day>();
            List<Hour> hoursSelected = new List<Hour>();

            //TODO: trouver l'équilibre des ifs pour les 4 conditions

            if ((pParams.FullJourney == true) && (pParams.FullWeek == true))
            {
                selectedDays = days;
                hoursSelected = hours;
                
                Console.WriteLine("Toute la journée , toute la semaine");
                postRegisterd = SetDheOnlyByPost(selectedDays,hoursSelected,RegisPost,postRegisterd);
                dhes = SetDheOnly(selectedDays, hoursSelected,RegisPost, postRegisterd);
            }
                    

            if(pParams.FullJourney == true && pParams.FullWeek == false)
            {
                Console.WriteLine("Toute la journée , semaine personnalisé");


                hoursSelected = hours;
                DaysSelector(pParams, days, selectedDays);

                postRegisterd = SetDheOnlyByPost(selectedDays, hoursSelected, RegisPost, postRegisterd);
                dhes = SetDheOnly(selectedDays, hoursSelected, RegisPost, postRegisterd);

            }


            if (pParams.FullJourney == false && pParams.FullWeek == true)
            {
                Console.WriteLine("horaire personnalisé, toute la semaine");

                hoursSelected = HourSelector(hours, min, ref max);
                selectedDays = days;
                postRegisterd = SetDheOnlyByPost(selectedDays, hoursSelected, RegisPost, postRegisterd);
                dhes = SetDheOnly(selectedDays, hoursSelected,RegisPost, postRegisterd);

            }

            if (pParams.FullJourney == false && pParams.FullWeek == false)
            { 
                Console.WriteLine("Horaire personnalisé, jours personnalisés");


                
                hoursSelected = HourSelector(hours, min, ref max);
                DaysSelector(pParams, days, selectedDays);
                postRegisterd = SetDheOnlyByPost(selectedDays, hoursSelected, RegisPost, postRegisterd);

                dhes = SetDheOnly(selectedDays,hoursSelected,RegisPost, postRegisterd);

            }
            


            foreach(var i in dhes)
            {
                Console.WriteLine($"Jour:{i.DayId} Heure:{i.HourId}");
            }
            PlanningMananger planningMananger = new PlanningMananger(SettedEmp, postRegisterd);
            planningMananger.PostProcess();
            planningMananger.MainProcess();

            ViewBag.Days = selectedDays;
            ViewBag.Hours = hoursSelected;
            ViewBag.Dhes = postRegisterd;
            return View(dhes);
        }

        private static void DaysSelector(Planning pParams, List<Day> days, List<Day> selectedDay)
        {
            for (int i = pParams.StartingDayId; i <= pParams.EndingDayId; i++)
            {
                selectedDay.Add(days[i-1]);
            }
        }

        private static List<Hour> HourSelector(List<Hour> hours, string min, ref string max)
        {
            int CursorMin = 0, CursorMax = 0;

            if (max == "00:00")
            {
                max = "23:30";
            }

            List<Hour> hourSelected = new List<Hour>();

            for (int i = 0; i < hours.Count; i++)
            {
                if (hours[i].Id == min)
                {
                    CursorMin = i;
                }
                if (hours[i].Id == max)
                {
                    CursorMax = i;
                }
            }

            for (int i = CursorMin; i <= CursorMax; i++)
            {

                hourSelected.Add(hours[i]);

            }

            return hourSelected;
        }

        public List<Dhe> SetDheOnly(List<Day> _d, List<Hour> _h, List<Post> _regisPost,List<PostRegisterd> postRegisterds)
        {
            List<Dhe> lDhe = new List<Dhe>();

            foreach (var post in _regisPost)
            {

                for (int d = 0; d < _d.Count; d++)
                {
                    for (int h = 0; h < _h.Count; h++)
                    {
                        lDhe.Add(new Dhe
                        {
                            HourId = _h[h].Id,
                            DayId = _d[d].Id,
                            PostId = post.Id

                        });
                    }

                }
            }
                return lDhe;
            
        }

        public List<PostRegisterd> SetDheOnlyByPost(List<Day> _d, List<Hour> _h, List<Post> _regisPost, List<PostRegisterd> postRegisterds)
        {
            List<Dhe> lDhe = new List<Dhe>();

            foreach (var p in _regisPost)
            {
                postRegisterds.Add(new PostRegisterd {
                    IdPost = p.Id,
                    Post = p
                });
            }

            //Créer un liste de dhe

            // que l'on donne ensuite à l'objet de la liste

            foreach (var p in postRegisterds)
            {


                for (int d = 0; d < _d.Count; d++)
                {
                    lDhe = null;
                    lDhe = new List<Dhe>();

                    for (int h = 0; h < _h.Count; h++)
                    {
                        lDhe.Add(new Dhe
                        {
                            HourId = _h[h].Id,
                            DayId = _d[d].Id,
                            PostId = p.IdPost,
                            

                        });


                    }

                    switch (_d[d].Id)
                    {
                        case 1:
                            p.Monday = lDhe;
                            break;
                        case 2:
                            p.Tuesday = lDhe;
                            break;
                        case 3:
                            p.Wednesay = lDhe;
                            break;
                        case 4:
                            p.Thursday = lDhe;
                            break;
                        case 5:
                            p.Friday = lDhe;
                            break;
                        case 6:
                            p.Saturday = lDhe;
                            break;
                        case 7:
                            p.Sunday = lDhe;
                            break;
                    }

                }
            }
            return postRegisterds;

        }

        public List<Dhe> SetDhePosts(List<Post> _regisPost,List<Dhe> _defaultDhe)
        {
            List<Dhe> lDhe = new List<Dhe>();

            for(int rp=0; rp<_regisPost.Count;rp++)
            {
                for(int dhec = 0;dhec<_defaultDhe.Count;dhec++)
                { 
                    Dhe tempDhe = _defaultDhe[dhec];
                    tempDhe.PostId = _regisPost[rp].Id;

                lDhe.Add(tempDhe);
                }

            }
            
            return lDhe;
        }

        public List<EmpRegisterd> SetEmpRegistered(List<Employe> lEmp)
        {
            List<EmpRegisterd> lEmpRegistred = new List<EmpRegisterd>();

            for (int i = 0; i < lEmp.Count; i++)
            {
                lEmpRegistred.Add(new EmpRegisterd
                {
                    IdUser = lEmp[i].Id,
                    NbCone = SetCones(lEmp[i]),
                    Employe = lEmp[i],
                    ConeLeft = SetCones(lEmp[i])
                });
            }
            return lEmpRegistred;
        }

        public IActionResult Generated(int id)
        {
            return View();
        }

        public List<Employe> GetRegisteredEmp(int id)
        {
            var regEmpGroup =  _context.GroupEmp.Include(g => g.Employe).Include(g => g.GroupEmpCat).Where(g => g.GroupEmpCatId == id).ToList();
            //employés présent dans la liste
            var uRegistered = from U in regEmpGroup
                              select U.Employe;
            return uRegistered.ToList();
        }

        public List<Post> GetPostRegistered(int id)
        {
            //Liste des postes inscris
            var regPostGroup =  _context.GroupPost.Include(p => p.Post).Include(gpc => gpc.GroupPostCat).Where(g => g.GroupPostCatId == id).ToList();

            //Liste des postes dans la liste
            var pRegisterd = from P in regPostGroup
                             select P.Post;

            return pRegisterd.ToList();
        }

        public  int SetCones(Employe emp)
        {
            var empType =  _context.TypeEmp.Find(emp.TypeEmpId);

            if(empType.Half==true)
            {
                return (empType.NbHeure * 2) + 1;
            }
            else
            {
                return empType.NbHeure * 2;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nom", "GroupPostCatId", "GroupEmpCatId", "StartingDayId", "EndingDayId", "StartingHourId", "EndingHourId", "FullWeek","FullJourney")]Planning planning)
        {
            if(ModelState.IsValid)
            {
                planning.CreatedAt = DateTime.UtcNow;
                _context.Add(planning);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Plannings
        public async Task<IActionResult> Index()
        {
            //Rajouter autres infos
            return View(await _context.Planning.ToListAsync());
        }

        // GET: Plannings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planning = await _context.Planning
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planning == null)
            {
                return NotFound();
            }

            return View(planning);
        }

        // GET: Plannings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planning = await _context.Planning.FindAsync(id);
            if (planning == null)
            {
                return NotFound();
            }
            return View(planning);
        }

        // POST: Plannings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom")] Planning planning)
        {
            if (id != planning.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planning);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanningExists(planning.Id))
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
            return View(planning);
        }

        // GET: Plannings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planning = await _context.Planning
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planning == null)
            {
                return NotFound();
            }

            return View(planning);
        }

        // POST: Plannings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planning = await _context.Planning.FindAsync(id);
            _context.Planning.Remove(planning);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Dupplication Planning
        public async Task<IActionResult> Dupplicate(int id)
        {
            if(PlanningExists(id))
            {
                var toDupplicate  = await _context.Planning.FindAsync(id);
                toDupplicate.Nom = toDupplicate.Nom + " - copie";
                toDupplicate.Id = 0;

                await _context.AddAsync(toDupplicate);
                await _context.SaveChangesAsync();

                
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PlanningExists(int id)
        {
            return _context.Planning.Any(e => e.Id == id);
        }
    }
}
