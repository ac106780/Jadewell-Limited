using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Areas.Identity.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class WorkersController : Controller
    {
        private readonly WebApplication1ContextDB _context;

        public WorkersController(WebApplication1ContextDB context)
        {
            _context = context;
        }

        // GET: Workers
        public async Task<IActionResult> Index()
        {
            var webApplication1ContextDB = _context.Workers.Include(w => w.House);
            return View(await webApplication1ContextDB.ToListAsync());
        }

        // GET: Workers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Workers == null)
            {
                return NotFound();
            }

            var workers = await _context.Workers
                .Include(w => w.House)
                .FirstOrDefaultAsync(m => m.WorkersID == id);
            if (workers == null)
            {
                return NotFound();
            }

            return View(workers);
        }

        // GET: Workers/Create
        public IActionResult Create()
        {
            ViewData["HouseID"] = new SelectList(_context.Set<House>(), "HouseID", "BuyPrice");
            return View();
        }

        // POST: Workers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkersID,FirstName,LastName,Phone,HouseID")] Workers workers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HouseID"] = new SelectList(_context.Set<House>(), "HouseID", "BuyPrice", workers.HouseID);
            return View(workers);
        }

        // GET: Workers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Workers == null)
            {
                return NotFound();
            }

            var workers = await _context.Workers.FindAsync(id);
            if (workers == null)
            {
                return NotFound();
            }
            ViewData["HouseID"] = new SelectList(_context.Set<House>(), "HouseID", "BuyPrice", workers.HouseID);
            return View(workers);
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkersID,FirstName,LastName,Phone,HouseID")] Workers workers)
        {
            if (id != workers.WorkersID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkersExists(workers.WorkersID))
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
            ViewData["HouseID"] = new SelectList(_context.Set<House>(), "HouseID", "BuyPrice", workers.HouseID);
            return View(workers);
        }

        // GET: Workers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Workers == null)
            {
                return NotFound();
            }

            var workers = await _context.Workers
                .Include(w => w.House)
                .FirstOrDefaultAsync(m => m.WorkersID == id);
            if (workers == null)
            {
                return NotFound();
            }

            return View(workers);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Workers == null)
            {
                return Problem("Entity set 'WebApplication1ContextDB.Workers'  is null.");
            }
            var workers = await _context.Workers.FindAsync(id);
            if (workers != null)
            {
                _context.Workers.Remove(workers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkersExists(int id)
        {
            return _context.Workers.Any(e => e.WorkersID == id);
        }
    }
}
