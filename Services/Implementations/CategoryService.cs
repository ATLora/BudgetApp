using BudgetApp.Models;
using BudgetApp.Models.CoreModels;
using BudgetApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _db;

        public CategoryService(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task CreateCategory(Category category)
        {
            var newCategory = new Category()
            {
                Name = category.Name,
                Type = category.Type,
            };
            if (category.Type == "Expense")
            {
                newCategory.Icon = "fa-solid fa-cart-shopping";
            }
            else if (category.Type == "Income")
            {
                newCategory.Icon = "fa solid fa-dollar-sign";
            }
            _db.Categories.Add(newCategory);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<string> GetCategoryName(int categoryId)
        {
            var category = await _db.Categories.SingleOrDefaultAsync(c => c.Id == categoryId);
            return category?.Name ?? string.Empty;
        }
    }
}
