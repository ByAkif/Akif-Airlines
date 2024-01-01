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
    public class KullaniciController : Controller
    {
        BiletContext _context = new BiletContext();

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("SessionKullanici") != null)
            {
                var cookoption = new CookieOptions();
                {
                    cookoption.Expires = DateTime.Now.AddDays(1);
                }
                Response.Cookies.Append("Kullanici", HttpContext.Session.GetString("SessionKullanici"), cookoption);
                return RedirectToAction("Index", "Kullanici");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Kullanici kullanici)
        {

            var login = _context.Kullanicilar.Where(_context => _context.Email == kullanici.Email && _context.Password == kullanici.Password).FirstOrDefault();
            if (login != null)
            {
                HttpContext.Session.SetString("SessionKullanici",kullanici.FirstName );
                var cookoption = new CookieOptions();
                {
                    cookoption.Expires = DateTime.Now.AddDays(1);
                }
                Response.Cookies.Append("Kullanici", HttpContext.Session.GetString("SessionKullanici"), cookoption);
                return RedirectToAction("Index", "Kullanici");
            }
            else
            {
                ViewBag.Message = "Kullanıcı adı veya şifre hatalı";
                return View();
            }
        }


        // GET: Kullanici
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("SessionAdmin") != null)
            {
                return _context.Kullanicilar != null ?
                          View(await _context.Kullanicilar.ToListAsync()) :
                          Problem("Entity set 'BiletContext.Kullanicilar'  is null.");
            }
            else
            {
                TempData["Mesaj4"] = "Lütfen Login olunuz";
                return RedirectToAction("Login", "Admin");
            }

        }

        // GET: Kullanici/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kullanicilar == null)
            {
                return NotFound();
            }

            var kullanici = await _context.Kullanicilar
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (kullanici == null)
            {
                return NotFound();
            }

            return View(kullanici);
        }

        // GET: Kullanici/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kullanici/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,FirstName,LastName,Email,Password,CPassword,PhoneNumber,Age,IdentityNumber")] Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kullanici);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kullanici);
        }

        // GET: Kullanici/Create
        public IActionResult Create2()
        {
            return View();
        }

        // POST: Kullanici/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create2([Bind("UserId,FirstName,LastName,Email,Password,CPassword,PhoneNumber,Age,IdentityNumber")] Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kullanici);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kullanici);
        }

        public IActionResult Profil(Kullanici kullanici)
        {
            if (HttpContext.Session.GetString("SessionUser") != null)
            {
                return View(kullanici);
            }
            else
            {
                TempData["Mesaj4"] = "Lütfen Login olunuz";
                return RedirectToAction("Login", "Home");
            }
            /*
            if (ModelState.IsValid)
            {
                return View(kullanici);
            }
            else
            {
                ViewBag.Mesaj = "Lütfen bilgilerinizi kontrol ediniz.";
                return View("Index");
            }
            var login = BiletContext.Adminler.Where(x => x.AdminName == admin.AdminName && x.Password == admin.Password).FirstOrDefault();
            if (login != null)
            {
                HttpContext.Session.SetString("SessionAdmin", admin.AdminName);
                var cookoption = new CookieOptions();
                {
                    cookoption.Expires = DateTime.Now.AddDays(1);
                }
                Response.Cookies.Append("Admin", HttpContext.Session.GetString("SessionAdmin"), cookoption);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.Message = "Kullanıcı adı veya şifre hatalı";
                return View();
            }
            */
        }

        // GET: Kullanici/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kullanicilar == null)
            {
                return NotFound();
            }

            var kullanici = await _context.Kullanicilar.FindAsync(id);
            if (kullanici == null)
            {
                return NotFound();
            }
            return View(kullanici);
        }

        // POST: Kullanici/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,FirstName,LastName,Email,Password,CPassword,PhoneNumber,Age,IdentityNumber")] Kullanici kullanici)
        {
            if (id != kullanici.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kullanici);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KullaniciExists(kullanici.UserId))
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
            return View(kullanici);
        }

        // GET: Kullanici/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kullanicilar == null)
            {
                return NotFound();
            }

            var kullanici = await _context.Kullanicilar
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (kullanici == null)
            {
                return NotFound();
            }

            return View(kullanici);
        }

        // POST: Kullanici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kullanicilar == null)
            {
                return Problem("Entity set 'BiletContext.Kullanicilar'  is null.");
            }
            var kullanici = await _context.Kullanicilar.FindAsync(id);
            if (kullanici != null)
            {
                _context.Kullanicilar.Remove(kullanici);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KullaniciExists(int id)
        {
            return (_context.Kullanicilar?.Any(e => e.UserId == id)).GetValueOrDefault();
        }

        public IActionResult Cikis()
        { 
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
