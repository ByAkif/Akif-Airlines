using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web12412412.Models;

namespace WebOdev.Controllers
{
    public class UcusController : Controller
    {
        BiletContext _context = new BiletContext();

        // GET: Ucus
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("SessionAdmin") != null)
            {
                var biletContext = _context.Ucuslar.Include(u => u.Ucak);
                return View(await biletContext.ToListAsync());
            }
            else
            {
                TempData["Mesaj3"] = "Lütfen Login olunuz";
                return RedirectToAction("Login", "Admin");
            }
        }

        // GET: Ucus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ucuslar == null)
            {
                return NotFound();
            }

            var ucus = await _context.Ucuslar
                .Include(u => u.Ucak)
                .FirstOrDefaultAsync(m => m.UcusId == id);
            if (ucus == null)
            {
                return NotFound();
            }

            return View(ucus);
        }

        // GET: Ucus/Create
        public IActionResult Create()
        {
            ViewData["UcakId"] = new SelectList(_context.Ucaklar, "UcakId", "UcakAdi");
            return View();
        }

        // POST: Ucus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UcusId,Nereden,Nereye,GidisTarihi,DonusTarihi,KalkisSaat,VarisSaat,UcakId,doluKoltukSayisi")] Ucus ucus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ucus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UcakId"] = new SelectList(_context.Ucaklar, "UcakId", "UcakAdi", ucus.UcakId);
            return View(ucus);
        }

        // GET: Ucus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ucuslar == null)
            {
                return NotFound();
            }

            var ucus = await _context.Ucuslar.FindAsync(id);
            if (ucus == null)
            {
                return NotFound();
            }
            ViewData["UcakId"] = new SelectList(_context.Ucaklar, "UcakId", "UcakAdi", ucus.UcakId);
            return View(ucus);
        }

        // POST: Ucus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UcusId,Nereden,Nereye,GidisTarihi,DonusTarihi,KalkisSaat,VarisSaat,UcakId,doluKoltukSayisi")] Ucus ucus)
        {
            if (id != ucus.UcusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ucus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UcusExists(ucus.UcusId))
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
            ViewData["UcakId"] = new SelectList(_context.Ucaklar, "UcakId", "UcakAdi", ucus.UcakId);
            return View(ucus);
        }

        // GET: Ucus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ucuslar == null)
            {
                return NotFound();
            }

            var ucus = await _context.Ucuslar
                .Include(u => u.Ucak)
                .FirstOrDefaultAsync(m => m.UcusId == id);
            if (ucus == null)
            {
                return NotFound();
            }

            return View(ucus);
        }

        // POST: Ucus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ucuslar == null)
            {
                return Problem("Entity set 'BiletContext.Ucuslar'  is null.");
            }
            var ucus = await _context.Ucuslar.FindAsync(id);
            if (ucus != null)
            {
                _context.Ucuslar.Remove(ucus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UcusExists(int id)
        {
          return (_context.Ucuslar?.Any(e => e.UcusId == id)).GetValueOrDefault();
        }
    }
}
