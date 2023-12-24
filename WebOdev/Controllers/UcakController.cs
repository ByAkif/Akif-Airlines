using Microsoft.AspNetCore.Mvc;

namespace WebOdev.Controllers
{
    public class UcakController : Controller
    {
        private readonly UcakRezervasyonDbContext _context;

        public UcakController(UcakRezervasyonDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ucaklar = _context.Ucaklar.Include(u => u.Guzergahlar).ToList();
            return View(ucaklar);
        }

        // Diğer eylemler buraya eklenebilir.
    }

}
