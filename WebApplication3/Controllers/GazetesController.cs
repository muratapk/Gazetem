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
    public class GazetesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GazetesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gazetes
        public async Task<IActionResult> Index()
        {
              return _context.Gazetes != null ? 
                          View(await _context.Gazetes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Gazetes'  is null.");
        }

        // GET: Gazetes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gazetes == null)
            {
                return NotFound();
            }

            var gazete = await _context.Gazetes
                .FirstOrDefaultAsync(m => m.GazeteId == id);
            if (gazete == null)
            {
                return NotFound();
            }

            return View(gazete);
        }

        // GET: Gazetes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gazetes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GazeteId,GazeteAdi,GazeteLogo,GazeteSlogan,GazeteEmail,GazetFacebook,GazeteInstagram,GazeteYoutube,GazeteTelefon,GazeteAdres")] Gazete gazete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gazete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gazete);
        }

        // GET: Gazetes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gazetes == null)
            {
                return NotFound();
            }

            var gazete = await _context.Gazetes.FindAsync(id);
            if (gazete == null)
            {
                return NotFound();
            }
            return View(gazete);
        }

        // POST: Gazetes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GazeteId,GazeteAdi,GazeteLogo,GazeteSlogan,GazeteEmail,GazetFacebook,GazeteInstagram,GazeteYoutube,GazeteTelefon,GazeteAdres")] Gazete gazete)
        {
            if (id != gazete.GazeteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gazete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GazeteExists(gazete.GazeteId))
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
            return View(gazete);
        }

        // GET: Gazetes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gazetes == null)
            {
                return NotFound();
            }

            var gazete = await _context.Gazetes
                .FirstOrDefaultAsync(m => m.GazeteId == id);
            if (gazete == null)
            {
                return NotFound();
            }

            return View(gazete);
        }

        // POST: Gazetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gazetes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Gazetes'  is null.");
            }
            var gazete = await _context.Gazetes.FindAsync(id);
            if (gazete != null)
            {
                _context.Gazetes.Remove(gazete);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GazeteExists(int id)
        {
          return (_context.Gazetes?.Any(e => e.GazeteId == id)).GetValueOrDefault();
        }
    }
}
