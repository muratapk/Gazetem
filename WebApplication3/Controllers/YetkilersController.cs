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
    public class YetkilersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YetkilersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Yetkilers
        public async Task<IActionResult> Index()
        {
              return _context.Yetkilers != null ? 
                          View(await _context.Yetkilers.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Yetkilers'  is null.");
        }

        // GET: Yetkilers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Yetkilers == null)
            {
                return NotFound();
            }

            var yetkiler = await _context.Yetkilers
                .FirstOrDefaultAsync(m => m.YetkiId == id);
            if (yetkiler == null)
            {
                return NotFound();
            }

            return View(yetkiler);
        }

        // GET: Yetkilers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yetkilers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YetkiId,YetkiAdi")] Yetkiler yetkiler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yetkiler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yetkiler);
        }

        // GET: Yetkilers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Yetkilers == null)
            {
                return NotFound();
            }

            var yetkiler = await _context.Yetkilers.FindAsync(id);
            if (yetkiler == null)
            {
                return NotFound();
            }
            return View(yetkiler);
        }

        // POST: Yetkilers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("YetkiId,YetkiAdi")] Yetkiler yetkiler)
        {
            if (id != yetkiler.YetkiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yetkiler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YetkilerExists(yetkiler.YetkiId))
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
            return View(yetkiler);
        }

        // GET: Yetkilers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Yetkilers == null)
            {
                return NotFound();
            }

            var yetkiler = await _context.Yetkilers
                .FirstOrDefaultAsync(m => m.YetkiId == id);
            if (yetkiler == null)
            {
                return NotFound();
            }

            return View(yetkiler);
        }

        // POST: Yetkilers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Yetkilers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Yetkilers'  is null.");
            }
            var yetkiler = await _context.Yetkilers.FindAsync(id);
            if (yetkiler != null)
            {
                _context.Yetkilers.Remove(yetkiler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YetkilerExists(int id)
        {
          return (_context.Yetkilers?.Any(e => e.YetkiId == id)).GetValueOrDefault();
        }
    }
}
