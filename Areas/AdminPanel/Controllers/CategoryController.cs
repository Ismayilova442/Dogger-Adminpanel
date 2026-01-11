using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication43.Areas.AdminPanel.ViewModels;
using WebApplication43.Data;
using WebApplication43.Models;

namespace WebApplication43.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        private DoggerDBContext _context { get; }
        public CategoryController (DoggerDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Categories.Where(p=>!p.IsDeleted));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(CategoryViewModel categoryViewModel)
        {
            Category category = new Category()
            {
                Name = categoryViewModel.Name,
                Description = categoryViewModel.Description,
            };
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Category existcategory=_context.Categories.Where(p=>!p.IsDeleted).FirstOrDefault(p=>p.Id==id);
            if (existcategory == null)
            {
                return NotFound();
            }
            return View(existcategory); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, CategoryViewModel category)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Category existcategory = _context.Categories.Where(p => !p.IsDeleted).FirstOrDefault(p => p.Id == id);
            if (existcategory == null)
            {
                return NotFound();
            }
            existcategory.Name=category.Name;
            existcategory.Description=category.Description; 
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Category existcategory = _context.Categories.Where(p => !p.IsDeleted).FirstOrDefault(p => p.Id == id);
            if (existcategory == null)
            {
                return NotFound();
            }
            _context.Remove(existcategory);
           await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
