using Microsoft.AspNetCore.Mvc;
using WebOdev.Models;

namespace WebOdev.Controllers
{
    public class AdminController : Controller
    {

        BiletContext BiletC = new BiletContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Adminlogin()
        {
            if (HttpContext.Session.GetString("SessionAdmin") != null)
            {
                return RedirectToAction("Deshboard");
            }
            else
                ViewBag.Message = "Lütfen giriş yapınız.";  
            return View();
        }

        [HttpPost]
        public IActionResult Adminlogin(Admin login)
        {
            var x = BiletC.AdminLogin.Where(s => s.AdminName == login.AdminName && s.Password == login.Password).FirstOrDefault();
            if (x != null)
            {
                HttpContext.Session.SetString("SessionAdmin", x.AdminName);
                return RedirectToAction("Deshboard");
            }
            else
            {
                ViewBag.Message = "Kullanıcı adı veya şifre yanlış";
                return View();
            }
        }
        public IActionResult Deshboard()
        {
            return View();
        }
    }
}
