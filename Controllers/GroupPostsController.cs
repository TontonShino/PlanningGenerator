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
    public class GroupPostsController : Controller
    {
        private readonly PlnContext _context;

        public GroupPostsController(PlnContext context)
        {
            _context = context;
        }


        // Récuperation de la liste des GroupPostCats
        public async Task<IActionResult> Index()
        {
            

            var gpn = await _context.GroupPostCat.ToListAsync();
            var gp = await _context.GroupPost.ToListAsync();

            return View(gpn);
        }

        public async Task<IActionResult> Gest(int id)
        {

            //Liste des postes inscris
            var regPostGroup = await _context.GroupPost.Include(p => p.Post).Include(gpc => gpc.GroupPostCat).Where(g => g.GroupPostCatId == id).ToListAsync();

            //Liste des postes dans la liste
            var pRegisterd = from P in regPostGroup
                             select P.Post;

            //Tous les postes
            var AllP = await _context.Post.ToListAsync();

            //Création d'une liste poste non inclus dans la liste
            List<Post> postListNot = new List<Post>();

            foreach(var p in AllP)
            {
                if(!pRegisterd.Contains(p))
                {
                    postListNot.Add(p);
                }
            }

            ViewBag.NoReg = postListNot;
            ViewBag.Group = await _context.GroupPostCat.FindAsync(id); //Infos du groupe selectionné
            return View(regPostGroup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPost(int IdPost, int IdGroupPost)
        {
            //Vérification de l'existance de l'enregistrement
            var exist = _context.GroupPost.Any(p=>p.PostId==IdPost && p.GroupPostCatId == IdGroupPost);
            GroupPost toAdd = new GroupPost
            {
                PostId = IdPost,
                GroupPostCatId = IdGroupPost
            };


            if (!exist)
            {
                await _context.GroupPost.AddAsync(toAdd);
                await _context.SaveChangesAsync();
            }
            else
            {

            }

            return RedirectToAction("Gest","GroupPosts", new {id = IdGroupPost });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemovePost(int toRemove,int idGest)
        {
            //Vérification de l'existance de l'enregistrement
            var gp = await _context.GroupPost.FindAsync(toRemove);

            
                _context.RemoveRange(gp);
                await _context.SaveChangesAsync();

            return RedirectToAction("Gest","GroupPosts", new { id = idGest});
            
        }

        // GET: GroupPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupPost = await _context.GroupPost
                .Include(g => g.GroupPostCat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupPost == null)
            {
                return NotFound();
            }

            return View(groupPost);
        }

        // GET: GroupPosts/Create
        public IActionResult Create()
        {
            ViewData["GroupPostCatId"] = new SelectList(_context.Set<GroupPostCat>(), "Id", "Id");
            return View();
        }

        // POST: GroupPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PosteId,GroupPostCatId")] GroupPost groupPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupPostCatId"] = new SelectList(_context.Set<GroupPostCat>(), "Id", "Id", groupPost.GroupPostCatId);
            return View(groupPost);
        }

        // GET: GroupPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupPost = await _context.GroupPost.FindAsync(id);
            if (groupPost == null)
            {
                return NotFound();
            }
            ViewData["GroupPostCatId"] = new SelectList(_context.Set<GroupPostCat>(), "Id", "Id", groupPost.GroupPostCatId);
            return View(groupPost);
        }

        // POST: GroupPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PosteId,GroupPostCatId")] GroupPost groupPost)
        {
            if (id != groupPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupPostExists(groupPost.Id))
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
            ViewData["GroupPostCatId"] = new SelectList(_context.Set<GroupPostCat>(), "Id", "Id", groupPost.GroupPostCatId);
            return View(groupPost);
        }

        // GET: GroupPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupPost = await _context.GroupPost
                .Include(g => g.GroupPostCat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupPost == null)
            {
                return NotFound();
            }

            return View(groupPost);
        }

        // POST: GroupPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupPost = await _context.GroupPost.FindAsync(id);
            _context.GroupPost.Remove(groupPost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupPostExists(int id)
        {
            return _context.GroupPost.Any(e => e.Id == id);
        }
        //Section GroupPostCat
        public IActionResult CreateGroup()
        {
            return View();
        }

        // [Bind("Id,PosteId,GroupPostCatId")] GroupPost groupPost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGroup([Bind("Id","Name")] GroupPostCat groupPostCat)
        {
            if(ModelState.IsValid)
            {
                _context.Add(groupPostCat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> DeleteGroup(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupPostCat = await _context.GroupPostCat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupPostCat == null)
            {
                return NotFound();
            }

            return View(groupPostCat);
        }

        [HttpPost, ActionName("DeleteGroup")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteGroupConfirmed(int id)
        {
            var groupPostCat = await _context.GroupPostCat.FindAsync(id);
            _context.GroupPostCat.Remove(groupPostCat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditGroup(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupPostCat = await _context.GroupPostCat.FindAsync(id);
            if (groupPostCat == null)
            {
                return NotFound();
            }
            return View(groupPostCat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditGroup(int id, [Bind("Id", "Name")] GroupPostCat groupPostCat)
        {
            if (id != groupPostCat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupPostCat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupPostCatExists(groupPostCat.Id))
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
            return View(groupPostCat);
        }

        private bool GroupPostCatExists(int id)
        {
            return _context.GroupPostCat.Any(e => e.Id == id);
    }

    }


}

