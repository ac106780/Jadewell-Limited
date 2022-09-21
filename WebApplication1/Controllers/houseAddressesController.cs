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
    public class houseAddressesController : Controller
    {
        private readonly WebApplication1ContextDB _context;

        public houseAddressesController(WebApplication1ContextDB context)
        {
            _context = context;
        }

        // GET: houseAddresses
        public async Task<IActionResult> Index()
        {
            var webApplication1ContextDB = _context.houseAddress.Include(h => h.House);
            return View(await webApplication1ContextDB.ToListAsync());
        }

        // GET: houseAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.houseAddress == null)
            {
                return NotFound();
            }

            var houseAddress = await _context.houseAddress
                .Include(h => h.House)
                .FirstOrDefaultAsync(m => m.houseAddressID == id);
            if (houseAddress == null)
            {
                return NotFound();
            }

            return View(houseAddress);
        }

        // GET: houseAddresses/Create
        public IActionResult Create()
        {
            ViewData["HouseID"] = new SelectList(_context.House, "HouseID", "BuyPrice");
            return View();
        }

        // POST: houseAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("houseAddressID,Number,Street,Suburb,ZIP,HouseID")] houseAddress houseAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(houseAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HouseID"] = new SelectList(_context.House, "HouseID", "BuyPrice", houseAddress.HouseID);
            return View(houseAddress);
        }

        // GET: houseAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.houseAddress == null)
            {
                return NotFound();
            }

            var houseAddress = await _context.houseAddress.FindAsync(id);
            if (houseAddress == null)
            {
                return NotFound();
            }
            ViewData["HouseID"] = new SelectList(_context.House, "HouseID", "BuyPrice", houseAddress.HouseID);
            return View(houseAddress);
        }

        // POST: houseAddresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("houseAddressID,Number,Street,Suburb,ZIP,HouseID")] houseAddress houseAddress)
        {
            if (id != houseAddress.houseAddressID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(houseAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!houseAddressExists(houseAddress.houseAddressID))
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
            ViewData["HouseID"] = new SelectList(_context.House, "HouseID", "BuyPrice", houseAddress.HouseID);
            return View(houseAddress);
        }

        // GET: houseAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.houseAddress == null)
            {
                return NotFound();
            }

            var houseAddress = await _context.houseAddress
                .Include(h => h.House)
                .FirstOrDefaultAsync(m => m.houseAddressID == id);
            if (houseAddress == null)
            {
                return NotFound();
            }

            return View(houseAddress);
        }

        // POST: houseAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.houseAddress == null)
            {
                return Problem("Entity set 'WebApplication1ContextDB.houseAddress'  is null.");
            }
            var houseAddress = await _context.houseAddress.FindAsync(id);
            if (houseAddress != null)
            {
                _context.houseAddress.Remove(houseAddress);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool houseAddressExists(int id)
        {
            return _context.houseAddress.Any(e => e.houseAddressID == id);
        }
    }
}
