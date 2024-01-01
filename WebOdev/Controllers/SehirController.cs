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
    public class SehirController : Controller
    {
        BiletContext _context = new BiletContext();

        // GET: Sehir
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("SessionAdmin") != null)
            {
                return _context.Sehir != null ?
                          View(await _context.Sehir.ToListAsync()) :
                          Problem("Entity set 'BiletContext.Sehir'  is null.");
            }
            else
            {
                TempData["Mesaj6"] = "Lütfen Login olunuz";
                return RedirectToAction("Login", "Admin");
            }
           
        }

        // GET: Sehir/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sehir == null)
            {
                return NotFound();
            }

            var sehir = await _context.Sehir
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sehir == null)
            {
                return NotFound();
            }

            return View(sehir);
        }

        // GET: Sehir/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sehir/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SehirAdi")] Sehir sehir)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sehir);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sehir);
        }

        // GET: Sehir/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sehir == null)
            {
                return NotFound();
            }

            var sehir = await _context.Sehir.FindAsync(id);
            if (sehir == null)
            {
                return NotFound();
            }
            return View(sehir);
        }

        // POST: Sehir/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SehirAdi")] Sehir sehir)
        {
            if (id != sehir.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sehir);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SehirExists(sehir.Id))
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
            return View(sehir);
        }

        // GET: Sehir/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sehir == null)
            {
                return NotFound();
            }

            var sehir = await _context.Sehir
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sehir == null)
            {
                return NotFound();
            }

            return View(sehir);
        }

        // POST: Sehir/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sehir == null)
            {
                return Problem("Entity set 'BiletContext.Sehir'  is null.");
            }
            var sehir = await _context.Sehir.FindAsync(id);
            if (sehir != null)
            {
                _context.Sehir.Remove(sehir);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SehirExists(int id)
        {
          return (_context.Sehir?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
