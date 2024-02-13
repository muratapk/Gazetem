using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
           
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Kulanıcılar gelen)
        {
            var sorgu = _context.Kulanıcılars.Where(x => x.KullaniciEmail == gelen.KullaniciEmail && x.KulaniciSifre == gelen.KulaniciSifre).FirstOrDefault();
            if(sorgu!=null)
            {
                HttpContext.Session.SetString("KulaniciEmail", gelen.KullaniciEmail);

                var claims = new List<Claim> {
                     new Claim(ClaimTypes.Email, gelen.KullaniciEmail),
                     new Claim(ClaimTypes.Role,gelen.YetkiId.ToString())
                    };
                var claimIdentity=new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(claimIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Kulanıcılar");
            }
            return View();
        }
    }
}
