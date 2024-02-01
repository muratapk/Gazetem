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
    public class KatagorisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KatagorisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Katagoris
        public async Task<IActionResult> Index()
        {
              return _context.katagoris != null ? 
                          View(await _context.katagoris.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.katagoris'  is null.");
        }

        // GET: Katagoris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.katagoris == null)
            {
                return NotFound();
            }

            var katagori = await _context.katagoris
                .FirstOrDefaultAsync(m => m.KatagoriId == id);
            if (katagori == null)
            {
                return NotFound();
            }

            return View(katagori);
        }

        // GET: Katagoris/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Katagoris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KatagoriId,KatagoriAdi")] Katagori katagori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(katagori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(katagori);
        }

        // GET: Katagoris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.katagoris == null)
            {
                return NotFound();
            }

            var katagori = await _context.katagoris.FindAsync(id);
            if (katagori == null)
            {
                return NotFound();
            }
            return View(katagori);
        }

        // POST: Katagoris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KatagoriId,KatagoriAdi")] Katagori katagori)
        {
            if (id != katagori.KatagoriId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(katagori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KatagoriExists(katagori.KatagoriId))
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
            return View(katagori);
        }

        // GET: Katagoris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.katagoris == null)
            {
                return NotFound();
            }

            var katagori = await _context.katagoris
                .FirstOrDefaultAsync(m => m.KatagoriId == id);
            if (katagori == null)
            {
                return NotFound();
            }

            return View(katagori);
        }

        // POST: Katagoris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.katagoris == null)
            {
                return Problem("Entity set 'ApplicationDbContext.katagoris'  is null.");
            }
            var katagori = await _context.katagoris.FindAsync(id);
            if (katagori != null)
            {
                _context.katagoris.Remove(katagori);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KatagoriExists(int id)
        {
          return (_context.katagoris?.Any(e => e.KatagoriId == id)).GetValueOrDefault();
        }
    }
}
