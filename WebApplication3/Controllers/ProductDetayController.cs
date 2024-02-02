using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;

namespace WebApplication3.Controllers
{
    public class ProductDetayController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductDetayController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index(int? id)
        {
            var sorgu = _context.haberlers.Where(x => x.HaberId == id).FirstOrDefault();
            return View(sorgu);
        }
    }
}
