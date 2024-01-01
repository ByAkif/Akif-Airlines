using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using Web12412412.Models;

namespace Web12412412.Controllers
{
    public class AdminController : Controller
    {
        BiletContext BiletContext = new BiletContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("SessionAdmin") != null)
            {
                var cookoption = new CookieOptions();
                {
                cookoption.Expires = DateTime.Now.AddDays(1);
                }
                Response.Cookies.Append("Admin", HttpContext.Session.GetString("SessionAdmin"), cookoption);
                return RedirectToAction("Index", "Admin");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Admin admin)
        {
            
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
        }
        public IActionResult UcakEkle()
        {
            if (HttpContext.Session.GetString("SessionAdmin") is null)
            {
                ViewBag.Message = "Lütfen Login olunuz";
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Cikis()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Admin");
        }



    }

     

    
}
