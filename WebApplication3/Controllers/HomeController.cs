using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        

        public HomeController(ApplicationDbContext context) 
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Detay(int? id)
        {
            var sorgu = _context.haberlers.Where(x=>x.HaberId==id).FirstOrDefault();
           return  View(sorgu);
        }

       
    }
}