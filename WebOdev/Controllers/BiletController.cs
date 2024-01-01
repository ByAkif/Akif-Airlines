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
    public class BiletController : Controller
    {
        BiletContext _context = new BiletContext();

        // GET: Bilet
        public async Task<IActionResult> Index()
        {
            var biletContext = _context.Biletler.Include(b => b.Ucak);
            return View(await biletContext.ToListAsync());
        }

        // GET: Bilet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Biletler == null)
            {
                return NotFound();
            }

            var bilet = await _context.Biletler
                .Include(b => b.Ucak)
                .FirstOrDefaultAsync(m => m.BiletId == id);
            if (bilet == null)
            {
                return NotFound();
            }

            return View(bilet);
        }

        // GET: Bilet/Create
        public IActionResult Create()
        {
            ViewData["UcakId"] = new SelectList(_context.Ucaklar, "UcakId", "UcakAdi");
            return View();
        }

        // POST: Bilet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BiletId,KalkisYeri,VarisYeri,GidisTarihi,DonusTarihi,KalkisSaat,UcakId,KoltukNumarasi")] Bilet bilet)
        {
            List<Sehir> sehirListesi = _context.Sehir.ToList();

            ViewBag.SehirListesi = new SelectList(sehirListesi, "Id", "SehirAdi");


            if (ModelState.IsValid)
            {
                _context.Add(bilet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UcakId"] = new SelectList(_context.Ucaklar, "UcakId", "UcakAdi", bilet.UcakId);
            return View(bilet);
        }

        // GET: Bilet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Biletler == null)
            {
                return NotFound();
            }

            var bilet = await _context.Biletler.FindAsync(id);
            if (bilet == null)
            {
                return NotFound();
            }
            ViewData["UcakId"] = new SelectList(_context.Ucaklar, "UcakId", "UcakAdi", bilet.UcakId);
            return View(bilet);
        }

        // POST: Bilet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BiletId,KalkisYeri,VarisYeri,GidisTarihi,DonusTarihi,KalkisSaat,UcakId,KoltukNumarasi")] Bilet bilet)
        {
            if (id != bilet.BiletId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bilet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiletExists(bilet.BiletId))
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
            ViewData["UcakId"] = new SelectList(_context.Ucaklar, "UcakId", "UcakAdi", bilet.UcakId);
            return View(bilet);
        }

        // GET: Bilet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Biletler == null)
            {
                return NotFound();
            }

            var bilet = await _context.Biletler
                .Include(b => b.Ucak)
                .FirstOrDefaultAsync(m => m.BiletId == id);
            if (bilet == null)
            {
                return NotFound();
            }

            return View(bilet);
        }

        // POST: Bilet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Biletler == null)
            {
                return Problem("Entity set 'BiletContext.Biletler'  is null.");
            }
            var bilet = await _context.Biletler.FindAsync(id);
            if (bilet != null)
            {
                _context.Biletler.Remove(bilet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BiletExists(int id)
        {
          return (_context.Biletler?.Any(e => e.BiletId == id)).GetValueOrDefault();
        }

    }
}
