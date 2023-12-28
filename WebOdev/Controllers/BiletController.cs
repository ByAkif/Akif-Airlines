using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebOdev.Models;
using WebOdev.Models;

public class BiletController : Controller
{
    private readonly ApplicationDbContext _context;

    public BiletController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Bilet rezervasyon formunu gösterir
    public IActionResult RezervasyonFormu()
    {
        return View();
    }

    // Bilet rezervasyonunu işler ve onay sayfasına yönlendirir
    [HttpPost]
    public IActionResult RezervasyonFormu(Bilet bilet)
    {
        if (ModelState.IsValid)
        {
            // Veritabanına bilet ekleyin
            _context.Biletler.Add(bilet);
            _context.SaveChanges();

            // Onay sayfasına yönlendirin
            return RedirectToAction("RezervasyonOnayi", new { biletId = bilet.Id });
        }

        // Model geçerli değilse formu tekrar gösterin
        return View(bilet);
    }

    // Rezervasyon onay sayfasını gösterir
    public IActionResult RezervasyonOnayi(int biletId)
    {
        // Bilet bilgilerini veritabanından alın
        var bilet = _context.Biletler.Find(biletId);

        if (bilet == null)
        {
            return NotFound();
        }

        return View(bilet);
    }
}
