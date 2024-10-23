using BudgetApp.Models;
using BudgetApp.Models.CoreModels;
using BudgetApp.Services.Interfaces;

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
    }
}
