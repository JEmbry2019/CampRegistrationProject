using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CampRegistrationProject.Data;
using CampRegistrationProject.Models;

namespace CampRegistrationProject.Controllers
{
    public class CampRegistrationProject : Controller
    {
        private readonly CampRegistrationProjectContext _context;

        public CampRegistrationProject(CampRegistrationProjectContext context)
        {
            _context = context;
        }

        // GET: CampRegistrationProject
        public async Task<IActionResult> Index()
        {
            return View(await _context.Camper.ToListAsync());
        }

        // GET: CampRegistrationProject/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campers = await _context.Camper
                .FirstOrDefaultAsync(m => m.ID == id);
            if (campers == null)
            {
                return NotFound();
            }

            return View(campers);
        }

        // GET: CampRegistrationProject/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CampRegistrationProject/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastName,FirstMidName,EnrollmentDate")] Campers campers)
        {
            if (ModelState.IsValid)
            {
                campers.ID = Guid.NewGuid();
                _context.Add(campers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(campers);
        }

        // GET: CampRegistrationProject/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campers = await _context.Camper.FindAsync(id);
            if (campers == null)
            {
                return NotFound();
            }
            return View(campers);
        }

        // POST: CampRegistrationProject/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,LastName,FirstMidName,EnrollmentDate")] Campers campers)
        {
            if (id != campers.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampersExists(campers.ID))
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
            return View(campers);
        }

        // GET: CampRegistrationProject/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campers = await _context.Camper
                .FirstOrDefaultAsync(m => m.ID == id);
            if (campers == null)
            {
                return NotFound();
            }

            return View(campers);
        }

        // POST: CampRegistrationProject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var campers = await _context.Camper.FindAsync(id);
            _context.Camper.Remove(campers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampersExists(Guid id)
        {
            return _context.Camper.Any(e => e.ID == id);
        }
    }
}
