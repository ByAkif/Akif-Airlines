using H12Auth2C.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace H12Auth2C.Controllers
{
   
    public class UcusKontrolController : Controller
    {
 

public class UcusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UcusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Uçuş listesini gösteren sayfa
        public IActionResult Index()
        {
            var ucuslar = _context.Ucuslar.ToList();
            return View(ucuslar);
        }

        // Uçuş detaylarını gösteren sayfa
        public IActionResult Detay(int id)
        {
            var ucus = _context.Ucuslar.Find(id);

            if (ucus == null)
            {
                return NotFound();
            }

            return View(ucus);
        }

        // Uçuş rezervasyon formu
        public IActionResult Rezervasyon(int id)
        {
            var ucus = _context.Ucuslar.Find(id);

            if (ucus == null)
            {
                return NotFound();
            }

            return View(ucus);
        }

        // Rezervasyon işlemleri
        [HttpPost]
        public IActionResult Rezervasyon(int id, string koltukNumarasi, string adSoyad)
        {
            var ucus = _context.Ucuslar.Find(id);

            if (ucus == null)
            {
                return NotFound();
            }

            // Rezervasyon işlemleri burada yapılır (veritabanına kaydetme vb.)

            return RedirectToAction("RezervasyonOnay", new { id = id, koltukNumarasi = koltukNumarasi, adSoyad = adSoyad });
        }

        // Rezervasyon onay sayfası
        public IActionResult RezervasyonOnay(int id, string koltukNumarasi, string adSoyad)
        {
            // Rezervasyon bilgilerini görüntüleme

            return View();
        }
    }

}

}