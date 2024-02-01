using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ResimlersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResimlersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Resimlers
        public async Task<IActionResult> Index()
        {
              return _context.Resimlers != null ? 
                          View(await _context.Resimlers.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Resimlers'  is null.");
        }

        // GET: Resimlers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Resimlers == null)
            {
                return NotFound();
            }

            var resimler = await _context.Resimlers
                .FirstOrDefaultAsync(m => m.ResimId == id);
            if (resimler == null)
            {
                return NotFound();
            }

            return View(resimler);
        }

        // GET: Resimlers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Resimlers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResimId,ResimAd")] Resimler resimler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resimler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resimler);
        }

        // GET: Resimlers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Resimlers == null)
            {
                return NotFound();
            }

            var resimler = await _context.Resimlers.FindAsync(id);
            if (resimler == null)
            {
                return NotFound();
            }
            return View(resimler);
        }

        // POST: Resimlers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResimId,ResimAd")] Resimler resimler)
        {
            if (id != resimler.ResimId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resimler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResimlerExists(resimler.ResimId))
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
            return View(resimler);
        }

        // GET: Resimlers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Resimlers == null)
            {
                return NotFound();
            }

            var resimler = await _context.Resimlers
                .FirstOrDefaultAsync(m => m.ResimId == id);
            if (resimler == null)
            {
                return NotFound();
            }

            return View(resimler);
        }

        // POST: Resimlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Resimlers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Resimlers'  is null.");
            }
            var resimler = await _context.Resimlers.FindAsync(id);
            if (resimler != null)
            {
                _context.Resimlers.Remove(resimler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResimlerExists(int id)
        {
          return (_context.Resimlers?.Any(e => e.ResimId == id)).GetValueOrDefault();
        }
    }
}
