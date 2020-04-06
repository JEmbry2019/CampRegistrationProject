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
    public class CamperController : Controller
    {
        private readonly CampRegistrationProjectContext _context;

        public CamperController(CampRegistrationProjectContext context)
        {
            _context = context;
        }

        // GET: Camper
        public async Task<IActionResult> Index()
        {
            return View(await _context.Campers.ToListAsync());
        }

        // GET: Camper/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camper = await _context.Campers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (camper == null)
            {
                return NotFound();
            }

            return View(camper);
        }

        // GET: Camper/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Camper/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastName,FirstMidName,Email,EnrollmentDate")] Camper camper)
        {
            if (ModelState.IsValid)
            {
                camper.ID = Guid.NewGuid();
                _context.Add(camper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(camper);
        }

        // GET: Camper/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camper = await _context.Campers.FindAsync(id);
            if (camper == null)
            {
                return NotFound();
            }
            return View(camper);
        }

        // POST: Camper/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,LastName,FirstMidName,Email,EnrollmentDate")] Camper camper)
        {
            if (id != camper.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(camper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CamperExists(camper.ID))
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
            return View(camper);
        }

        // GET: Camper/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camper = await _context.Campers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (camper == null)
            {
                return NotFound();
            }

            return View(camper);
        }

        // POST: Camper/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var camper = await _context.Campers.FindAsync(id);
            _context.Campers.Remove(camper);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CamperExists(Guid id)
        {
            return _context.Campers.Any(e => e.ID == id);
        }
    }
}
