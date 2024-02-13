using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
