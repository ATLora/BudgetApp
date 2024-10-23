using BudgetApp.Models.CoreModels;
using BudgetApp.Models;
using Microsoft.AspNetCore.Mvc;
using BudgetApp.Services.Interfaces;

namespace BudgetApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ICategoryService _categoryService;

        public CategoryController(ApplicationDbContext context, ICategoryService categoryService)
        {
            _db = context;
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.CreateCategory(category);
                return RedirectToAction("Index", "Create"); 
            }
            return View(category);
        }
    }
}
