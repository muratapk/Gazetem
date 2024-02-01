using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;

namespace WebApplication3.ViewComponents
{
    public class TrendListComponent:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public TrendListComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var sorgu=_context.haberlers.OrderByDescending(x=>x.HaberId).Take(8).ToList();   
            return View(sorgu);
        }
    }
}
