using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourProject.Models;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Admin paneli ana sayfası
    public IActionResult AdminPanel()
    {
        // Güzergahları ve uçakları getir
        var routes = _context.Routes.Include(r => r.Aircraft).ToList();
        return View(routes);
    }

    // Diğer admin işlemleri için metotlar eklenebilir
}
