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
    public class KulanıcılarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KulanıcılarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kulanıcılar
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Kulanıcılars.Include(k => k.Yetkiler);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Kulanıcılar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kulanıcılars == null)
            {
                return NotFound();
            }

            var kulanıcılar = await _context.Kulanıcılars
                .Include(k => k.Yetkiler)
                .FirstOrDefaultAsync(m => m.KulanıcıId == id);
            if (kulanıcılar == null)
            {
                return NotFound();
            }

            return View(kulanıcılar);
        }

        // GET: Kulanıcılar/Create
        public IActionResult Create()
        {
            ViewData["YetkiId"] = new SelectList(_context.Yetkilers, "YetkiId", "YetkiId");
            return View();
        }

        // POST: Kulanıcılar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KulanıcıId,KulaniciSifre,KulaniciAdi,KullaniciEmail,YetkiId")] Kulanıcılar kulanıcılar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kulanıcılar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["YetkiId"] = new SelectList(_context.Yetkilers, "YetkiId", "YetkiId", kulanıcılar.YetkiId);
            return View(kulanıcılar);
        }

        // GET: Kulanıcılar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kulanıcılars == null)
            {
                return NotFound();
            }

            var kulanıcılar = await _context.Kulanıcılars.FindAsync(id);
            if (kulanıcılar == null)
            {
                return NotFound();
            }
            ViewData["YetkiId"] = new SelectList(_context.Yetkilers, "YetkiId", "YetkiId", kulanıcılar.YetkiId);
            return View(kulanıcılar);
        }

        // POST: Kulanıcılar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KulanıcıId,KulaniciSifre,KulaniciAdi,KullaniciEmail,YetkiId")] Kulanıcılar kulanıcılar)
        {
            if (id != kulanıcılar.KulanıcıId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kulanıcılar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KulanıcılarExists(kulanıcılar.KulanıcıId))
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
            ViewData["YetkiId"] = new SelectList(_context.Yetkilers, "YetkiId", "YetkiId", kulanıcılar.YetkiId);
            return View(kulanıcılar);
        }

        // GET: Kulanıcılar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kulanıcılars == null)
            {
                return NotFound();
            }

            var kulanıcılar = await _context.Kulanıcılars
                .Include(k => k.Yetkiler)
                .FirstOrDefaultAsync(m => m.KulanıcıId == id);
            if (kulanıcılar == null)
            {
                return NotFound();
            }

            return View(kulanıcılar);
        }

        // POST: Kulanıcılar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kulanıcılars == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Kulanıcılars'  is null.");
            }
            var kulanıcılar = await _context.Kulanıcılars.FindAsync(id);
            if (kulanıcılar != null)
            {
                _context.Kulanıcılars.Remove(kulanıcılar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KulanıcılarExists(int id)
        {
          return (_context.Kulanıcılars?.Any(e => e.KulanıcıId == id)).GetValueOrDefault();
        }
    }
}
