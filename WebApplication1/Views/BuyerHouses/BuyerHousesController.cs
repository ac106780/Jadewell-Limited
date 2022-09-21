using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Areas.Identity.Data;
using WebApplication1.Models;

namespace WebApplication1.Views.BuyerHouses
{
    public class BuyerHousesController : Controller
    {
        private readonly WebApplication1ContextDB _context;

        public BuyerHousesController(WebApplication1ContextDB context)
        {
            _context = context;
        }

        // GET: BuyerHouses
        public async Task<IActionResult> Index()
        {
            var webApplication1ContextDB = _context.BuyerHouse.Include(b => b.House);
            return View(await webApplication1ContextDB.ToListAsync());
        }

        // GET: BuyerHouses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BuyerHouse == null)
            {
                return NotFound();
            }

            var buyerHouse = await _context.BuyerHouse
                .Include(b => b.House)
                .FirstOrDefaultAsync(m => m.BuyerHouseID == id);
            if (buyerHouse == null)
            {
                return NotFound();
            }

            return View(buyerHouse);
        }

        // GET: BuyerHouses/Create
        public IActionResult Create()
        {
            ViewData["HouseID"] = new SelectList(_context.House, "HouseID", "BuyPrice");
            return View();
        }

        // POST: BuyerHouses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BuyerHouseID,HouseID,BuyerID")] BuyerHouse buyerHouse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buyerHouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HouseID"] = new SelectList(_context.House, "HouseID", "BuyPrice", buyerHouse.HouseID);
            return View(buyerHouse);
        }

        // GET: BuyerHouses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BuyerHouse == null)
            {
                return NotFound();
            }

            var buyerHouse = await _context.BuyerHouse.FindAsync(id);
            if (buyerHouse == null)
            {
                return NotFound();
            }
            ViewData["HouseID"] = new SelectList(_context.House, "HouseID", "BuyPrice", buyerHouse.HouseID);
            return View(buyerHouse);
        }

        // POST: BuyerHouses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BuyerHouseID,HouseID,BuyerID")] BuyerHouse buyerHouse)
        {
            if (id != buyerHouse.BuyerHouseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buyerHouse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyerHouseExists(buyerHouse.BuyerHouseID))
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
            ViewData["HouseID"] = new SelectList(_context.House, "HouseID", "BuyPrice", buyerHouse.HouseID);
            return View(buyerHouse);
        }

        // GET: BuyerHouses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BuyerHouse == null)
            {
                return NotFound();
            }

            var buyerHouse = await _context.BuyerHouse
                .Include(b => b.House)
                .FirstOrDefaultAsync(m => m.BuyerHouseID == id);
            if (buyerHouse == null)
            {
                return NotFound();
            }

            return View(buyerHouse);
        }

        // POST: BuyerHouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BuyerHouse == null)
            {
                return Problem("Entity set 'WebApplication1ContextDB.BuyerHouse'  is null.");
            }
            var buyerHouse = await _context.BuyerHouse.FindAsync(id);
            if (buyerHouse != null)
            {
                _context.BuyerHouse.Remove(buyerHouse);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuyerHouseExists(int id)
        {
          return _context.BuyerHouse.Any(e => e.BuyerHouseID == id);
        }
    }
}
