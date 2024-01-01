using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web12412412.Models;

namespace Web12412412.Controllers
{
    public class UcakController : Controller
    {
        BiletContext _context = new BiletContext();

        // GET: Ucak
        public async Task<IActionResult> Index()
        {
            if(HttpContext.Session.GetString("SessionAdmin") != null)
            {
                return _context.Ucaklar != null ?
                       View(await _context.Ucaklar.ToListAsync()) :
                       Problem("Entity set 'BiletContext.Ucaklar'  is null.");
            }
            else
            {
                TempData["Mesaj2"] = "Lütfen Login olunuz";
                return RedirectToAction("Login", "Admin");
            }
           
        }

        // GET: Ucak/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ucaklar == null)
            {
                return NotFound();
            }

            var ucak = await _context.Ucaklar
                .FirstOrDefaultAsync(m => m.UcakId == id);
            if (ucak == null)
            {
                return NotFound();
            }

            return View(ucak);
        }

        // GET: Ucak/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ucak/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UcakId,UcakAdi,KoltukSayisi,Fiyat,doluKoltukSayisi")] Ucak ucak)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ucak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ucak);
        }

        // GET: Ucak/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ucaklar == null)
            {
                return NotFound();
            }

            var ucak = await _context.Ucaklar.FindAsync(id);
            if (ucak == null)
            {
                return NotFound();
            }
            return View(ucak);
        }

        // POST: Ucak/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UcakId,UcakAdi,KoltukSayisi,Fiyat,doluKoltukSayisi")] Ucak ucak)
        {
            if (id != ucak.UcakId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ucak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UcakExists(ucak.UcakId))
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
            return View(ucak);
        }

        // GET: Ucak/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ucaklar == null)
            {
                return NotFound();
            }

            var ucak = await _context.Ucaklar
                .FirstOrDefaultAsync(m => m.UcakId == id);
            if (ucak == null)
            {
                return NotFound();
            }

            return View(ucak);
        }

        // POST: Ucak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ucaklar == null)
            {
                return Problem("Entity set 'BiletContext.Ucaklar'  is null.");
            }
            var ucak = await _context.Ucaklar.FindAsync(id);
            if (ucak != null)
            {
                _context.Ucaklar.Remove(ucak);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UcakExists(int id)
        {
          return (_context.Ucaklar?.Any(e => e.UcakId == id)).GetValueOrDefault();
        }
    }
}
