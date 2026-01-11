using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication43.Data;
using WebApplication43.Models;
using WebApplication43.ViewModels;

namespace WebApplication43.Controllers
{
    public class HomeController : Controller
    {
        private DoggerDBContext _context { get; }
        public HomeController (DoggerDBContext context)
        {
                _context = context;
        }
        public IActionResult Index()
        {
            List<Product>products=_context.Products.Include(p=>p.ProductImages).Include(p=>p.Category).Where(p=>!p.IsDeleted).ToList();
            Category category = _context.Categories.FirstOrDefault();
            HomeViewModel home = new HomeViewModel()
            {
                Products = products,
                Category = category,
            };
            return View(home);
        }
    }
}
