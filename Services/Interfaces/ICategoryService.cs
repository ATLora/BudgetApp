using BudgetApp.Models.CoreModels;

namespace BudgetApp.Services.Interfaces
{
    public interface ICategoryService
    {
        Task CreateCategory(Category category);
        Task<List<Category>> GetAllCategories();
        Task<string> GetCategoryName(int categoryId);
    }
}
