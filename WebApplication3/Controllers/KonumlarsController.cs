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
    public class KonumlarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KonumlarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Konumlars
        public async Task<IActionResult> Index()
        {
              return _context.Konumlars != null ? 
                          View(await _context.Konumlars.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Konumlars'  is null.");
        }

        // GET: Konumlars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Konumlars == null)
            {
                return NotFound();
            }

            var konumlar = await _context.Konumlars
                .FirstOrDefaultAsync(m => m.KonumId == id);
            if (konumlar == null)
            {
                return NotFound();
            }

            return View(konumlar);
        }

        // GET: Konumlars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Konumlars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KonumId,KonumAdi")] Konumlar konumlar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(konumlar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(konumlar);
        }

        // GET: Konumlars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Konumlars == null)
            {
                return NotFound();
            }

            var konumlar = await _context.Konumlars.FindAsync(id);
            if (konumlar == null)
            {
                return NotFound();
            }
            return View(konumlar);
        }

        // POST: Konumlars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KonumId,KonumAdi")] Konumlar konumlar)
        {
            if (id != konumlar.KonumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(konumlar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KonumlarExists(konumlar.KonumId))
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
            return View(konumlar);
        }

        // GET: Konumlars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Konumlars == null)
            {
                return NotFound();
            }

            var konumlar = await _context.Konumlars
                .FirstOrDefaultAsync(m => m.KonumId == id);
            if (konumlar == null)
            {
                return NotFound();
            }

            return View(konumlar);
        }

        // POST: Konumlars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Konumlars == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Konumlars'  is null.");
            }
            var konumlar = await _context.Konumlars.FindAsync(id);
            if (konumlar != null)
            {
                _context.Konumlars.Remove(konumlar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KonumlarExists(int id)
        {
          return (_context.Konumlars?.Any(e => e.KonumId == id)).GetValueOrDefault();
        }
    }
}
