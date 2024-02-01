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
    public class ReklamlarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReklamlarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reklamlars
        public async Task<IActionResult> Index()
        {
              return _context.Reklamlars != null ? 
                          View(await _context.Reklamlars.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Reklamlars'  is null.");
        }

        // GET: Reklamlars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reklamlars == null)
            {
                return NotFound();
            }

            var reklamlar = await _context.Reklamlars
                .FirstOrDefaultAsync(m => m.ReklamId == id);
            if (reklamlar == null)
            {
                return NotFound();
            }

            return View(reklamlar);
        }

        // GET: Reklamlars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reklamlars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReklamId,ReklamKonusu,ReklamResim,KonumId")] Reklam reklamlar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reklamlar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reklamlar);
        }

        // GET: Reklamlars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reklamlars == null)
            {
                return NotFound();
            }

            var reklamlar = await _context.Reklamlars.FindAsync(id);
            if (reklamlar == null)
            {
                return NotFound();
            }
            return View(reklamlar);
        }

        // POST: Reklamlars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReklamId,ReklamKonusu,ReklamResim,KonumId")] Reklam reklamlar)
        {
            if (id != reklamlar.ReklamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reklamlar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReklamlarExists(reklamlar.ReklamId))
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
            return View(reklamlar);
        }

        // GET: Reklamlars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reklamlars == null)
            {
                return NotFound();
            }

            var reklamlar = await _context.Reklamlars
                .FirstOrDefaultAsync(m => m.ReklamId == id);
            if (reklamlar == null)
            {
                return NotFound();
            }

            return View(reklamlar);
        }

        // POST: Reklamlars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reklamlars == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Reklamlars'  is null.");
            }
            var reklamlar = await _context.Reklamlars.FindAsync(id);
            if (reklamlar != null)
            {
                _context.Reklamlars.Remove(reklamlar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReklamlarExists(int id)
        {
          return (_context.Reklamlars?.Any(e => e.ReklamId == id)).GetValueOrDefault();
        }
    }
}
