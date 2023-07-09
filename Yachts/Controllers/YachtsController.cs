using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Yachts.Models;
using Yachts.Utils;

namespace Yachts.Controllers
{
    public class YachtsController : Controller
    {
        private readonly YachtsDbContext _context;

        public YachtsController(YachtsDbContext context)
        {
            _context = context;
        }

        // GET: Yachts
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated) 
            {
                return View("AdminYachtList", await _context.Yachts.ToListAsync());
            }
            return View(await _context.Yachts.ToListAsync());
        }

        // GET: Yachts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Yachts == null)
            {
                return NotFound();
            }

            var yacht = await _context.Yachts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yacht == null)
            {
                return NotFound();
            }

            return View(yacht);
        }

        [Authorize]
        // GET: Yachts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yachts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,PricePerDay,PhotoUrl,Description")] Yacht yacht)
        {
                _context.Add(yacht);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        [Authorize]
        // GET: Yachts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Yachts == null)
            {
                return NotFound();
            }

            var yacht = await _context.Yachts.FindAsync(id);
            if (yacht == null)
            {
                return NotFound();
            }
            return View(yacht);
        }

        // POST: Yachts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,PricePerDay,PhotoUrl,Description")] Yacht yacht)
        {
            if (id != yacht.Id)
            {
                return NotFound();
            }
            try
            {
                _context.Update(yacht);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YachtExists(yacht.Id))
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

        [Authorize]
        // GET: Yachts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Yachts == null)
            {
                return NotFound();
            }

            var yacht = await _context.Yachts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yacht == null)
            {
                return NotFound();
            }

            return View(yacht);
        }

        [Authorize]
        // POST: Yachts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Yachts == null)
            {
                return Problem("Entity set 'YachtsDbContext.Yachts'  is null.");
            }
            var yacht = await _context.Yachts.FindAsync(id);
            if (yacht != null)
            {
                _context.Yachts.Remove(yacht);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YachtExists(int id)
        {
          return _context.Yachts.Any(e => e.Id == id);
        }
    }
}
